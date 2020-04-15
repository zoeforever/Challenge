using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using challenge.Middleware;
using challenge.Services;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using Orleans.Serialization;

namespace challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //本服务开放端口
            int silePort = int.Parse(Configuration["Orleans:silePort"]);
            //主简仓网关端口
            int gatewayPort = int.Parse(Configuration["Orleans:gatewayPort"]);
            //主简仓开放端口    
            int mainSiloPort = int.Parse(Configuration["Orleans:mainSiloPort"]);

            StartAsyncClient(mainSiloPort, gatewayPort, silePort, services);

            services.AddMvc().AddJsonOptions(options =>
                {
                    //忽略循环引用
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //不更改元数据的key的大小写
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["AuthorityUrl"];
                    options.ApiName = "WebAppAPI";
                    options.RequireHttpsMetadata = false;
                });
            services.AddHttpClient();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IBlacklistService, BlacklistService>();


        }
        const int initializeAttemptsBeforeFailing = 5;
        private static int attempt = 0;
        async Task StartAsyncClient(int mainSiloProt, int gatewayProt, int siloProt, IServiceCollection servicesCollection)
        {
            attempt = 0;
            IClusterClient client;
            client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "challenge";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            client.Connect(RetryFilter);
            Console.WriteLine("Client successfully connect to silo host");
            servicesCollection.AddSingleton(client);

            // IClusterClient client = new ClientBuilder()
            //      .Configure<SerializationProviderOptions>(d =>
            //      {
            //          d.SerializationProviders.Add(typeof(ProtobufSerializer).GetTypeInfo());
            //          d.FallbackSerializationProvider = typeof(ProtobufSerializer).GetTypeInfo();
            //      })
            //      //与主简仓进行连接
            //      .UseStaticClustering(new IPEndPoint[] { new IPEndPoint(IPAddress.Loopback, gatewayProt) })
            //    .Configure<ClusterOptions>(options =>
            //    {
            //        options.ClusterId = "dev";
            //        options.ServiceId = "challenge";
            //    })

            ////配置刷新简仓的时间 一般来说不会这么短
            //.Configure<GatewayOptions>(d => d.GatewayListRefreshPeriod = TimeSpan.FromSeconds(5))
            //.ConfigureLogging(logging => logging.AddConsole()).Build();
            // await client.Connect();
            // Console.WriteLine("Orleans客户端已经启动");
            //servicesCollection.AddSingleton(client);

        }

        private static async Task<bool> RetryFilter(Exception exception)
        {
            if (exception.GetType() != typeof(SiloUnavailableException))
            {
                Console.WriteLine($"Cluster client failed to connect to cluster with unexpected error.  Exception: {exception}");
                return false;
            }
            attempt++;
            Console.WriteLine($"Cluster client attempt {attempt} of {initializeAttemptsBeforeFailing} failed to connect to cluster.  Exception: {exception}");
            if (attempt > initializeAttemptsBeforeFailing)
            {
                return false;
            }
            await Task.Delay(TimeSpan.FromSeconds(4));
            return true;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseMiddleware<LeakyBucket>();
            app.UseMiddleware<AddBlackList>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

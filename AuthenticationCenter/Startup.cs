using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationCenter.Classes;
using AuthenticationCenter.Services;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthenticationCenter
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
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserService, UserService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    //.AddInMemoryClients(null);
            //    .AddInMemoryApiResources();

            IdentityServerClients client = new IdentityServerClients(services.BuildServiceProvider());
            services.AddIdentityServer()//Ids4服务
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityServerResources.GetApiResources())
                .AddInMemoryIdentityResources(IdentityServerResources.GetIdentityResources())
                .AddInMemoryClients(IdentityServerClients.GetClients())//把配置文件的Client配置资源放到内存
                //.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();//自定义用户登录。即自定义用户登录又添加测试用户，则以测试用户为准
                .AddTestUsers(client.GetUsers().Result);//添加测试用户

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = Configuration["JWT:Authority"];
                  options.RequireHttpsMetadata = false;
                  options.Audience = "WebAppAPI";
                  options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
                  options.TokenValidationParameters.RequireExpirationTime = true;
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("default");
            //允许IdentityServer开始拦截路由并处理请求。
            app.UseIdentityServer();
            //添加身份验证UseMvc
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

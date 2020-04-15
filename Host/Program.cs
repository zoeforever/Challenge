using System;
using System.Net;
using System.Threading.Tasks;
using Implements;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace Host
{
    class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Host.exe silePort gatewayPort");
                return -1;
            }
            else
            {
                return RunMainAsync(int.Parse(args[0]), int.Parse(args[1])).Result;
            }
        }

        private static async Task<int> RunMainAsync(int siloPort, int gatewayPort)
        {
            try
            {
                var host = await StartSilo(siloPort, gatewayPort);
                Console.WriteLine("Press Enter to terminate...");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo(int siloPort, int gatewayPort)
        {
            // define the cluster configuration
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "challenge";
                })
                .Configure<EndpointOptions>(options => { options.AdvertisedIPAddress = IPAddress.Loopback; options.SiloPort = siloPort; options.GatewayPort = gatewayPort; })
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(RateLimit).Assembly).WithReferences().WithCodeGeneration())
            //.ConfigureLogging(logging => logging.AddConsole());
            ;
            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
    //    static void Main(string[] args)
    //    {
    //        if (args.Length != 3)
    //        {
    //            Console.WriteLine("Host.exe silePort gatewayPort mainSiloPort");
    //        }
    //        else
    //        {
    //            StartHost(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
    //            Console.WriteLine("press enter to exit");
    //            Console.ReadKey();
    //        }
    //    }

    //    /// <summary>
    //    /// 在本地启动一个Host
    //    /// </summary>
    //    /// <returns></returns>
    //    static async Task<ISiloHost> StartHost(int silePort, int gatewayPort, int mainSiloPort)
    //    {
    //        var builder = new SiloHostBuilder()
    //            .UseLocalhostClustering()
    //            .Configure<ClusterOptions>(options =>
    //            {
    //                options.ClusterId = "dev";
    //                options.ServiceId = "challenge";
    //            })
    //            .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
    //            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(RateLimit).Assembly).WithReferences())
    //            //.ConfigureLogging(logging => logging.AddConsole())
    //            ;

    //        var host = builder.Build();
    //        await host.StartAsync();
    //        return host;

    //        //var builder = new SiloHostBuilder()
    //        //         //启动一个在本地的Host 若primarySiloEndpoint属性为空 则启动主简仓 否则进行连接
    //        //         //IPAddress.Loopback为127.0.0.1
    //        //         //.UseLocalhostClustering()
    //        //         .Configure<SerializationProviderOptions>(d => { d.SerializationProviders.Add(typeof(ProtobufSerializer).GetTypeInfo()); d.FallbackSerializationProvider = typeof(ProtobufSerializer).GetTypeInfo(); })
    //        //        .UseDevelopmentClustering(new IPEndPoint(IPAddress.Loopback, mainSiloPort))
    //        //        .ConfigureEndpoints(siloPort: silePort, gatewayPort: gatewayPort)
    //        //        .Configure<ClusterOptions>(options =>
    //        //        {
    //        //            //ClusterId为集群名称 相同的名称才能被分配到一个集群中
    //        //            options.ClusterId = "dev";
    //        //            //当前服务的名称  
    //        //            options.ServiceId = "challenge";
    //        //        })
    //        //         .UseInMemoryReminderService();

    //        ////.AddStartupTask<CallGrainStartupTask>();


    //        ////进行构建 
    //        //var host = builder.Build();
    //        ////启动服务
    //        //await host.StartAsync();
    //        //return host;
    //    }
}

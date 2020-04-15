orleans1  dotnet Host.dll 11113 30000
orleans2  dotnet Host.dll 11114 30000
mysql服务 dotnet MysqlService.dll --urls="http://localhost:5000"
授权中心  dotnet AuthenticationCenter.dll --urls="http://localhost:5002"
主程序1   dotnet Challenge.dll --urls="http://localhost:7000"
主程序2   dotnet Challenge.dll --urls="http://localhost:7001"
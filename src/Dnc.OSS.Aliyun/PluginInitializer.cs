/******************************************************
    PluginInitializer.cs:aliyun oss 模块 服务注册

    创建人:gainorloss 创建日期:【2019-07-12】
    Copyright (C)         gainorloss std.
 ******************************************************/

using Aliyun.OSS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dnc.OSS.Aliyun
{
    public class PluginInitializer
         : IPluginInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Fx.Construction.Configuration;

            var options = new AliyunOSSClientOptions();
            configuration.GetSection(nameof(AliyunOSSClientOptions)).Bind(options);

            services.AddSingleton(sp => new OssClient(options.EndPoint,options.AccessKeyId,options.AccessKeySecret));
            services.AddSingleton<IOSSClient>(sp => new AliyunOSSClient(sp.GetRequiredService<OssClient>(), options));
        }
    }
}

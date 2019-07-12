/******************************************************
    AliyunOSSClientOptions.cs:aliyun oss sdk 连接相关配置包装类

    创建人:gainorloss 创建日期:【2019-07-12】
    Copyright (C)         gainorloss std.
 ******************************************************/

namespace Dnc.OSS.Aliyun
{
    public class AliyunOSSClientOptions
    {
        public string EndPoint { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string BucketName { get; set; }
    }
}

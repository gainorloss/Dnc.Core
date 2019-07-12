/******************************************************
    AliyunOSSClient.cs:aliyun oss sdk 包装

    创建人:gainorloss 创建日期:【2019-07-12】
    Copyright (C)         gainorloss std.
 ******************************************************/

using Aliyun.OSS;
using System;
using System.IO;

namespace Dnc.OSS.Aliyun
{
    /// <summary>
    ///  [RequestSizeLimit(1000_000_000)]
    /// </summary>
    public class AliyunOSSClient
        : IOSSClient
    {
        private readonly IOss _client;
        private readonly AliyunOSSClientOptions _options;
        public AliyunOSSClient(IOss client, AliyunOSSClientOptions options)
        {
            _client = client;
            _options = options;
        }
        public UploadObjectDescriptor UploadObject(Stream stream, string fileName)
        {
            var objectName = fileName.ToObjectName();
            using (stream)
            {
                var ret = _client.PutObject(_options.BucketName, objectName, stream);
                return new UploadObjectDescriptor(ret.HttpStatusCode == System.Net.HttpStatusCode.OK, fileName, $"https://{_options.BucketName}.{_options.EndPoint}/", objectName);
            }
        }
    }
}

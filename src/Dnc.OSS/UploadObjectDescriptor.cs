/******************************************************
    UploadObjectDescriptor.cs: oss上传对象描述

    创建人:gainorloss 创建日期:【2019-07-12】
    Copyright (C)         gainorloss std.
 ******************************************************/

using System;
using System.IO;

namespace Dnc.OSS
{
    public class UploadObjectDescriptor
    {
        private UploadObjectDescriptor()
        { }

        public UploadObjectDescriptor(bool success, string originalPath, string formatPathPrefix, string objectName)
        {
            SetUploadResult(success);
            SetOriginalPathAddExtNameAndObjectName(originalPath, objectName);
            SetFormatPath(formatPathPrefix);
        }

        private void SetUploadResult(bool success)
        {
            if (Success != success)
                Success = success;
        }

        private void SetFormatPath(string formatPathPrefix)
        {
            if (string.IsNullOrWhiteSpace(formatPathPrefix))
                throw new ArgumentException("message", nameof(formatPathPrefix));

            if (string.IsNullOrWhiteSpace(ExtName)) return;

            var formatPath = $"{formatPathPrefix}{ObjectName}";
            if (FormatPath.Equals(formatPathPrefix)) return;

            FormatPath = formatPathPrefix;
        }

        private void SetOriginalPathAddExtNameAndObjectName(string originalPath, string objectName)
        {
            if (string.IsNullOrWhiteSpace(originalPath))
                throw new ArgumentException("message", nameof(originalPath));

            if (OriginalPath.Equals(originalPath)) return;

            OriginalPath = originalPath;
            ExtName = Path.GetExtension(originalPath);

            objectName = objectName ?? originalPath.ToObjectName();

            if (!ObjectName.Equals(objectName))
                ObjectName = objectName;
        }

        public string OriginalPath { get; private set; }
        public string FormatPath { get; private set; }
        public string ExtName { get; private set; }
        public DateTime UploadTime { get; private set; }
        public string ObjectName { get; private set; }
        public bool Success { get; private set; }
    }
}

using System.IO;

namespace Dnc.OSS
{
    public interface IOSSClient
    {
        UploadObjectDescriptor UploadObject(Stream stream, string fileName);
    }
}

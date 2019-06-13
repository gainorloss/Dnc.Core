namespace Dnc.AspNetCore.WebApi
{
    public class ResponseBase
    {
        /// <summary>
        ///Tag the request is success or failed <see cref="Models.HttpStatusCodes"/>.
        /// </summary>
        public HttpStatusCodes Status { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
    }
}

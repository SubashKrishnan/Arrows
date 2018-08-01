using System.IO;
using System.Net.Http;
using System.Web.Http.Filters;
namespace Trade.ApiAuth
{
    public class DeflateCompressionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var content = actionExecutedContext.Response.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            var zlibbedContent = bytes == null ? new byte[0] :
            CompressionHelper.DeflateByte(bytes);
            actionExecutedContext.Response.Content = new ByteArrayContent(zlibbedContent);
            actionExecutedContext.Response.Content.Headers.Remove("Content-Type");
            actionExecutedContext.Response.Content.Headers.Add("Content-encoding", "deflate");
            actionExecutedContext.Response.Content.Headers.Add("Content-Type", "application/json");
            base.OnActionExecuted(actionExecutedContext);
        }
    }
    public class CompressionHelper
    {
        public static byte[] DeflateByte(byte[] str)
        {
            if (str == null)
            {
                return null;
            }
            using (var output = new MemoryStream())
            {
                using (
                var compressor = new Ionic.Zlib.GZipStream(
                output, Ionic.Zlib.CompressionMode.Compress,
                Ionic.Zlib.CompressionLevel.BestSpeed))
                {
                    compressor.Write(str, 0, str.Length);
                }
                return output.ToArray();
            }
        }
    }
}
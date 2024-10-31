using Microsoft.AspNetCore.Http;

namespace VYG.Core.ExtensionMethods
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public static string GetIpAddress(this HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace PeopleApp.Api.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        private ContentResult GetContentResult(int statusCode, string content)
        {
            var result=new ContentResult();
            result.StatusCode = statusCode;
            result.Content = content;
            return result;
        }
    //    var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
    //    var apiKey = appSettings.GetValue<string>(APIKEYNAME);
    //    //var x1=appSettings.GetRequiredSection("ApiKeyConfiguration");
    //    var x2 = appSettings.GetSection("ApiKeyConfiguration");
    //            //var appSettings2 = context.HttpContext.RequestServices.GetRequiredService<ApiKeyConfiguration>();
    //            if (appSettings == null)
    //            {
    //                context.Result = GetContentResult(401, "Appsettings not found");
    //                return;
    //            }
    //var keyValue = appSettings[$"{APIKEYNAME}"];
    //var section = appSettings.GetSection($"AppSettings:{APIKEYNAME}");
    ////appsettings.json -> ApiKey

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Result = GetContentResult(401, "Api Key was not provided");
                    return;
                }
                var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                if (appSettings == null)
                {
                    context.Result = GetContentResult(401, "Appsettings not found");
                    return;
                }
                var apiKey = appSettings.GetValue<string>(APIKEYNAME);
                if (apiKey == null)
                {
                    context.Result = GetContentResult(401, "Appsettings - ApiKey - not found");
                    return;
                }
                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Result = GetContentResult(401, "Api Key is not valid");
                    return;
                }
                await next();
            }
            catch (Exception ex)
            {
                context.Result = GetContentResult(401, ex.Message);
                return;
            }
            
        }
    }
}


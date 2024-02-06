using Common.BaseApi.Exceptions;
using Common.BaseApi.Resources;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Presentation.BaseApi.Dtos;

namespace Presentation.BaseApi.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Method responsible for capturing all exceptions in the project.
        /// A decorator [TypeFilter(typeof(CustomExceptionFilter))] should be added to each controller.
        /// </summary>
        /// <param name="exception">Parameter where the Exception is captured.</param>
        public override void OnException(ExceptionContext context)
        {
            HttpResponseException responseException = new HttpResponseException();

            ResponseDto response = new ResponseDto();
            if (context.Exception is BusinessException)
            {
                responseException.Status = StatusCodes.Status400BadRequest;
                response.Message = context.Exception.Message;
                context.ExceptionHandled = true;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                responseException.Status = StatusCodes.Status401Unauthorized;
                response.Message = StatusCodeMessages.Status404NotFound;
                context.ExceptionHandled = true;
                //Log.Error(StatusCodeMessages.Status404NotFound);
            }
            else
            {
                responseException.Status = StatusCodes.Status500InternalServerError;
                response.Result = JsonConvert.SerializeObject(context.Exception);
                response.Message = StatusCodeMessages.Status500InternalServerError;
                context.ExceptionHandled = true;

                //Add Logs
                //Log.Fatal(context.Exception, StatusCodeMessages.Status500InternalServerError);
            }

            context.Result = new ObjectResult(responseException.Details)
            {
                StatusCode = responseException.Status,
                Value = response
            };

            if (responseException.Status == StatusCodes.Status500InternalServerError)
            {
                IHttpResponseFeature? httpResponseFeature = context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>();
                if (httpResponseFeature is not null) httpResponseFeature.ReasonPhrase = StatusCodeMessages.Status500InternalServerError;
            }

        }
    }
}

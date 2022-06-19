using System.Net;

namespace WebAPI.HomeTaskMiddleWare
{
	public class GlobalErrorHandler
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;
		public GlobalErrorHandler(RequestDelegate next, ILogger logger)
		{
			_logger = logger;
			_next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				httpContext.Response.ContentType = "application/json";
				httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				await httpContext.Response.WriteAsync(ex.Message);
			}
		}
	}
}

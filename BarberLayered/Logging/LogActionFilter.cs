using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberLayered.Filters
{
    //public class LogActionFilter : IActionFilter, IResultFilter, IExceptionFilter

    //To delete
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' is executing.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' has executed.");
        }

        //public void OnResultExecuting(ResultExecutingContext context)
        //{
        //    _logger.LogInformation($"Result for '{context.ActionDescriptor.DisplayName}' is executing.");
        //}

        //public void OnResultExecuted(ResultExecutedContext context)
        //{
        //    _logger.LogInformation($"Result for '{context.ActionDescriptor.DisplayName}' has executed.");
        //}

        //public void OnException(ExceptionContext context)
        //{
        //    _logger.LogError(context.Exception, $"An error occurred while executing action '{context.ActionDescriptor.DisplayName}'.");
        //}
    }
}
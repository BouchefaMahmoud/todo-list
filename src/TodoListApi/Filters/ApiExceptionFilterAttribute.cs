using Application.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Core;
using System;
using System.Collections.Generic;

namespace TodoListApi.Filters
{
    /// <summary>
    /// Api Exception Filter
    /// </summary>
    /// <seealso cref="ExceptionFilterAttribute" />
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(BusinessException),  HandleBusinessException },
            };
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="context">The context.</param>
        private void HandleException(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ApiExceptionFilterAttribute>>();
            logger.LogError(context.Exception, "{ExceptionMessage}", context.Exception.GetBaseException().Message);

            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        /// <summary>
        /// Handles the unknown exception.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = context.Exception.GetBaseException().Message,
                Title = "InternalServerError",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Handles the validation exception.
        /// </summary>
        /// <param name="context">The context.</param>
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = nameof(ValidationException),
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Handles the business exception.
        /// </summary>
        /// <param name="context">The context.</param>
        private void HandleBusinessException(ExceptionContext context)
        {
            var exception = context.Exception as BusinessException;

            var details = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message,
                Title = nameof(BusinessException),
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}

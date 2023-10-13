using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerServiceBase _loggerServiceBase;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerServiceBase)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerServiceBase = loggerServiceBase;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> parameters = new List<LogParameter>()
            {
                new LogParameter(){Type=request.GetType().Name,Value=request}
            };

            LogDetail logDetail = new LogDetail()
            {
                MethodName = next.Method.Name,
                LogParameters = parameters,
                User = _httpContextAccessor.HttpContext.User.Identity.Name ?? "?",
            };

            _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));

            return await next();
        }
    }
}
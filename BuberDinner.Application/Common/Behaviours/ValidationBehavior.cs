using BuberDinner.Application.Authentication.Command.Register;
using BuberDinner.Application.Services.Authentication;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Behaviours
{
    public class ValidationRegisterCommandBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationRegisterCommandBehaviour(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (result.IsValid)
                return await next();

            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

            var resultType = typeof(TResponse);

            var failureMethod = resultType
                .GetMethod("Failure", new[] { typeof(List<string>) });

            return (TResponse)failureMethod.Invoke(null, new object[] { errors })!;
        }
    }

}

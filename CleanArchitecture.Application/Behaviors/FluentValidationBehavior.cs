﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArchitecture.Application.Behaviors
{
    public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class,
        IRequest<TResponse> where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var errorDictionary = _validators
                .Select(s => s.Validate(context))
                .SelectMany(s => s.Errors)
                .GroupBy(s => s.PropertyName, s => s.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray(),

                }).ToDictionary(s => s.Key, s => s.Values[0]);

            if (errorDictionary.Any())
            {
                var error = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(error);
            }
            return await next();



        }
    }
}

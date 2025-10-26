using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eCommerce.API.ValidationFilter;
public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _provider;

    public ValidationFilter(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var arg in context.ActionArguments.Values)
        {
            if (arg == null) continue;

            var argType = arg.GetType();
            var validatorType = typeof(IValidator<>).MakeGenericType(argType);
            var validator = _provider.GetService(validatorType) as IValidator;
            if (validator == null) continue;

            var validationContextType = typeof(FluentValidation.ValidationContext<>).MakeGenericType(argType);
            var validationContext = Activator.CreateInstance(validationContextType, arg);
            var validateAsyncMethod = validatorType.GetMethod("ValidateAsync", new[] { validationContextType, typeof(CancellationToken) });
            var resultTask = (Task)validateAsyncMethod.Invoke(validator, new object[] { validationContext, CancellationToken.None });
            await resultTask.ConfigureAwait(false);

            var resultProperty = resultTask.GetType().GetProperty("Result");
            var validationResult = resultProperty.GetValue(resultTask) as FluentValidation.Results.ValidationResult;

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                context.Result = new BadRequestObjectResult(new { errors });
                return;
            }
        }

        await next();
    }
}

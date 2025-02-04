using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdmissionCommittee.Desktop;

public static class Extensions
{
    public static void AddBindings<TControl, TSource>(this TControl target,
        Expression<Func<TControl, object>> targetProperty,
        TSource source,
        Expression<Func<TSource, object>> sourceProperty,
        ErrorProvider? errorProvider = null)
        where TControl : Control
        where TSource : class
    {
        var targetName = GetPropertyName(targetProperty);
        var sourceName = GetPropertyName(sourceProperty);
        target.DataBindings.Add(targetName, source, sourceName, false, DataSourceUpdateMode.OnPropertyChanged);

        if (errorProvider != null)
        {
            target.Validating += (_, _) =>
            {
                var context = new ValidationContext(source);
                var results = new List<ValidationResult>();
                errorProvider.SetError(target, string.Empty);
                if (!Validator.TryValidateObject(source, context, results, true))
                {
                    foreach (var error in results.Where(x => x.MemberNames.Contains(sourceName)))
                    {
                        errorProvider.SetError(target, error.ErrorMessage);
                    }
                }
            };
        }
    }

    private static string GetPropertyName<TItem, TMember>(Expression<Func<TItem, TMember>> targetMember)
    {
        if (targetMember.Body is MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }

        if (targetMember.Body is UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member.Name;
            }
        }

        throw new InvalidOperationException("Неизвестный тип выражения");
    }
}
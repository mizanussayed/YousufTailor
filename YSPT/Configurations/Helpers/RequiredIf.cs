using System.ComponentModel.DataAnnotations;

namespace YSPT.Configurations.Helpers;

public class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _dependentProperty;
    private readonly object _targetValue;
    private readonly RequiredAttribute _innerAttribute = new RequiredAttribute();

    public RequiredIfAttribute(string dependentProperty, object targetValue)
    {
        _dependentProperty = dependentProperty;
        _targetValue = targetValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var field = validationContext.ObjectType.GetProperty(_dependentProperty);
        if (field != null)
        {
            var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
            if ((dependentValue == null && _targetValue == null) || (dependentValue != null && dependentValue.Equals(_targetValue)))
            {
                if (!_innerAttribute.IsValid(value))
                {
                    string name = validationContext.DisplayName;
                    ErrorMessage ??= $"{name} is required.";
                    return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(FormatErrorMessage(_dependentProperty));
        }
    }
}


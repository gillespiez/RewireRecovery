using RewireRecovery.Models;
using FluentValidation;

namespace RewireRecovery.Validator
{
    public class TriggerValidator  : AbstractValidator<Triggers>
    {
        public TriggerValidator()
        {
            RuleFor(c => c.Trigger).Must(a => ValidateStringEmpty(a)).WithMessage("Trigger should not be empty.");
        }
        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}

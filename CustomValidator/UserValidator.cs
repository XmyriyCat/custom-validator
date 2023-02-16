using Validator.Extensions;
using Validator.Implementation;

namespace CustomValidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            AddValidationRule(x => x.Name).NotNull();
        }
    }
}

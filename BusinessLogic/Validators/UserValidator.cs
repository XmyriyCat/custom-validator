using BusinessLogic.Models;
using Validator.Extensions;
using Validator.Implementation;

namespace BusinessLogic.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            AddValidationRule(x => x.Id).GreaterThan(0);
            AddValidationRule(x => x.Name).NotNull().Length(4, 44);
            AddValidationRule(x => x.Age).GreaterThanOrEqual(19);
        }
    }
}

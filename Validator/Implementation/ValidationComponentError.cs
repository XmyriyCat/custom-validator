namespace Validator.Implementation
{
    public class ValidationComponentError
    {
        public string ErrorName { get; set; }

        public ValidationComponentError(string errorMessage)
        {
            ErrorName = errorMessage;
        }
    }
}

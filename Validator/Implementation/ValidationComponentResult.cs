namespace Validator.Implementation
{
    public class ValidationComponentResult
    {
        public ValidationComponentResult()
        {
        }

        public ValidationComponentResult(ValidationComponentError error)
        {
            if (error is null)
            {
                return;
            }

            Error = error;
        }

        public ValidationComponentError Error { get; set; }

        public bool IsValid
            => Error is null;

        public override string ToString()
        {
            return Error.ErrorName;
        }
    }
}

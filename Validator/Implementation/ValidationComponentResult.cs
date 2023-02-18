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

            Errors.Add(error);
        }

        public List<ValidationComponentError> Errors { get; set; } = new List<ValidationComponentError>();

        public bool IsValid 
            => Errors.Count == 0;

        public override string ToString()
        {
            return ToString(" ");
        }

        public string ToString(string separator)
        {
            return string.Join(separator, Errors.Select(error => error.ErrorName));
        }
    }
}

namespace Validator.Implementation
{
    public class ValidationResult
    {
        private IEnumerable<ValidationError> _errors = new List<ValidationError>();
        public bool IsValid => !Errors.Any();

        public IEnumerable<ValidationError> Errors
        {
            get => _errors;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }

                var existingErrors = value.Where(error => error is not null);

                _errors = existingErrors;
            }
        }

        public void AddValidationError(ValidationError error)
        {
            if (error is null)
            {
                return;
            }

            _errors.Append(error);
        }

        public override string ToString()
        {
            return ToString(" ");
        }

        public string ToString(string separator)
        {
            return string.Join(separator, _errors.Select(error => error.Message));
        }
    }
}

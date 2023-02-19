namespace Validator.Implementation
{
    public class ValidationResult
    {
        private List<ValidationPropertyResult> _results = new List<ValidationPropertyResult>();
        public bool IsValid 
            => !Errors.Any();

        public IEnumerable<ValidationPropertyResult> Errors
        {
            get => _results;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }

                var existingErrors = value.Where(error => error is not null).ToList();

                _results = existingErrors;
            }
        }

        public void AddValidationError(ValidationPropertyResult propertyResult)
        {
            if (propertyResult is null)
            {
                return;
            }

            _results.Add(propertyResult);
        }

        public override string ToString()
        {
            return ToString(" ");
        }

        public string ToString(string separator)
        {
            return string.Join(separator, _results.Select(result => result.ToString()));
        }
    }
}

namespace Validator.Implementation
{
    public class ValidationPropertyResult
    {
        private List<ValidationComponentResult> _componentResults = new List<ValidationComponentResult>();

        public ValidationPropertyResult()
        {
        }
        
        public ValidationPropertyResult(ValidationComponentResult componentResult)
        {
            ComponentResults.Add(componentResult);
        }
        
        public List<ValidationComponentResult> ComponentResults
        {
            get
            {
                return _componentResults;
            }
            set
            {
                if (value is null)
                {
                    return;
                }

                _componentResults = value;
            }
        }

        public bool IsValid
            => ComponentResults.Count == 0;

        public void AddValidationComponentResult(ValidationComponentResult componentResult)
        {
            if (componentResult is null)
            {
                return;
            }

            _componentResults.Add(componentResult);
        }

        public override string ToString()
        {
            return ToString(" ");
        }

        public string ToString(string separator)
        {
            return string.Join(separator, _componentResults.Select(componentResult => componentResult.ToString()));
        }
    }
}

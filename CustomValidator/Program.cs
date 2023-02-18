namespace CustomValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userValidator = new UserValidator();

            var user = new User
            {
                Id = 1,
                Name = null,
                Age = 19
            };

            var validationResult = userValidator.Validate(user);

            Console.WriteLine("Hello, World!");
        }
    }
}
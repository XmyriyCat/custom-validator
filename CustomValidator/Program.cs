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
                Name = "Pavel",
                Age = 19
            };

            userValidator.Validate(user);

            Console.WriteLine("Hello, World!");
        }
    }
}
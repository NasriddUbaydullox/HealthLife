namespace Exeption_Handling
{
    internal class Program
    {
        public static string orgUserName = "Admin";
        public static string orgPassword = "Password";
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();
            try
            {
                ValidateUser(userName, password);
            }
            catch (Exception e)
            {
                Console.Clear();
                UserException a = new UserException();
                Console.WriteLine(a.Message);
                
            }
            finally
            {

                Console.WriteLine("Session finished ");

            }
        }
        public static void ValidateUser(string userName, string password)
        {
            if (password != orgPassword || userName != orgUserName)
            {
                Logger.LogError(userName, password);
                Console.WriteLine("Username or password incorrect!");

            }
            else
            {

                Console.WriteLine("Welcome to the system...");
            }
        }
        public class UserException : Exception
        {
            public const string Code = "invalid_user_credentials";
        }
        public class Logger
        {
            public static void LogError(string message, string code)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine("[" + dateTime +" ERR" + "]");
            }
        }
    }
}

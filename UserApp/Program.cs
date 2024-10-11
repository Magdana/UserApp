using UserApp;

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Register  2. Login  3. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1": // Register
                    RegisterUser(userManager);
                    break;

                case "2": // Login
                    LoginUser(userManager);
                    break;

                case "3": // Exit
                    return; 

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void RegisterUser(UserManager userManager)
    {
        Console.Write("Enter username: ");
        string userName = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter full name: ");
        string fullName = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter address: ");
        string address = Console.ReadLine();

        Console.WriteLine("Select role:\n0. Admin\n1. User");
        Role role = (Role)Enum.Parse(typeof(Role), Console.ReadLine());

        User newUser = new User(userName, password, fullName, email, age, phoneNumber, address, role);
        string result = userManager.Register(newUser);
        Console.WriteLine(result);
    }

    static void LoginUser(UserManager userManager)
    {
        Console.Write("Enter username: ");
        string userName = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string result = userManager.Authenticate(userName, password);
        Console.WriteLine(result);

        if (result.Contains("User authenticated successfully!"))
        {
            Console.WriteLine(userManager.DisplayUserInfo());
        }
    }
}

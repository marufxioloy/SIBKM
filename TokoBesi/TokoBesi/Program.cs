using System;

namespace Method
{

    // Superclass
    public class Restaurant
    {
        // Property dengan Encapsulation
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Method dengan Abstraction
        public virtual void DisplayMenu()
        {
            Console.WriteLine("Daftar menu belum tersedia.");
        }
    }

    public class WesternRestaurant : Restaurant
    {
        // Property dengan Encapsulation
        private string chefName;
        public string ChefName
        {
            get { return chefName; }
            set { chefName = value; }
        }

        // Method yang melakukan override dari superclass dengan Polymorphism
        public override void DisplayMenu()
        {
            Console.WriteLine("Menu Western Restaurant:");
            Console.WriteLine("- Fish and Chips");
            Console.WriteLine("- Chicken Confit Pasta");
            Console.WriteLine("- Beef Pasta Salad");
            Console.WriteLine("- Korean Crispy Chicken");
        }
    }

    // Subclass yang menginherit dari Restaurant
    public class IndonesianRestaurant : Restaurant
    {
        // Property dengan Encapsulation
        private string ownerName;
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        // Method yang melakukan override dari superclass dengan Polymorphism
        public override void DisplayMenu()
        {
            Console.WriteLine("Menu Indonesian Restaurant:");
            Console.WriteLine("- Nasi Goreng");
            Console.WriteLine("- Bakso");
            Console.WriteLine("- Nasi Padang");
            Console.WriteLine("- Soto");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Membuat objek dari masing-masing subclass
            WesternRestaurant westernResto = new WesternRestaurant();
            westernResto.Name = "Lux Surakarta";
            westernResto.ChefName = "Erwan Adri Wijaya";

            IndonesianRestaurant indoResto = new IndonesianRestaurant();
            indoResto.Name = "La Densa";
            indoResto.OwnerName = "Widhi Afit";

            // Memanggil method DisplayMenu() dari masing-masing objek
            Console.WriteLine(westernResto.Name + " by Chef " + westernResto.ChefName);
            westernResto.DisplayMenu();

            Console.WriteLine(indoResto.Name + " by " + indoResto.OwnerName);
            indoResto.DisplayMenu();
        }
    }
}
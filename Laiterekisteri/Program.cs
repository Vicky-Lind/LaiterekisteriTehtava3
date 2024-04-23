using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries needed to access SQL Server
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections;
using System.Runtime.CompilerServices;

namespace DeviceDb
{
    // CLASS DEFINITIONS FOR DIFFERENT DEVICE TYPES
    // --------------------------------------------

    // A super class for all kind of devices
    // =====================================
    internal class Device
    {
        // Fields and properties
        // ----------------------

        private string name = "Uusi laite";

        public string Name
        { get { return name; } set { name = value; } }

        private string purchaseDate = "1.1.1900";

        public string PurchaseDate
        { get { return purchaseDate; } set { purchaseDate = value; } }

        private double price = 0.0d;

        public double Price
        { get { return price; } set { price = value; } }

        private int warranty = 12;

        public int Warranty
        { get { return warranty; } set { warranty = value; } }

        private string processorType = "N/A";

        public string ProcessorType
        { get { return processorType; } set { processorType = value; } }

        private int amountRAM = 0;

        public int AmountRam
        { get { return amountRAM; } set { amountRAM = value; } }

        private int storageCapacity = 0;

        public int StorageCapacity
        { get { return storageCapacity; } set { storageCapacity = value; } }

        // Constructors
        // -------------

        public Device()
        {
        }

        public Device(string name)
        {
            this.name = name;
        }

        public Device(string name, string purchaseDate, double price, int warranty)
        {
            this.name = name;
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }

        // Other methods in the superclass
        // ------------
        public void ShowPurchaseInfo()
        {
            // Show purchasing data
            Console.WriteLine();
            Console.WriteLine("Laitteen hankintatiedot");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Laitteen nimi: " + this.name);
            Console.WriteLine("Ostopäivä: " + this.purchaseDate);
            Console.WriteLine("Hankinta: " + this.price);
            Console.WriteLine("Takuu: " + this.warranty + " kk");
        }

        // Show technical data
        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Laitteen tekniset tiedot");
            Console.WriteLine("------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuisti: " + AmountRam);
            Console.WriteLine("Levytila: " + StorageCapacity);
        }

        // Calculate the ending date of warranty
        public void CalculateWarrantyEndingDate()
        {
            // Convert date sring to date time
            DateTime startDate = DateTime.ParseExact(this.PurchaseDate,
                                        "yyyy-MM-dd",
                                         CultureInfo.InvariantCulture);

            // Add warranty months to purchase date
            DateTime endDate = startDate.AddMonths(this.Warranty);

            // Convert it to ISO standard format
            endDate = endDate.Date;

            string isoDate = endDate.ToString("yyyy-MM-dd");

            Console.WriteLine("Takuu päättyy: " + isoDate);
        }
    }

    // Compurer class, a subclass of Device
    // ====================================
    internal class Computer : Device
    {
        // Constructors
        // ------------
        public Computer() : base()
        { }

        public Computer(string name) : base(name)
        { }

        public void setComputerInfo()
        {
            Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
            PurchaseDate = Console.ReadLine();
            Console.Write("Hankintahinta: ");
            string price = Console.ReadLine();

            // Use error handling while trying to convert string values to numerical values
            try
            {
                Price = double.Parse(price);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virheellinen hintatieto, käytä desimaalipilkkua (,)" + ex.Message);
            }

            Console.Write("Takuun kesto kuukausina: ");
            string warranty = Console.ReadLine();

            try
            {
                Warranty = int.Parse(warranty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuna " + ex.Message);
            }

            Console.Write("Prosessorin tyyppi: ");
            ProcessorType = Console.ReadLine();
            Console.Write("Keskumuistin määrä (GB): ");
            string amountRam = Console.ReadLine();

            try
            {
                AmountRam = int.Parse(amountRam);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
            }

            Console.Write("Tallennuskapasiteetti (GB): ");
            string storageCapacity = Console.ReadLine();

            try
            {
                StorageCapacity = int.Parse(storageCapacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu " + ex.Message);
            }
            try
            {
                CalculateWarrantyEndingDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
            }
        }

        public void saveToDb()
        {
            // Add the computer to Device table
            Console.WriteLine("Lisätään tietokone Laite-tauluun");

            string connectionString = "Data Source=LS99-NOTEBOOK-2\\SQLEXPRESS;Initial Catalog=Laiterekisteri;Integrated Security=True";

            string insertCommand = $"INSERT INTO dbo.Laite (Nimi, Hankintahinta, Hankintapaiva, Takuu, Prosessori, Keskusmuisti, Tallennustila, Laitetyyppi) VALUES ('{this.Name}', {this.Price}, '{this.PurchaseDate}', {this.Warranty}, '{this.ProcessorType}', {this.AmountRam}, {this.StorageCapacity}, 'Tietokone');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(insertCommand, connection);
                command.ExecuteNonQuery();

                connection.Close();
            };
        }

        public void getComputersFromDb()
        {
            Console.WriteLine("Haetaan kaikki koneet tietokannasta...");

            string connectionString = "Data Source=LS99-NOTEBOOK-2\\SQLEXPRESS;Initial Catalog=Laiterekisteri;Integrated Security=True";

            string sqlQuery = "SELECT * FROM dbo.Laite;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.CommandTimeout = 10;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                }
                connection.Close();

                break;
            };
        }
    }

    // Tablet class, a subclass of Device
    // ====================================
    internal class Tablet : Device
    {
        // subclass specific fields and properties
        // ---------------------------------------

        private string operatingSystem;

        public string OperatingSystem
        { get { return operatingSystem; } set { operatingSystem = value; } }

        private bool stylusEnabled = false;

        public bool StylusEnabled
        { get { return stylusEnabled; } set { stylusEnabled = value; } }

        // Constructors
        // --------------

        public Tablet() : base()
        {
        }

        public Tablet(string name) : base(name)
        {
        }

        // Methods specific to Tablet class
        // ----------------------------
        public void TabletInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Tabletin erityitiedot");
            Console.WriteLine("---------------------");
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }
    }

    // THE PROGRAM
    // ===========
    internal class Program
    {
        private static void Main(string[] args)

        {
            // For ever loop to run the program
            while (true)
            {
                Console.WriteLine("Minkä laitteen tiedot tallenetaan? 🤖");
                Console.Write("1 tietokone 💻, 2 tabletti 📱: ");
                string type = Console.ReadLine();
                Console.WriteLine("------------------------------------");

                // Choices for different type of devices
                switch (type)
                {
                    case "1":

                        // Prompt user to enter device information
                        Console.Write("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);

                        computer.setComputerInfo();

                        // Use methods to show entered values
                        computer.ShowPurchaseInfo();
                        computer.ShowBasicTechnicalInfo();
                        computer.saveToDb();

                        break;

                    case "2":
                        Console.Write("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        break;

                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;
                }

                Console.WriteLine("Haluatko jatkaa k/e?");
                string response = Console.ReadLine();
                if (response == "e")
                {
                    Computer computer = new Computer();
                    computer.getComputersFromDb();

                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
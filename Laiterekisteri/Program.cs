using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laiterekisteri
{
    //------------------------------------
    internal class Device
    {
        private string name = "Uusi laite";

        public string Name
        { get { return name; } set { name = value; } }

        private string purchaseDate = "01.01.2024";

        public string PurchaseDate
        { get { return purchaseDate; } set { purchaseDate = value; } }

        private double price = 10.00;

        public double Price
        { get { return price; } set { price = value; } }

        private int warranty = 10;

        public int Warranty
        { get { return warranty; } set { warranty = value; } }

        private string processorType = "N/A";

        public string ProcessorType
        { get { return processorType; } set { processorType = value; } }

        private int amountRAM = 0;

        public int AmountRAM
        { get { return amountRAM; } set { amountRAM = value; } }

        private int storageCapacity = 0;

        public int StorageCapacity
        { get { return storageCapacity; } set { storageCapacity = value; } }

        //--------------------

        public Device()
        {
        }

        public Device(string name)
        {
            this.name = name;
        }

        public Device(string purchaseDate, double price, int warranty)
        {
            this.purchaseDate = purchaseDate;
            this.price = price;
            this.warranty = warranty;
        }

        //--------------------

        public void ShowPurchaseInfo()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Laitteen nimi: " + Name);
            Console.WriteLine("Ostopäivä: " + PurchaseDate);
            Console.WriteLine("Hinta: " + Price);
            Console.WriteLine("Takuu: " + Warranty + " kk");
            Console.WriteLine();
        }

        public void SetPurchaseInfo()
        {
            Console.WriteLine("Ostopäivä: ");
            PurchaseDate = Console.ReadLine();

            Console.WriteLine("Hinta: ");
            try
            {
                Price = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virheellinen hintatieto" + ex.Message);
            }

            Console.WriteLine("Takuu kk: ");
            Warranty = int.Parse(Console.ReadLine());
        }

        public void ShowBasicTechnicalInfo()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Koneen nimi: " + Name);
            Console.WriteLine("Prosessori: " + ProcessorType);
            Console.WriteLine("Keskusmuistin määrä: " + AmountRAM);
            Console.WriteLine("Levytila: " + StorageCapacity);
            Console.WriteLine();
        }

        public void SetTechnicalInfo()
        {
            Console.Write("Anna koneen Keskusmuistin määrä: ");
            AmountRAM = int.Parse(Console.ReadLine());

            Console.Write("Anna koneen prosessorityyppi: ");
            ProcessorType = Console.ReadLine();

            Console.Write("Anna koneen levytila: ");
            StorageCapacity = int.Parse(Console.ReadLine());
        }
    }

    //------------------------------------
    internal class Computer : Device
    {
        public Computer() : base()
        {
        }

        public Computer(string name) : base(name)
        {
        }
    }

    //------------------------------------
    internal class Phone : Device
    {
    }

    //------------------------------------
    internal class Tablet : Device
    {
        private string operatingSystem;

        public string OperatingSystem
        { get { return operatingSystem; } set { operatingSystem = value; } }

        private string inputMethod;

        public string InputMethod
        { get { return inputMethod; } set { inputMethod = value; } }

        private bool stylusEnabled = false;

        public bool StylusEnabled
        { get { return stylusEnabled; } set { stylusEnabled = value; } }

        //--------------------

        public Tablet() : base()
        {
        }

        public Tablet(string name) : base(name)
        {
        }

        //--------------------

        public void ShowTabletInfo()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Käyttöliittymä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
            Console.WriteLine();
        }

        public void SetTabletInfo()
        {
            Console.Write("Anna tabletin käyttöliittymä: ");
            OperatingSystem = Console.ReadLine();

            Console.Write("Anna tabletin syöttötapa: ");
            InputMethod = Console.ReadLine();

            Console.Write("Toimiiko tabletti kynällä? kyllä/ei ");
            string stylusAnswer = Console.ReadLine();
            if (stylusAnswer == "kyllä")
            {
                StylusEnabled = true;
            }
            else if (stylusAnswer == "ei")
            {
                StylusEnabled = false;
            }
        }
    }

    //------------------------------------
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Minkä laitteen tiedot tallennetaan?");
                Console.Write("1 Tietokone, 2 tabletti: ");
                string type = Console.ReadLine();

                switch (type)
                {
                    case "1":
                        Console.Write("Nimi: ");
                        Computer computer = new Computer(Console.ReadLine());
                        computer.SetTechnicalInfo();
                        computer.ShowBasicTechnicalInfo();
                        computer.SetPurchaseInfo();
                        break;

                    case "2":
                        Console.Write("Nimi: ");

                        Tablet tablet = new Tablet(Console.ReadLine());
                        tablet.SetTabletInfo();
                        tablet.ShowTabletInfo();
                        tablet.SetPurchaseInfo();
                        break;

                    default:
                        Console.WriteLine("Valitse joko 1 tai 2");
                        break;
                }

                Console.WriteLine("Haluatko jatkaa? K/e");
                string continueAnswer = Console.ReadLine().Trim().ToLower();

                if (continueAnswer == "e")
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
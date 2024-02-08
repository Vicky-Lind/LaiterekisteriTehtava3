using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laiterekisteri
{
    internal class Device
    {
        public string boughtDate = "01.01.2024";
        public double boughtPrice = 10.00;
        public int warrantyMonths = 10;

        public Device()
        {
        }

        public Device(string boughtDate, double boughtPrice, int warrantyMonths)
        {
            this.boughtDate = boughtDate;
            this.boughtPrice = boughtPrice;
            this.warrantyMonths = warrantyMonths;
        }

        public void SayOpinion()
        {
            Console.WriteLine("This is the main device category");
            Console.WriteLine(boughtDate, boughtPrice, warrantyMonths);
        }
    }

    internal class Computer : Device
    {
        public string size;

        public Computer(string size)
        {
            this.size = size;
        }

        public new void SayOpinion()
        {
            Console.WriteLine("This is the computer category");
            Console.WriteLine(size);
        }
    }

    internal class Phone : Device
    {
    }

    internal class Tablet : Device
    {
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Device device = new Device("08.02.2024", 160.00, 12);
            device.SayOpinion();

            Computer computer = new Computer("16inch");

            computer.boughtPrice = 180.60;

            Console.ReadLine();
        }
    }
}
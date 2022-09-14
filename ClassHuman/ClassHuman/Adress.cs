using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    public class Adress
    {
        private string _country;
        private string _city;
        private string _street;
        private int _house;

        public Adress()
        {
            this._country = "Ukraine";
            this._city = "Kherson";
            this._street = "Perekopskaya";
            this._house = 6;
        }

        public Adress(string country, string city, string street, int house)
        {
            this._country = country;
            this._city = city;
            this._street = street;
            this._house = house;
        }

        public string toString()
        {
            return
                "Country: " + this._country + "\n" +
                "City: " + this._city + "\n" +
                "Street: " + this._street + "\n" +
                "House: " + this._house.ToString();
        }
        public Adress inputadress()
        {
            string country;
            while (true)
            {
                Console.WriteLine("Country: ");
                country = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(country)) break;
                else Console.WriteLine("Вы не ввели страну!");
            }
            string city;
            while (true)
            {
                Console.WriteLine("City: ");
                city = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(city)) break;
                else Console.WriteLine("Вы не ввели город!");
            }
            string street;
            while (true)
            {
                Console.WriteLine("Street: ");
                street = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(street)) break;
                else Console.WriteLine("Вы не ввели улицу!");
            }
            int house;
            while (true)
            {
                try
                {
                    Console.WriteLine("House: ");
                    house = int.Parse(Console.ReadLine());
                    if (house > 0) break;
                    else Console.WriteLine("Номер дома не может быть отридцательным!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели номер лома!");
                }
            }
            Adress adress = new Adress(country, city, street, house);
            return adress;
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public int House
        {
            get { return _house; }
            set { _house = value; }
        }
    }
}

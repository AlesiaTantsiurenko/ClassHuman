using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    [Serializable]
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

        public string toString() =>
                "Country: " + this._country + "\n" +
                "City: " + this._city + "\n" +
                "Street: " + this._street + "\n" +
                "House: " + this._house.ToString();
        public bool IsNotEmpty(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            else return true;
        }
        public bool IsValidNumber(int number)
        {
            if (number > 0) return true;
            else return false;

        }
        public Adress inputadress()
        {
            string country;
            while (true)
            {
                Console.WriteLine("Country: ");
                country = Console.ReadLine();
                if (IsNotEmpty(country)) break;
                else Console.WriteLine("Вы не ввели страну!");
            }
            string city;
            while (true)
            {
                Console.WriteLine("City: ");
                city = Console.ReadLine();
                if (IsNotEmpty(city)) break;
                else Console.WriteLine("Вы не ввели город!");
            }
            string street;
            while (true)
            {
                Console.WriteLine("Street: ");
                street = Console.ReadLine();
                if (IsNotEmpty(street)) break;
                else Console.WriteLine("Вы не ввели улицу!");
            }
            int house;
            while (true)
            {
                    Console.WriteLine("House: ");
                    string ho = Console.ReadLine();
                if (IsNotEmpty(ho) && IsValidNumber(int.Parse(ho)))
                {
                    house = int.Parse(ho);
                    break;
                }
                else Console.WriteLine("Номер дома не может быть отридцательным или пустым!");
            }
            Adress adress = new Adress(country, city, street, house);
            return adress;
        }
        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string Street
        {
            get => _street;
            set => _street = value;
        }

        public int House
        {
            get => _house;
            set => _house = value;
        }
    }
}

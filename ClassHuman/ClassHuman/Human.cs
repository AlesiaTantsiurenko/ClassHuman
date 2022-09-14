using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    public enum Nation { Ukranian, French, Polish };
    public class Human
    {
        protected string _name;
        protected string _surname;
        protected int _age;
        protected double _height;
        protected double _weight;
        protected bool _habbits;
        protected string _email;
        protected Nation _nation;
        protected Adress _adress;


        public Human()
        {
            this._name = "Alesia";
            this._surname = "Tantsiurenko";
            this._age = 18;
            this._height = 1.84;
            this._weight = 60;
            this._habbits = false;
            this._email = "alesiatantsiurenko@gmail.com";
            this._nation = Nation.Ukranian;
            this._adress = new Adress();
        }
        public Human(string name, string surname, int age, double height, double weight, bool habbits, string email, Nation nation, Adress adress)
        {
            this._name = name;
            this._surname = surname;
            this._age = age;
            this._height = height;
            this._weight = weight;
            this._habbits = habbits;
            this._email = email;
            this._nation = nation;
            this._adress = adress;
        }
        public static Human operator +(Human one, Human two)
        {
            Human result = new Human();
            result._age = one._age + two._age;
            result._habbits = one._habbits && two._habbits;
            return result;
        }
        public static bool operator >(Human one, Human two)
        {
            bool result = one._age > two._age;
            return result;
        }
        public static bool operator <(Human one, Human two)
        {
            bool result = one._age < two._age;
            return result;
        }
        public virtual void printInfo()
        {
            string data =
                "Name: " + this._name + "\n" +
                "Surname: " + this._surname + "\n" +
                "Age: " + this._age.ToString() + "\n" +
                "Height: " + this._height.ToString() + "\n" +
                "Weight: " + this._weight.ToString() + "\n" +
                "Is Habbits: " + this._habbits.ToString() + "\n" +
                "Email: " + this._email + "\n" +
                "Nation: " + this._nation.ToString() + "\n" +
                "Adress: " + this._adress.toString();
            Console.WriteLine(data);
        }
        public string toStr()
        {
            string str;
            str = "Name: " + this._name + "\n" +
                "Surname: " + this._surname + "\n" +
                "Age: " + this._age.ToString() + "\n" +
                "Height: " + this._height.ToString() + "\n" +
                "Weight: " + this._weight.ToString() + "\n" +
                "Is Habbits: " + this._habbits.ToString() + "\n" +
                "Email: " + this._email + "\n" +
                "Nation: " + this._nation.ToString() + "\n" +
                "Adress: " + this._adress.toString();
            return str;
        }
        public virtual  void inputInfo(/*listHuman list*/)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Habbits: ");
            bool habbits = bool.Parse(Console.ReadLine());
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Nation: ");
            //Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            Adress adr = new Adress();
            //Human n = new Human(name, surname, age, height, weight, habbits,email, nation, adr.inputadress());
            //list.add(n);
        }
        
public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool Habbits
        {
            get { return _habbits; }
            set { _habbits = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public Nation Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        public Adress Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    class Student : Human
    {
        private int group;
        private int money;

        public Student() : base()
        {

        }
        public Student(string name, string surname, int age, double height,
            double weight, bool habbits, Nation nation, Adress adress, int group, int money) : base(name, surname,
                age, height, weight, habbits, nation, adress)
        {
            this.group = group;
            this.money = money;
        }
        public override void printInfo()
        {
            string data =
               "Name: " + this._name + "\n" +
               "Surname: " + this._surname + "\n" +
               "Age: " + this._age.ToString() + "\n" +
               "Height: " + this._height.ToString() + "\n" +
               "Weight: " + this._weight.ToString() + "\n" +
               "Is Habbits: " + this._habbits.ToString() + "\n" +
               "Nation: " + this._nation.ToString() + "\n" +
               "Adress: " + this._adress.toString() + "\n" +
               "Group: " + this.group.ToString() + "\n" +
               "Money: " + this.money.ToString();
            Console.WriteLine(data);

        }

        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}

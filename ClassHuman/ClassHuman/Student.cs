using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    public enum Key { csharp, python, java, JS }
     [Serializable]
     public class Student : Human
    {
        private int group;
        private int money;
        private Key key;

        public Student() : base()
        {

        }
        public Student(string name, string surname, int age, double height,
            double weight, bool habbits, string email, Nation nation, Adress adress, int group, int money, Key key) : base(name, surname,
                age, height, weight, habbits, email, nation, adress)
        {
            this.group = group;
            this.money = money;
            this.key= key;
        }
        public override void printInfo()
        {
            string data =
               base.toStr() + "\n" +
               "Group: " + this.group.ToString() + "\n" +
               "Money: " + this.money.ToString() + "\n" +
                "Key: " + this.key.ToString();
            Console.WriteLine(data);

        }

       
        public int Group
        {
            get => group;
            set => group = value;
        }
        public int Money
        {
            get => money;
            set => money = value;
        }
        public Key Key
        {
            get => key;
            set => key = value;

        }
    }
}

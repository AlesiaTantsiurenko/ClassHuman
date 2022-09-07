using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ClassHuman
{
    class Teacher : Human
    {
        private int salary;
        private string department;
        private List<Student> list;

        public Teacher() : base()
        {
            list = new List<Student>();
        }
        public Teacher(string name, string surname, int age, double height,
            double weight, bool habbits, Nation nation, Adress adress, int salary, string department) : base(name, surname,
                age, height, weight, habbits, nation, adress)
        {
            this.salary = salary;
            this.department = department;
            this.list = new List<Student>();
        }
        public void add(Student human)
        {
            list.Add(human);
        }
        public void show()
        {
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();
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
               "Salary: " + this.salary.ToString() + "\n" +
               "Money: " + this.department;
            Console.WriteLine(data);

        }

        public void write_to_json()
        {
            //File.WriteAllText("input.json", string.Empty);


            for (int i = 0; i < list.Count(); i++)
                File.AppendAllText("input.json", JsonConvert.SerializeObject(list[i],
              new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii }));

        }
        public void read_from_file()
        {
            list.Clear();
            JsonTextReader reader = new JsonTextReader(new StreamReader("input.json"));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                JsonSerializer serializer = new JsonSerializer();
                Student l = serializer.Deserialize<Student>(reader);

                list.Add(l);
            }

        }
        public void findName(string str)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if (list[n].Name == str)
                    list[n].printInfo();
                else
                    Console.WriteLine("Объекта с такими инициалами нету в списке!");
            }

        }
        public void find_change_name(string fName, string lName)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if (list[n].Name == fName)
                {
                    list[n].Name = lName;
                    list[n].printInfo();
                }
            }

        }
        public void find_change_surname(string fSurname, string lSurname)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if (list[n].Surname == fSurname)
                {
                    list[n].Surname = lSurname;
                    list[n].printInfo();
                }
                else
                    Console.WriteLine("Объекта с такими инициалами нету в списке!");
            }
        }
        public void find_change_age(string name, string surname, int age)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if ((list[n].Name == name) && (list[n].Surname == surname))
                {
                    list[n].Age = age;
                    list[n].printInfo();
                }
                else
                    Console.WriteLine("Объекта с такими инициалами нету в списке!");
            }
        }
        public void remove(string name, string surname)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if ((list[n].Name == name) && (list[n].Surname == surname))
                    list.RemoveAt(n);
            }
            Console.WriteLine("Удаление прошло успешно!");
        }

        public void sort_surname()
        {
            Student reserv = new Student();
            for (int j = 1; j < list.Count(); j++)
                for (int i = 0; i < list.Count() - 1; i++)
                    if (list[i].Surname[0] > list[i + 1].Surname[0])
                    {
                        reserv = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = reserv;
                    }
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();

        }
        public void sort_age()
        {
            Student reserv = new Student();
            for (int j = 1; j < list.Count(); j++)
                for (int i = 0; i < list.Count() - 1; i++)
                    if (list[i].Age > list[i + 1].Age)
                    {
                        reserv = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = reserv;
                    }
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();

        }
        public void inputInfo()
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
            Console.WriteLine("Nation: ");
            //Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            Adress adr = new Adress();
            Console.WriteLine("Group: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine("Money: ");
            int money = int.Parse(Console.ReadLine());
            Student n = new Student(name, surname, age, height, weight, habbits, nation, adr.inputadress(), group, money);
            add(n);
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public List<Student> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}

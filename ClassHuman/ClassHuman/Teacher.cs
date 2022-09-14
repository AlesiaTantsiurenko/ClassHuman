using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ClassHuman
{
   public enum KeyWords {csharp, python, java, JS}
   public  class Teacher : Human
    {
        private int salary;
        private string department;
        private int numofseats;
        private KeyWords keywords;
        private List<Student> list;

        public Teacher() : base()
        {
            list = new List<Student>();
        }
        public Teacher(string name, string surname, int age, double height,
            double weight, bool habbits,string email, Nation nation, Adress adress, int salary, string department, int numofseats, KeyWords keywords) : base(name, surname,
                age, height, weight, habbits,email, nation, adress)
        {
            this.salary = salary;
            this.department = department;
            this.numofseats = numofseats;
            this.keywords = keywords;
            this.list = new List<Student>();
        }
        public void add(Student student)
        {
            if (check_numofset(student.Key.ToString()))
                list.Add(student);
            else
            {
                Console.WriteLine("Мест нет либо интересы не совпадают!");
            }
        }
        public void show()
        {
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();
        }
        public override void printInfo() 
        {
            string data =
               base.toStr() + "\n" +
               "Salary: " + this.salary.ToString() + "\n" +
               "Money: " + this.department + "\n" +
                "Number of set: " + this.numofseats.ToString() + "\n" +
                "Key: " + this.keywords.ToString();
            Console.WriteLine(data);

        }
        public void SerializelistStudent()
        {

            /*XmlSerializer x = new XmlSerializer(typeof(Student));
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, list);*/
            using (FileStream fs = new FileStream("Student.txt",
                   FileMode.Create, FileAccess.Write))
            {
                XmlSerializer bf = new XmlSerializer(typeof(List<Student>)); // тип для сериализации List объектов Student
                bf.Serialize(fs, list);
                fs.Close();

                list.Clear();
            }
        }
        public void DeserializelistStudent()
        {
            using (FileStream fs = new FileStream("Student.txt",
                    FileMode.Open, FileAccess.Read))
            {
                XmlSerializer bf = new XmlSerializer(typeof(List<Student>)); // тип для сериализации List объектов FLY
                list = bf.Deserialize(fs) as List<Student>;
                foreach (Student obj in list)
                    obj.printInfo();
                fs.Close();
            }
        }
        public void write_to_json()
        {
            //File.WriteAllText("input.json", string.Empty);


            for (int i = 0; i < list.Count(); i++)
                File.AppendAllText("Student.json", JsonConvert.SerializeObject(list[i],
              new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii }));

        }
        public void read_from_file()
        {
            list.Clear();
            JsonTextReader reader = new JsonTextReader(new StreamReader("Student.json"));
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
        public bool check_numofset(string key)
        {
            bool flag = false;
            if ((list.Count < numofseats)&&(key == keywords.ToString()))
                flag = true;
            else
            {
                flag = false;
            }
            return flag;
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
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

           /* try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
           */
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public override void inputInfo()
        {
            string name;
            while (true)
            {
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) break;
                else Console.WriteLine("Вы не ввели имя!");

            }
            string surname;
            while (true)
            {
                Console.WriteLine("Surname: ");
                surname = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(surname)) break;
                else Console.WriteLine("Вы не ввели фамилию!");

            }
            int age;
            while (true)
            {
                try
                {
                    Console.WriteLine("Age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age > 0) break;
                    else Console.WriteLine("Возраст не может быть отридцательныи!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели возраст!");
                }
            }
            double height;
            while (true)
            {
                try
                {
                    Console.WriteLine("Height: ");
                    height = double.Parse(Console.ReadLine());
                    if (height > 0) break;
                    else Console.WriteLine("Рост не может быть отридцательныи!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели рост!");
                }
            }
            double weight;
            while (true)
            {
                try
                {
                    Console.WriteLine("Weight: ");
                    weight = double.Parse(Console.ReadLine());
                    if (weight > 0) break;
                    else Console.WriteLine("Вес не может быть отридцательныи!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели вес!");
                }
            }
            bool habbits;
            while (true)
            {
                try
                {
                    Console.WriteLine("Habbits: ");
                    habbits = bool.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Вы не ввели привычку либо введенное значение не соответствет нужному типу!");
                }
            }
            string email;
            while (true)
            {
                Console.WriteLine("Email: ");
                email = Console.ReadLine();
                if (IsValidEmail(email)) break;
                else Console.WriteLine("Неверный email!");
            }
            Nation nation;
            while (true)
            {
                try
                {
                    Console.WriteLine("Nation: ");
                    //Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
                    nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
                    break;
                }
                catch
                {
                    Console.WriteLine("Введенной нации либо нету в списке либо ви ничего не ввели!");
                }
            }
            Adress adr = new Adress();
            int group;
            while (true)
            {
                try
                {
                    Console.WriteLine("Group: ");
                    group = int.Parse(Console.ReadLine());
                    if(group>0) break;
                    else Console.WriteLine("Номер группы не может быть отридцательным!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели номер группы!");
                }
            }
            int money;
            while (true)
            {
                try
                {
                    Console.WriteLine("Money: ");
                    money = int.Parse(Console.ReadLine());
                    if (money > 0) break;
                    else Console.WriteLine("Размер стипендии не может быть отридцательным!");
                }
                catch
                {
                    Console.WriteLine("Вы не ввели размер стипендии!");
                }
            }
            Key key;
            while (true)
            {
                try
                {
                    Console.WriteLine("Keywords: ");
                    key = (Key)Enum.Parse(typeof(Key), Console.ReadLine(), true);
                    break;
                }
                catch
                {
                    Console.WriteLine("Введенного языка либо нету в списке либо ви ничего не ввели!");
                }
            }
            Student n = new Student(name, surname, age, height, weight, habbits, email, nation, adr.inputadress(), group, money, key);
            
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
        public int NumOfSeats
        {
            get { return numofseats;}
            set { numofseats = value; }
        }
        public KeyWords KeyWords
        {
            get { return keywords; }
            set { keywords = value; }
        }
        public List<Student> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}

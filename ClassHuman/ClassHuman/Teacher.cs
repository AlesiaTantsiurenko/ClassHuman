using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;


namespace ClassHuman
{
    
    public enum KeyWords {csharp, python, java, JS}

   [Serializable]
   public class Teacher : Human
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
                toStr() + "\n" +
               "Salary: " + this.salary.ToString() + "\n" +
               "Money: " + this.department + "\n" +
                "Number of set: " + this.numofseats.ToString() + "\n" +
                "Key: " + this.keywords.ToString();
            Console.WriteLine(data);

        }
        public void Ser()
        {
            SoapFormatter formatter = new SoapFormatter();

            // создаем поток (soap файл)
            FileStream fs = new FileStream("Student.soap", FileMode.OpenOrCreate);
            try
            {
              
                foreach (Student obj in list)
                    formatter.Serialize(fs, obj);
                Console.WriteLine("Запись в soap файл прошла успешно😉!");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

        }
        public void Des()
        {
            string path = "Student.soap";
            if (File.Exists(path))
            {
                //SoapFormatter formatter = new SoapFormatter();
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                List<Student> liststudent = new List<Student>();
                try
                {

                    /*while (fs.Position < fs.Length)
                     {
                         liststudent.Add((Student)formatter.Deserialize(fs));

                     }*/
                    SoapFormatter formatter = new SoapFormatter();

                    // Deserialize the hashtable from the file and
                    // assign the reference to the local variable.
                    for (int i = 0;i < list.Count(); i++){
                        Student s = (Student)formatter.Deserialize(fs);
                        liststudent.Add(s); 
                    }

                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
                for (int n = 0; n < liststudent.Count(); n++)
                    liststudent[n].printInfo();
            }
            else Console.WriteLine($"Файла с именем {path} не существует!");
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
                Console.WriteLine("Запись в txt файл прошла успешно😉!");
            }
        }
        public void DeserializelistStudent()
        {
            string path = "Student.txt";
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path,
                        FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer bf = new XmlSerializer(typeof(List<Student>)); // тип для сериализации List объектов FLY
                    list = bf.Deserialize(fs) as List<Student>;
                    foreach (Student obj in list)
                        obj.printInfo();
                    fs.Close();
                }
            }
            else Console.WriteLine($"Файла с именем {path} не существует!");

        }
        public void write_to_json()
        {
            //File.WriteAllText("input.json", string.Empty);


            for (int i = 0; i < list.Count(); i++)
                File.AppendAllText("Student.json", JsonConvert.SerializeObject(list[i],
              new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii }));
            Console.WriteLine("Запись в json файл прошла успешно😉!");
        }
        public void read_from_file()
        {
            string path = "Student.json";
            if (File.Exists(path))
            {
                list.Clear();
                JsonTextReader reader = new JsonTextReader(new StreamReader(path));
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
                foreach (Student obj in list)
                    obj.printInfo();
                reader.Close();
            }
            else Console.WriteLine($"Файла с именем {path} не существует!");

        }
       
        public void findName(string str)
        {
           
            if (list.Exists(obg => obg.Name == str)) list.Find(obg => obg.Name == str).printInfo();
            else Console.WriteLine($"Объекта с именем {str} не существует в списке.");

        }
        public void find_change_name(string fName, string lName)
        {
            if (list.Exists(obg => obg.Name == fName))
            {
                var st = list.Find(obg => obg.Name == fName);
                st.Name = lName;
                st.printInfo();
            }
            else Console.WriteLine($"Объекта с именем {fName} не существует в списке.");

        }
        public void find_change_surname(string fSurname, string lSurname)
        {
            if(list.Exists(obg => obg.Surname == fSurname))
            {
                var st = list.Find(obg => obg.Surname == fSurname);
                st.Surname = Surname;
                st.printInfo();
            }
            else Console.WriteLine($"Объекта с именем {fSurname} не существует в списке.");
        
        }
        public void find_change_age(string name, string surname, int age)
        {
            if(list.Exists(obg => (obg.Name == name)&&(obg.Surname == surname)))
            {
                var st = list.Find(obg => (obg.Name == name) && (obg.Surname == surname));
                st.Age = age;
                st.printInfo();
            }
            else Console.WriteLine($"Объекта с именем {name} и фамилией {surname} не существует в списке.");
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
            if (list.Exists(obg => (obg.Name == name) && (obg.Surname == surname)))
            {
                var st = list.Find(obg => (obg.Name == name) && (obg.Surname == surname));
                list.Remove(st);
                Console.WriteLine("Удаление прошло успешно!");
            }
            else Console.WriteLine($"Объекта с именем {name} и фамилией {surname} не существует в списке.");
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
            IsNotEmpty(email);
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
        public bool IsValidNumber_d(double number)
        {
            if (number > 0) return true;
            else return false;

        }
        public bool IsValidHabbits(string habbit)
        {
            string[] array = { "true", "false"};
            if (array.Contains(habbit)) return true;
            else return false;
        }
        public bool IsValidNation(string str)
        {
            List<string> termsList = new List<string>();
            foreach (string s in Enum.GetNames(typeof(Nation)))
            {
                termsList.Add(s);
            }
            if (termsList.Contains(str)) return true;
            else return false;
        }
        public bool IsValidKey(string str)
        {
            List<string> termsList = new List<string>();
            foreach (string s in Enum.GetNames(typeof(Key)))
            {
                termsList.Add(s);
            }
            if (termsList.Contains(str)) return true;
            else return false;
        }

        public  void inputInfo()
        {
            string name;
            while (true)
            {
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
                if (IsNotEmpty(name)) break;
                else Console.WriteLine("Вы не ввели имя!");

            }
            string surname;
            while (true)
            {
                Console.WriteLine("Surname: ");
                surname = Console.ReadLine();
                if (IsNotEmpty(surname)) break;
                else Console.WriteLine("Вы не ввели фамилию!");

            }
            int age;
            while (true)
            {
                    Console.WriteLine("Age: ");
                    string a = Console.ReadLine();
                if (IsNotEmpty(a) && IsValidNumber(int.Parse(a))){
                    age = int.Parse(a);
                    break; }
                else Console.WriteLine("Возраст не может быть отридцательным или пустым!");
                
            }
            double height;
            while (true)
            {
                    Console.WriteLine("Height: ");
                    string h = Console.ReadLine();
                    if (IsNotEmpty(h) && IsValidNumber_d(double.Parse(h))){
                        height = double.Parse(h);
                        break; }
                    else Console.WriteLine("Рост не может быть отридцательныи или пустым!");
               
            }
            double weight;
            while (true)
            {
                    Console.WriteLine("Weight: ");
                    string w = Console.ReadLine();
                    if (IsNotEmpty(w) && IsValidNumber_d(double.Parse(w))){
                        weight = double.Parse(w);
                        break; }
                    else Console.WriteLine("Вес не может быть отридцательныи или пустым!");
            }
            bool habbits;
            while (true)
            {
                    Console.WriteLine("Habbits: ");
                    string hab = Console.ReadLine();
                    if (IsNotEmpty(hab) && IsValidHabbits(hab))
                    {
                        habbits = bool.Parse(hab);
                        break;
                    }
                    else Console.WriteLine("Вы не ввели привычку либо введенное значение не соответствет нужному типу!");
                
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
                    Console.WriteLine("Nation: ");
                    //Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
                    string nat = Console.ReadLine();
                    if (IsNotEmpty(nat) && IsValidNation(nat))
                    {
                        nation = (Nation)Enum.Parse(typeof(Nation), nat, true);
                        break;
                    }
                    else Console.WriteLine("Введенной нации либо нету в списке либо ви ничего не ввели!"); 
            }
            Adress adr = new Adress();
            int group;
            while (true)
            {
                    Console.WriteLine("Group: ");
                    string gr = Console.ReadLine();
                if (IsNotEmpty(gr) && IsValidNumber(int.Parse(gr)))
                {
                    group = int.Parse(gr);
                    break;
                }
                else Console.WriteLine("Номер группы не может быть отридцательным или пустым!");
            }
            int money;
            while (true)
            {
                    Console.WriteLine("Money: ");
                    string m = Console.ReadLine();
                    if (IsNotEmpty(m) && IsValidNumber(int.Parse(m)))
                    {
                        money = int.Parse(m);
                        break;
                    }
                else Console.WriteLine("Размер стипендии не может быть отридцательным или пустым!");
            }
            Key key;
            while (true)
            {
                    Console.WriteLine("Keywords: ");
                    string ky = Console.ReadLine();
                    if (IsNotEmpty(ky) && IsValidKey(ky))
                    {
                        key = (Key)Enum.Parse(typeof(Key), ky, true);
                        break;
                    }
                else Console.WriteLine("Введенного языка либо нету в списке либо ви ничего не ввели!");
            }
            Student n = new Student(name, surname, age, height, weight, habbits, email, nation, adr.inputadress(), group, money, key);
            
            add(n);
        }
        public int Salary
        {
            get => salary;
            set => salary = value;
        }
        public string Department
        {
            get => department;
            set => department = value;
        }
        public int NumOfSeats
        {
            get => numofseats;
            set => numofseats = value;
        }
        public KeyWords KeyWords
        {
            get => keywords;
            set => keywords = value;
        }
        public List<Student> List
        {
            get => list;
            set => list = value;
        }
    }
}

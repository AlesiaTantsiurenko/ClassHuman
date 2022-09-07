using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> listHuman = new List<Human>();
            Adress add1 = new Adress("Ukraine", "Kherson", "Perekopskaya", 3);
            Human one = new Human("Alesia", "Tantsiurenko", 20, 1.84, 60, false, Nation.Ukranian, add1);
            Human two = new Human("Alex", "Anderson", 18, 1.84, 100, true, Nation.Polish, new Adress("Polish", "Jahj", "Thgg", 5));
            //Human zero = new Human();
            //zero.printInfo();
            listHuman list = new listHuman();
            list.add(one);
            list.add(two);

            listTeacher listTeacher = new listTeacher();
            Student st_one = new Student("Jane", "Ternova", 20, 1.78, 65, false, Nation.French, new Adress("France", "Paris", "Brovera", 7), 241, 5000);
            Student st_two = new Student("Olga", "Kring", 18, 1.80, 60, false, Nation.Ukranian, new Adress("France", "Paris", "Troleva", 10), 241, 5000);
            Student st_three = new Student("Rita", "Ora", 16, 1.75, 55, false, Nation.Ukranian, new Adress("France", "Paris", "Norgaeva", 8), 241, 5000);
            Teacher one_th = new Teacher("Viktoria", "Lavrova", 30, 1.83, 65, false, Nation.French, new Adress("France", "Paris", "Krasnova", 5), 30000, "FKNFM");
            one_th.add(st_one);
            one_th.add(st_two);
            one_th.add(st_three);
            //one_th.show();
            Teacher two_th = new Teacher("Jack", "Li", 25, 1.83, 80, false, Nation.French, new Adress("France", "Paris", "Grineva", 3), 30000, "FKNFM");
            listTeacher.add(one_th);
            listTeacher.add(two_th);
            

            //listTeacher.show();
            
            string choice = null;
            while (choice != "0")
            {
                Console.WriteLine("Выберите действие ");
                Console.WriteLine("0 - выйти с программы.");
                Console.WriteLine("1 - распечатать все объекты");
                Console.WriteLine("2 - найти объект по имени");
                Console.WriteLine("3 - сортировка объектов по возрасту и вывести информацию");
                Console.WriteLine("4 - сортировка объектов по фамилии и вывести информацию");
                Console.WriteLine("5 - создать новый объект и добавить в список");
                Console.WriteLine("6 - изменить значения поля объекта");
                Console.WriteLine("7 - удалить объект");
                Console.WriteLine("8 - записать список студентов в файл");
                Console.WriteLine("9 - прочитать файл со списом студентов");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("До свидания!");
                        break;
                    case "1":
                        one_th.show();
                        break;
                    case "2":
                        Console.WriteLine("Введите имя ");
                        string name = Console.ReadLine();
                        one_th.findName(name);
                        break;
                    case "3":
                        one_th.sort_age();
                        break;
                    case "4":
                        one_th.sort_surname();
                        break;
                    case "5":
                        one_th.inputInfo();
                        Console.WriteLine("Теперь наш список выглядит так: ");
                        one_th.show();
                        break;
                    case "6":
                        string c = null;
                        while (c != "0")
                        {
                            Console.WriteLine("Выберите действие ");
                            Console.WriteLine("0 - вернуться в главное меню.");
                            Console.WriteLine("1 - изменить имя");
                            Console.WriteLine("2 - изменить фамилию");
                            Console.WriteLine("3 - изменить возраст");
                            c = Console.ReadLine();
                            switch (c)
                            {
                                case "0":
                                    break;
                                case "1":
                                    Console.WriteLine("Введите имя объекта которое хотите изменить: ");
                                    string firstName = Console.ReadLine();
                                    Console.WriteLine("Введите имя на которое хотите изменить: ");
                                    string secondName = Console.ReadLine();
                                    one_th.find_change_name(firstName, secondName);
                                    break;
                                case "2":
                                    Console.WriteLine("Введите фамилию объекта которую хотите изменить: ");
                                    string firstSurname = Console.ReadLine();
                                    Console.WriteLine("Введите фамилию на которую хотите изменить: ");
                                    string secondSurname = Console.ReadLine();
                                    one_th.find_change_surname(firstSurname, secondSurname);
                                    break;
                                case "3":
                                    Console.WriteLine("Введите имя объекта чей возраст вы хотите изменить: ");
                                    string Name = Console.ReadLine();
                                    Console.WriteLine("Введите фамилию объекта чей возраст вы хотите изменить: ");
                                    string SurName = Console.ReadLine();
                                    Console.WriteLine("Введите возраст на который хотите изменить: ");
                                    int Age = int.Parse(Console.ReadLine());
                                    one_th.find_change_age(Name, SurName, Age);
                                    break;
                                default:
                                    Console.WriteLine("Вы ввели неверный номер!");
                                    break;
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("Введите имя объекта который хотите удалить: ");
                        string name_human = Console.ReadLine();
                        Console.WriteLine("Введите фамилию объекта который хотите удалить: ");
                        string surName = Console.ReadLine();
                        one_th.remove(name_human, surName);
                        break;
                    case "8":
                        one_th.write_to_json();
                        break;
                    case "9":
                        one_th.read_from_file();
                        one_th.show();
                        break;

                    default:
                        Console.WriteLine("Вы ввели неверный номер!");
                        break;

                }
            }
            Console.ReadLine();
        
    }
    }
}

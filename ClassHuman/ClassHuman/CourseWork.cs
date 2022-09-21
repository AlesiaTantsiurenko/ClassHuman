using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    public struct UDC
    {
        private int id;
        private string udc;
        public UDC(int id, string udc)
        {
            this.id = id;
            this.udc = udc;
        }
        public string printInfo()
        {
            return "Id: " + this.id.ToString() + "\n" + "Name: " + this.udc;
        }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Udc
        {
            get => udc;
            set => udc = value;
        }
    } 
    public class CourseWork
    {
        private string description;
        private string name;
        private DateTime date;
        private UDC udc;
        public CourseWork(string description, string name, DateTime date, UDC udc)
        {
            this.description = description;
            this.name = name;
            this.date = date;
            this.udc = udc;
        }

        public void printinfo()
        {
            string text = "Description: " + description + "\n" +
                 "Name: " + this.name + "\n" +
                 "Date: " + this.date + "\n" +
                 "UDC: " + this.udc;

            Console.WriteLine(text);
        }
        public string striginfo()=>
                 "Description: " + description + "\n" +
                 "Name: " + name + "\n" +
                 "Date: " + date + "\n" +
                 "UDC: " + this.udc;

        public string Description{
            get => description;
            set => description = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        public UDC Udc
        {
            get => udc;
            set => udc = value;
        }
    }
}

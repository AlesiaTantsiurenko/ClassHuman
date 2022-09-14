using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    class CourseWork
    {
        private string description;
        private string name;
        private DateTime date;
        public CourseWork(string description, string name, DateTime date)
        {
            this.description = description;
            this.name = name;
            this.date = date;
        }

        public void printinfo()
        {
            string text = "Description: " + description + "\n" +
                 "Name: " + name + "\n" +
                 "Date: " + date;
            Console.WriteLine(text);
        }
        public string strinfo()
        {
            return "Description: " + description + "\n" +
                 "Name: " + name + "\n" +
                 "Date: " + date;
        }

        public string Description{
            get { return description; }
            set { description = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}

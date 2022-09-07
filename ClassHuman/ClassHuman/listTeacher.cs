using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHuman
{
    class listTeacher
    {
        private List<Teacher> list;
        public listTeacher()
        {
            list = new List<Teacher>();
        }

        public void add(Teacher human)
        {
            list.Add(human);
        }
        public void show()
        {
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();
        }
        public List<Teacher> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}

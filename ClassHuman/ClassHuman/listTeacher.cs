using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections;

namespace ClassHuman
{
    
    public class listTeacher
       
    {
        private List<Teacher> listteacher;
        public listTeacher()
        {
            listteacher = new List<Teacher>();
        }

        public void add(Teacher human)
        {
            listteacher.Add(human);
        }
        public void show()
        {
            for (int n = 0; n < listteacher.Count(); n++)
                listteacher[n].printInfo();
        }
        
        public List<Teacher> List
        {
            get => listteacher;
            set => listteacher = value;
        }
    }
}

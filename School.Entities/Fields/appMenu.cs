using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields
{
    public class appMenu
    {
        public string studentMenu { get; set; }
        public string subjectMenu { get; set; }
        public string courseMenu { get; set; }
        public string resultMenu { get; set; }
        public menuRequest menuRequest { get; set; }

        public appMenu()
        {
            menuRequest = new menuRequest();
        }
    }
    public class menuRequest
    {
        public string name { get; set; }
    }
}

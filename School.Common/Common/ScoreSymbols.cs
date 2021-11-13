using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.Common
{
    public class ScoreSymbols
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        //[Required(ErrorMessage = "Score is Required")]
        //[Display(Name = "Score")]
        public int Score { get; set; }
        public int Rating { get; set; }

        public string getSymbol()
        {
            if (Rating == 100)
            {
                return "A++";
            }
            else if (Rating >= 90)
            {
                return "A+";
            }
            else if (Rating >= 80)
            {
                return "B";
            }
            else if (Rating >= 70)
            {
                return "C";
            }
            else if (Rating >= 60)
            {
                return "D";
            }
            else if (Rating >= 50)
            {
                return "E";
            }
            else
            {
                return "F";
            }
        }
    }
}

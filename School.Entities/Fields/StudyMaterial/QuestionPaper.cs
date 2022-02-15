using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields.StudyMaterial
{
    public class QuestionPaper
    {
        public int Id { get; set; }
        public string QuestionPaperCode { get; set; }
        public string QuestionPaperName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

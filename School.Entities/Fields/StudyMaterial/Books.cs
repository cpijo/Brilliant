using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Fields.StudyMaterial
{
    public class Books
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookId { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public int BookEdition { get; set; }
        public string AuthorId { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string BookType { get; set; }
        public Decimal Rating { get; set; }
        public string GradeId { get; set; }
        public string GradeName { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class Books_simple
    {
        public int Id { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}

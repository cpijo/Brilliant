using School.Entities.Fields.StudyMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.UI.ViewModels
{
    public class BooksViewModel
    {
        public Books Books { get; set; }
        public List<Books> BooksList { get; set; }

        public BooksViewModel()
        {
            Books = new Books();
            BooksList = new List<Books>();
        }
    }
}
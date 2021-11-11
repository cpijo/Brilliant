
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace School.Entities.Fields
{
    //I saw your missed calls (Incorrect)
    //I missed your calls   (correct)

    public class StudentParent
    {
        public string StudentParentId { get; set; }
        public string StudentId { get; set; }
        public string ParentId { get; set; }
    }

    public class Student: User
    {
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public Student()
        {        
        }
        public void getDefaults() {
            CreatedDate = DateTime.Today;
            CreatedDate = DateTime.Today;
            StudentId = Guid.NewGuid().ToString();
        }
    }
    public class Address
    {
        public string AddressId { get; set; }
        public string UserId { get; set; }
        public string StudentId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public string UnitNumber { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }


    /*
    public class StudentModel
    {
        public Student Student { get; set; }
        public Address Address { get; set; }
        public ClassOrCourse ClassOrCourse { get; set; }

        public Picture Picture { get; set; }
        public string RaceDropboxItem { get; set; }
        public SelectList RaceDropboxItemList { get; set; }

        public string GenderDropboxItem { get; set; }
        public SelectList GenderDropboxItemList { get; set; }

        public string LookingForDropboxItem { get; set; }
        public SelectList LookingForDropboxItemList { get; set; }

        public string LanguageDropboxItem { get; set; }
        public SelectList LanguageDropboxItemList { get; set; }

        public string CountryDropboxItem { get; set; }
        public SelectList CountryDropboxItemList { get; set; }

        public string ProvinceDropboxItem { get; set; }
        public SelectList ProvinceDropboxItemList { get; set; }

        public string SurbubDropboxItem { get; set; }
        public SelectList SurbubDropboxItemList { get; set; }

        public string bodySizeItem { get; set; }
        public SelectList bodySizeItemList { get; set; }

        public string UnkownItem { get; set; }
        public SelectList UnkownItemList { get; set; }

        public List<string> RaceList { get; set; }
        public List<string> GenderList { get; set; }
        public List<string> LanguageList { get; set; }
        public List<string> ProvinceList { get; set; }
    }
    */
}
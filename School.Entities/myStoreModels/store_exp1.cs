using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.myStoreModels
{
    public class UserLogin
    {
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }


    public class OrderDisplayViewModel
    {
        public Guid CustomerID { get; set; }

        [Display(Name = "Order Number")]
        public Guid OrderID { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "PO / Description")]
        public string Description { get; set; }
    }
    public class CustomerOrdersListViewModel
    {
        [Display(Name = "Customer Number")]
        public Guid CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Country")]
        public string CountryNameEnglish { get; set; }

        [Display(Name = "Region")]
        public string RegionNameEnglish { get; set; }

        //public List<OrderDisplayViewModel> Orders { get; set; }
    }

    public class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OrderID { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public virtual Customer Customer { get; set; }
    }

    public class Item
    {
    }

    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(3)]
        public string CountryIso3 { get; set; }

        [MaxLength(3)]
        public string RegionCode { get; set; }

        //public virtual Country Country { get; set; }

        //public virtual Region Region { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
    /*
    @media (min-width: 768px) {

    .form-inline .form-control {
      display: inline-block;
      width: auto;
      vertical-align: middle;
    }

    .my-form-inline
    {
        min-width: 0;
        width: 25px;
        color:red;
    }

    #sval {
  border: ridge #ccc;
  border-width: 6px;
}
#bival {
  border: solid red;
  border-width: 2px 10px;
}
#treval {
  border: dotted orange;
  border-width: 0.3em 0 9px;
}
#fourval {
  border: solid lightgreen;
  border-width: thin medium thick 1em;
}
p {
  width: auto;
  margin: 0.25em;
  padding: 0.25em;
}


    border-width: 1px 2em 0 4rem;
}
    */
}

using System.ComponentModel.DataAnnotations;

namespace WareHouse_Client.Models
{
    public class Product
    {
        [Display(Name ="ID")]
        public int ProductID { get; set; }

        [Display(Name ="Name")]
        public string ProductName { get; set; }

        [Display(Name = "Code")]
        public string ProductCode { get; set; }
    }
}
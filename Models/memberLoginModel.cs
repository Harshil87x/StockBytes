using System.ComponentModel.DataAnnotations;

namespace StockBytes.Models
{
    public class memberLoginModel
    {
        [Key]
        public int ID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
    }
}

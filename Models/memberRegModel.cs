using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockBytes.Models
{
    [Table("tbl_Registrations")]
    public class memberRegModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//showing the identitty
        public int ID { get; set; }


        [Required(ErrorMessage = "First Name Required")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "EmailID Required")]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string Confirmpwd { get; set; }

        [Required(ErrorMessage = "Contact Number required")]
        public int Contact_Number { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "DOB required")] // c
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Fee required")] // c

        public bool Watchlist { get; set; }
        public bool watchlist1 { get; set; }
        public bool watchlist2 { get; set; }
        public bool watchlist3 { get; set; }
        public bool watchlist4 { get; set; }
        public bool watchlist5 { get; set; }
        public bool watchlist6 { get; set; }
        public bool watchlist7 { get; set; }
        public bool watchlist8 { get; set; }
        public bool watchlist9 { get; set; }
        public bool watchlist10 { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.DAL
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Column(TypeName = "Varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "Varchar(100)")]
        [Required]
        public string UserName { get; set; }
        [Column(TypeName = "Varchar(25)")]
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string Contcat { get; set; }
        [Column(TypeName = "Varchar(10)")]
        [Required]
        public string Country { get; set; }
        [Column(TypeName = "Varchar(10)")]
        [Required]
        public string City { get; set; }
        [Column(TypeName = "Varchar(6)")]
        [Required]
        public string Gender { get; set; }
        [Column(TypeName = "Bit")]
        [Required]
        public bool Terms { get; set; }

        // Navigation properties
        //public  Countries Countries { get; set; }
        //public  Cities Cities { get; set; }

    }
}

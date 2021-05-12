using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.DAL
{
    public class Countries
    {
        [Key]
        [Column(TypeName = "Varchar(10)")]
        public string CountryId { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string CountryName { get; set; }

    }
}

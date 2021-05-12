using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.DAL
{
    public class Cities
    {
        [Key]
        [Column(TypeName = "Varchar(10)")]
        public string CityId { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string CityName { get; set; }
        [Column(TypeName = "Varchar(10)")]
        public string CountryId { get; set; }
        //  public virtual ICollection<Countries> Countries { get; set; }
    }
}

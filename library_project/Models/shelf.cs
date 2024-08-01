using library_project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace library_pr{
    public class shelf
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "גובה המדף")]
        public int Hight { get; set; }

        public List<book> books { get; set; }

        public Bookcase? bookcase { get; set; }

        [NotMapped]
        public int? bcid { get; set; }
    }
}

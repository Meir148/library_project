using library_pr;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_project.Models
{
    public class book
    {
        public book() { }


        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string Name { get; set; }

        [Display(Name = "קטגוריה")]
        public string Genre { get; set; }

        [Display(Name = "גובה הספר")]
        public int Hight { get; set; }

        [NotMapped]
        public int? bkid { get; set; }

        public shelf? Shelf { get; set; }

    }
}

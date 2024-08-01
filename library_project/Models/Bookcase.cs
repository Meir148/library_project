using library_pr;
using System;
using System.ComponentModel.DataAnnotations;


namespace library_project.Models
{
    public class Bookcase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם ארון הספרים")]
        public string Name { get; set; }

        public List<shelf> shelves { get; set; }
        

    }
}

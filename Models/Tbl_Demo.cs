using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
   
    public class Tbl_Demo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rollno { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DOB { get; set; }


        public string Mobile { get; set; }

        public string Gender { get; set; }
        public decimal Fee { get; set; }
        public string Dept { get; set; }
        public Boolean Status { get; set; }
    }
}

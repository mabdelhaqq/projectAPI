using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class StudentSubjectData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public StudentData Student { get; set; }
        public SubjectData Subject { get; set; }
    }
}

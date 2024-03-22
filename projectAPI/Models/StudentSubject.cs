using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projectAPI.Models
{
    public class StudentSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}

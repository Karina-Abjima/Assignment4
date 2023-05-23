using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentData.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        
        public string Name { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public long ContactNumber { get; set; }
        public int RollNo { get; set; }
    }
}

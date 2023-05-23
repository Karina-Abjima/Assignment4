using System;
using System.Collections.Generic;

namespace StudentData.Models
{
    public partial class StudentsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public long ContactNumber { get; set; }
        public int RollNo { get; set; }
    }
}

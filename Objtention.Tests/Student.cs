using System;

namespace Objtention.Tests
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CGPA { get; set; }
        public bool IsClubMember { get; set; }
        public decimal Funds { get; set; }
        public decimal? Loans { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

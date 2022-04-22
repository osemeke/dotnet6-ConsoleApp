using System;
using System.Collections.Generic;

namespace CoreConsoleApp.Entities
{
    public partial class CandidateWassce
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string? IndexNo { get; set; }
        public string CandidateName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Dob { get; set; } = null!;
        public int Disability { get; set; }
        public int NoOfAttempt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? OldData { get; set; }
        public string? NewData { get; set; }
    }
}

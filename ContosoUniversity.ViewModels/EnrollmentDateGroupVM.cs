using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.ViewModels
{
    public class EnrollmentDateGroupVM
    {
        public DateTime EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
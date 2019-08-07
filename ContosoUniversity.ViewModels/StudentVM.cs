using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.ViewModels
{
    public class StudentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentDate { get; set; }
    }
}
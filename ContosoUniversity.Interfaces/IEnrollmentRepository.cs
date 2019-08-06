using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Interfaces
{
    public interface IEnrollmentRepository
    {
        IEnumerable<EnrollmentDateGroup> GetLatestEnrollments(int count);
    }
}

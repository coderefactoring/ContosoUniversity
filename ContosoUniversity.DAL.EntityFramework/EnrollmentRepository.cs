using ContosoUniversity.Domain;
using ContosoUniversity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.DAL.EntityFramework
{
    public class EnrollmentRepository : Repository<EnrollmentDateGroup>, IEnrollmentRepository
    {
        SchoolContext SchoolContext { get { return Context as SchoolContext; } }
        public EnrollmentRepository(SchoolContext context) : base(context)
        {

        }
        public IEnumerable<EnrollmentDateGroup> GetEnrollments()
        {
            string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Person "
                + "WHERE Discriminator = 'Student' "
                + "GROUP BY EnrollmentDate";
            return SchoolContext.Database.SqlQuery<EnrollmentDateGroup>(query);
        }
    }
}

using ContosoUniversity.Domain;
using ContosoUniversity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.DAL.EntityFramework
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }
    }
}

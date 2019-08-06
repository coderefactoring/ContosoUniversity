using ContosoUniversity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SchoolContext _context;
        public IEnrollmentRepository Enrollments { get; private set; }
        public IStudentRepository Students { get; private set; }

        public UnitOfWork(SchoolContext context, IEnrollmentRepository enrollments, IStudentRepository students)
        {
            _context = context;
            Enrollments = enrollments;
            Students = students;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

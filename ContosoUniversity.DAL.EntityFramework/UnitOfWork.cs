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
        public IEnrollmentRepository EnrollmentRepository { get; private set; }

        public UnitOfWork(SchoolContext context, IEnrollmentRepository enrollmentRepository)
        {
            _context = context;
            EnrollmentRepository = enrollmentRepository;
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

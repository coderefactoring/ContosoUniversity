using AutoMapper;
using ContosoUniversity.Domain;
using ContosoUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Mapper
{
    public class EnrollmentDateGroupProfile : Profile
    {
        public EnrollmentDateGroupProfile()
        {
            CreateMap<Domain.EnrollmentDateGroup, ViewModels.EnrollmentDateGroupVM>();
        }
    }
}

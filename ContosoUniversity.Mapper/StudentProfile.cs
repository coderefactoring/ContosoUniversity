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
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Domain.Student, ViewModels.StudentVM>().
                ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstMidName)).
                ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName)).
                ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate.ToShortDateString()));
        }
    }
}

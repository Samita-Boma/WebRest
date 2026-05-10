using System;
using AutoMapper;

using WebRest.EF.Models;

namespace WebRestAPI.Code;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, Address>();
        CreateMap<Course, Course>();
        CreateMap<Employer, Employer>();
        CreateMap<Enrollment, Enrollment>();
        CreateMap<Grade, Grade>();
        CreateMap<GradeConversion, GradeConversion>();
        CreateMap<GradeType, GradeType>();
        CreateMap<GradeTypeWeight, GradeTypeWeight>();
        CreateMap<Instructor, Instructor>();
        CreateMap<InstructorAddress, InstructorAddress>();
        CreateMap<Location, Location>();
        CreateMap<Section, Section>();
        CreateMap<SectionLocation, SectionLocation>();
        CreateMap<Student, Student>();
        CreateMap<StudentAddress, StudentAddress>();
        CreateMap<StudentEmployer, StudentEmployer>();
        CreateMap<Zipcode, Zipcode>();
    }
}

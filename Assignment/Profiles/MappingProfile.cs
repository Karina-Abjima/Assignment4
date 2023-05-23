using AutoMapper;
using StudentData.Entities;
using StudentData.Models;


namespace StudentData.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentsDetail>();
            CreateMap<StudentsDetail, Student>();
        }
    }
}

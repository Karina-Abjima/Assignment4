using StudentData.Entities;
using StudentData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentData.Repository
{
    public interface IStudentRepo
    {
        Task< List<StudentsDetail> >GetAll();
        Task<StudentsDetail> GetByID(int id);
        Task<StudentsDetail> AddStudentAsync(StudentsDetail student);

        Task<StudentsDetail> DeleteStudentAsync(int id, IStudentRepo studentRepo);
        Task<StudentsDetail> UpdateDetail(int id, StudentsDetail student);
    }
}

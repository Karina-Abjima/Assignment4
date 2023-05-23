using Microsoft.EntityFrameworkCore;
using StudentData.Models;


namespace StudentData.Repository
{
    public class StudentRepo : IStudentRepo
    {

        private readonly StudentContext _context;

        public StudentRepo(StudentContext context)
        {
            _context = context;
        }

        public async Task<StudentsDetail> GetByID(int id)
        {
            var student = await _context.StudentsDetails.FindAsync(id);
            return student;
        }
        public async Task<StudentsDetail> AddStudentAsync(StudentsDetail student)
        {
            _context.StudentsDetails.Add(student);
            var s = await _context.SaveChangesAsync();
            return student;
        }

        public async Task<StudentsDetail> DeleteStudentAsync(int Id, IStudentRepo studentRepo)
        {
            var student = await studentRepo.GetByID(Id);
            if (student != null)
            {
                return student;
            }
            _context.StudentsDetails.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }


        public Task<StudentsDetail> UpdateDetail(int id, StudentsDetail student)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentsDetail>> GetAll()
        {
            return await _context.StudentsDetails.ToListAsync();
        }


    }
}
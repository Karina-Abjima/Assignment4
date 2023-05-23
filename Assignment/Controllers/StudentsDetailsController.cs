using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Models;
using StudentData.Repository;
using StudentData.Entities;

namespace StudentData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDetailsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentRepo _studentRepo;

        public StudentsDetailsController(StudentContext context, IMapper mapper, IStudentRepo studentRepo)
        {
            _context = context;
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        // GET: api/StudentsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDetail>>> GetStudentsDetails()
        {
            try
            {

                if (_context.StudentsDetails == null)
                    return NotFound();

                var studentdto = await _studentRepo.GetAll();
                //var studentdto = _context.StudentsDetails.ToListAsync();
                var studentdto1 = studentdto.Select(x => _mapper.Map<Student>(x));
                return Ok(studentdto1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/StudentsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsDetail>> GetStudentsDetail(int id)
        {
            try
            {
                if (_context.StudentsDetails == null)
                {

                    throw new ArgumentNullException(nameof(id));

                }
                var studentsDetail = _studentRepo.GetByID(id);

                if (studentsDetail == null)
                {
                    return NotFound();
                }
                var item = _mapper.Map<Student>(studentsDetail);
                return Ok(item);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT: api/StudentsDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsDetail(int id, StudentsDetail studentsDetail)
        {
            try
            {
                if (id != studentsDetail.Id)
                {

                    return BadRequest();
                }

                var updateStudent = await _studentRepo.UpdateDetail(id, studentsDetail);
                if (updateStudent == null)
                {
                    return NotFound();
                }
                var studentdetail1 = _mapper.Map<StudentsDetail>(updateStudent);
                return Ok(updateStudent);//finderror
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            /* catch (DbUpdateConcurrencyException)
             {
                 if (!StudentsDetailExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }*/



        }

        // POST: api/StudentsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDetail>> PostStudentsDetail(StudentsDetail studentsDetail)
        {
            if (_context.StudentsDetails == null)
            {
                return Problem("Entity set 'StudentContext.StudentsDetails'  is null.");
            }
            _context.StudentsDetails.Add(studentsDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsDetail", new { id = studentsDetail.Id }, studentsDetail);
        }

        // DELETE: api/StudentsDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDetail(int id)
        {
            try
            {
                if (_context.StudentsDetails == null)
                {
                    return NotFound();
                }
                var studentsDetail = await _context.StudentsDetails.FindAsync(id);
                if (studentsDetail == null)
                {
                    return NotFound();
                }

                _context.StudentsDetails.Remove(studentsDetail);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception Ex) { return BadRequest(Ex.Message); }
        }

        private bool StudentsDetailExists(int id)
        {
            return (_context.StudentsDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

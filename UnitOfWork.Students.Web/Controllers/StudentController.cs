using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UnitOfWork.Students.Domain.Entities;
using UnitOfWork.Students.Domain.Interfaces;

namespace UnitOfWork.Students.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var data = _unitOfWork.StudentRepository.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var data = _unitOfWork.StudentRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student doctor)
        {

            _unitOfWork.StudentRepository.Insert(doctor);
            _unitOfWork.Save();
            return CreatedAtRoute(nameof(GetStudentById), new { id = doctor.StudentId }, doctor);
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student doctor)
        {
            _unitOfWork.StudentRepository.Update(doctor);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            _unitOfWork.StudentRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}

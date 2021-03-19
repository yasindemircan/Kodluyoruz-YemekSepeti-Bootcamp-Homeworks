using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
    using Services.Interface;
    //using School.Models;
    
    namespace School.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StudentsController : ControllerBase
        {
            private readonly IStudentService _studentService;

            public StudentsController(IStudentService studentService)
            {
                _studentService = studentService;
            }
    
            [HttpGet]
            public async Task <ActionResult> GetStudents()
            {
                var Stundents = await _studentService.GetStudents();
                return Ok(Stundents);
            }
    
            [HttpGet("{id}")]
            public async Task <ActionResult> GetStudentById(int id)
            {
                var Student = await _studentService.GetStudent(id);
                if(Student == null)
                    return NotFound();
                return Ok(Student);
            }
    
            [HttpPost]
            public async Task <ActionResult> Post([FromBody] Student student)
            {
                var newStudent = await _studentService.AddStudent(student);
                return Ok(newStudent.FullName+" Added");
            }
    
            [HttpPut("{id}")]
            public async Task <IActionResult> Put(int id, [FromBody] Student student)
            {
                var Student = await _studentService.GetStudent(id);
                if(Student == null)
                    return NotFound();
                var Update = await _studentService.Update(student);
                return Ok(Update.FullName);
            }
    
            [HttpDelete("{id}")]
            public async Task <ActionResult> Delete(int id)
            {
                await _studentService.Delete(id);
                return Ok(id +"Silindi");
            }
        }
    }
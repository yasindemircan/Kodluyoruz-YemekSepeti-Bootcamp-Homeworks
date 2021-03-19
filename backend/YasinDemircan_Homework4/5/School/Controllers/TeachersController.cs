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
        public class TeachersController : ControllerBase
        {
            private readonly ITeacherService _teacherService;

            public TeachersController(ITeacherService teacherService)
            {
                _teacherService= teacherService;
            }
    
            [HttpGet]
            public async Task <ActionResult> GetTeachers()
            {
                var Teachers = await _teacherService.GetTeachers();
                return Ok(Teachers);
            }
    
            [HttpGet("{id}")]
            public async Task <ActionResult> GetTeacherById(int id)
            {
                //var Student = await _studentService.GetStudent(s => s.Id ==id);
                var teacher = await _teacherService.GetTeacher(id);
                if(teacher == null)
                    return NotFound();
                return Ok(teacher);
            }
    
            [HttpPost]
            public async Task <ActionResult> Post([FromBody] Teacher teacher)
            {
                var newTeacher = await _teacherService.AddTeacher(teacher);
                return Ok(newTeacher.FullName+" Added");
            }
    
            [HttpPut("{id}")]
            public async Task <IActionResult> Put(int id, [FromBody] Teacher teacher)
            {
                var Teacher = await _teacherService.GetTeacher(id);
                if(Teacher == null)
                    return NotFound();
                var Update = await _teacherService.Update(teacher);
                return Ok(Update.FullName);
            }
    
            [HttpDelete("{id}")]
            public async Task <ActionResult> Delete(int id)
            {
                await _teacherService.Delete(id);
                return Ok(id +"Silindi");
            }
        }
    }
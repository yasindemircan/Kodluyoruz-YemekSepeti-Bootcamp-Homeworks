using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Repositories.Interface;
using Domain.Entities;
using Domain.Response;
using Services.Interface;
using Services.MapExtensions;

namespace Services.Services
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<StudentResponse> AddStudent(Student entity)
        {
            var data = await _studentRepository.Add(entity);
            return data.toResponse();
            // return new StudentResponse{
            //     Id = data.Id,
            //     FullName = string.Concat(data.Name,data.LastName),
            //     Class = data.Class,
            //     SchoolNumber = data.SchoolNumber
            // };
        }

        public async Task<bool> Delete(int id)
        {
           return await _studentRepository.Delete(id);
        }

        public async Task<StudentResponse> GetStudent(int id){
            var result = await _studentRepository.GetById(id);
            if(result == null )
                return null;
           return result.toResponse();
        //    return new StudentResponse{
        //         Id =result.Id,
        //         FullName = string.Concat(result.Name,result.LastName),
        //         Class = result.Class,
        //         SchoolNumber = result.SchoolNumber
        //     };
        }

        public async Task<List<StudentResponse>> GetStudents()
        {
             var result = await _studentRepository.GetAll();
            return result.Select(c => c.toResponse()).ToList();
        }

        public async Task<StudentResponse> Update(Student entity)
        {
            var result = await _studentRepository.Update(entity); 
            return result.toResponse();
        }
    }
}

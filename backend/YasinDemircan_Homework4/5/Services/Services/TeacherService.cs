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

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        public async Task<TeacherResponse> AddTeacher(Teacher entity)
        {
            var data = await _teacherRepository.Add(entity);
            return data.toTeacherResponse();
        }

        public async Task<bool> Delete(int id)
        {
           return await _teacherRepository.Delete(id);
        }

        public async Task<TeacherResponse> GetTeacher(int id){
            var result = await _teacherRepository.GetById(id);
            if(result == null )
                return null;
           return result.toTeacherResponse();
        }

        public async Task<List<TeacherResponse>> GetTeachers()
        {
             var result = await _teacherRepository.GetAll();
            return result.Select(t =>t.toTeacherResponse()).ToList();
        }
        public async Task<TeacherResponse> Update(Teacher entity)
        {
            var result = await _teacherRepository.Update(entity); 
            return result.toTeacherResponse();
           
        }
    }
}

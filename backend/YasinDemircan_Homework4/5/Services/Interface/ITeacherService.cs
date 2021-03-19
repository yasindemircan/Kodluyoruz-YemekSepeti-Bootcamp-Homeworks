using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Response;

namespace Services.Interface
{
    public interface ITeacherService
    {
        Task<List<TeacherResponse>> GetTeachers();
         Task<TeacherResponse> GetTeacher(int id);
        Task<TeacherResponse> AddTeacher(Teacher entity);
       
        Task<TeacherResponse> Update(Teacher entity);

        Task<bool> Delete (int id);

    }
}

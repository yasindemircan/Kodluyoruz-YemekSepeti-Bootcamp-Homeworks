using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Response;

namespace Services.Interface
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetStudents();

         Task<StudentResponse> GetStudent(int id);
        Task<StudentResponse> AddStudent(Student entity);
        Task<StudentResponse> Update(Student entity);

        Task<bool> Delete (int id);

    }
}

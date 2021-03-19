using System;
using Domain.Entities;
using Domain.Response;

namespace Services.MapExtensions
{
    public static class TeacherExtensions
    {
         public static TeacherResponse toTeacherResponse(this Teacher teacher){
            return new TeacherResponse{
                Id = teacher.Id,
                FullName = string.Concat(teacher.Name, teacher.LastName),
                Phone = teacher.Phone
            };
    }
}
}

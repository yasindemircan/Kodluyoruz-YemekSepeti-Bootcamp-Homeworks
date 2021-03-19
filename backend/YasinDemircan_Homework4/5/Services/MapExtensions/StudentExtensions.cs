using System;
using System.Linq;
using Domain.Entities;
using Domain.Response;

namespace Services.MapExtensions
{
    public static class StudentExtensions
    {
         public static StudentResponse toResponse(this Student student){
            return new StudentResponse{
                Id = student.Id,
                FullName = string.Concat(student.Name, student.LastName),
                Class = student.Class,
                SchoolNumber = student.SchoolNumber
            };
        }
    }
}

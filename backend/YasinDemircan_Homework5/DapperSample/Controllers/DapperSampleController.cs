using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperSample.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperSample.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DapperSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult DapperInsert([FromBody] StudentModel studentModel)
        {

            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                db.Execute(@"INSERT INTO Student(Id,Name,LastName,SchoolNumber,Class) 
                            VALUES(@Id,@Name,@LastName,@SchoolNumber,@Class)", studentModel);
                // execute methodu ile request bodyden aldığımız değerleri db üzerine ekledik.
            }
            return Ok(studentModel);
        }

        [HttpGet("{ClassNumber}")]
        public IActionResult DapperSelect(int classNumber)
        {
            IEnumerable<StudentModel> student = new List<StudentModel>();
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();

                student = db.Query<StudentModel>($"SELECT * FROM Student Where Class = {classNumber}");
                // Query methodu ile sql sorgusu attık ve geriye dönen değeri student modele map ediyor.
            }
            return Ok(student);
        }
        [HttpPut]
        public IActionResult DapperUpdate([FromBody] StudentModel student)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();

                string sql = @"UPDATE Student Set Class = @Class
                                     WHERE Id = @Id";
                var paramsArray = new[]
                {
            new {Id =student.Id, Class = student.Class}
        };
                var affected = db.Execute(sql, paramsArray);
                // request bodyden gelen Id ve class bilgisiyle ögrencinin classını guncelliyorum
                // eger yaptıgım update işlmeinden etkilenen bir alan yoksa nocontent gönderiyorum.
                if (affected == 0)
                    return NoContent();
            }
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public ActionResult<StudentModel> DapperDelete(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                var sqlDelete = db.Execute(@"Delete From Student Where Id = @Id", new { Id = id });
                // Request bodyden alınan id ile tablomuz üzerinde silme işlemi yaptık
                if (sqlDelete == 0)
                    return NoContent();

            }
            return Ok(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> DapperSp()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))){
             if(db.State != ConnectionState.Open)
                db.Open();
             var procedure = "[Sales by Year]";
             var values = new{Beginning_Date = "2010.1.1", Ending_Date ="2010.12.30"};
             var result = db.Query(procedure,values,commandType: CommandType.StoredProcedure).ToList();
                //Stored procedure kullanılarak iki tarih arasındaki veriler result değikenine aldık eğer result.count 0 sa bulunamadı geri döndürdük.
             if(result.Count == 0)
                return NotFound();

            }
           
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult DapperTransactionalInsert([FromBody] StudentModel student){
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if(db.State != ConnectionState.Open)
                    db.Open();
                
                using(var transaction = db.BeginTransaction()){
                    var sql = @"Insert Into dbo.Student(Id,Name,LastName,SchoolNumber,Class)
                                    Values(@Id, @Name, @LastName, @SchoolNumber, @Class)";
                    
                    StudentModel student1 = new StudentModel(){
                        Id = student.Id,
                        Name = student.Name,
                        LastName = student.LastName,
                        SchoolNumber = student.SchoolNumber,
                        Class = student.Class
                    };
                    var result = db.Execute(sql,student1,transaction);
                    
                    sql = @"Insert Into dbo.Teacher(Id,Name,LastName,Phone)
                            Values(@Id,@Name,@LastName,@Phone)";
                    TeacherModel teacherModel = new TeacherModel(){
                        Id = 1,
                        Name="Ahmet",
                        LastName="x",
                        Phone=12345678
                    };
                    result = db.Execute(sql,teacherModel,transaction);
                    transaction.Commit();
                    // begin transaction blogu içerisinde student ve teacher tablolarına 
                    // sırayla veri ekliyoruz eğer commit kısmına gelmeden bir hata oluşursa 2 tabloyada veri eklenmiyor.
                }
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<StudentModel> DapperOneToOneMapping()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
               if(db.State != ConnectionState.Open)
                    db.Open();

                var sql = @"Select * From Student INNER JOIN Teacher ON Student.Id = Teacher.Id;";
                 var result = db.Query<StudentModel, TeacherModel, StudentModel>(
                     sql,(Student,Teacher) => {
                         return Student;
                     }
                 );
            return Ok(result);
            }
            // bir e bir ilişkili tabloyu bir modele bagladık.
        }


        [HttpGet]
        public ActionResult<StudentModel> DapperOneToMany()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if(db.State != ConnectionState.Open)
                    db.Open();
                var sql = @"Select TOP 10 * From Student Inner Join Teacher ON Student.Id = Teacher.Id;";
               var StudentDictionary = new Dictionary<int,StudentModel>();
               var list = db.Query<StudentModel,TeacherModel,StudentModel>(
                   sql,(student, teacher) =>{
                       StudentModel teacherEntry;
                       if(!StudentDictionary.TryGetValue(student.Id, out teacherEntry)){
                           teacherEntry = student;
                           teacherEntry.student = new List<TeacherModel>();
                           StudentDictionary.Add(teacherEntry.Id, teacherEntry);
                       }
                       teacherEntry.Student.Add(student);
                       return teacherEntry;
                   },
                   splitOn:"TeacherId")
                   .Distinct()
                   .ToList();
            if(list.Count == 0)
                return NoContent();
            return Ok(list);
            }
        }
        
        
    }
}

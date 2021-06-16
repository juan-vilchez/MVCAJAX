using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using API.Models;
using API.Repository;
using Domain;
using Service;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        StudentService Service;

        public StudentController()
        {
            Service = new StudentService();
        }
        // GET: Student
        [HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            List<Student> prodList = Service.Get();
            List<StudentModel> Students = new List<StudentModel>();
            foreach (var item in prodList)
            {
                Students.Add(mapObj.Translate(item));
            }
            return Json<List<StudentModel>>(Students);
        }
        [HttpGet]
        public JsonResult<StudentModel> GetStudents(int id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            Student dalStudent = Service.GetById(id);
            StudentModel Students = new StudentModel();
            Students = mapObj.Translate(dalStudent);
            return Json<StudentModel>(Students);
        }
        [HttpPost]
        public bool InsertStudents(StudentModel Student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
               EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student StudentObj = new Student();
                StudentObj = mapObj.Translate(Student);
                Service.Insert(StudentObj);
                status = true;
            }
            return status;
        }
        [HttpPut]
        public bool UpdateStudent(StudentModel Student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student StudentObj = new Student();
            StudentObj = mapObj.Translate(Student);
            Service.Update(StudentObj, StudentObj.studentID);
            status = true;
            return status;
        }
        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            bool status = false;
            Service.Delete(id);
            status = true;
            return status;
        }
    }
}
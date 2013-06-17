using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.DAL;

namespace Web.Controllers
{
    public class StudentController : ApiController
    {
        private EntitiesContext context;

        public StudentController()
        {
            this.context = new EntitiesContext();
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            Student student = this.context.Students.Find(id);

            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return student;
        }

[ActionName("name")]
public Student GetStudentByName(string param)
{
    Student student = this.context.Students.FirstOrDefault(x => x.Firstname == param);
    if (student == null)
    {
        throw new HttpResponseException(HttpStatusCode.NotFound);
    }

    return student;
}
            
        [HttpPost]
        public HttpResponseMessage Post(Student student)
        {
            if (string.IsNullOrEmpty(student.Firstname))
                throw new HttpException(500, "missing Student's name");

            try
            {
                this.context.Students.Add(student);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Student student)
        {
            Student s = this.context.Students.Find(id);
            if (s != null)
            {
                s.Firstname = student.Firstname;
                s.Lastname = student.Lastname;
                this.context.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Student student = this.context.Students.Find(id);
            if (student != null)
            {
                this.context.Students.Remove(student);
                this.context.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}

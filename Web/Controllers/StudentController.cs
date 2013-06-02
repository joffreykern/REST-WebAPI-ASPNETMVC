using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public List<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return this.context.Students.Find(id);
        }

        [HttpPost]
        public void Post(Student student)
        {
            this.context.Students.Add(student);
            this.context.SaveChanges();
        }

        [HttpPut]
        public void Put(int id, Student student)
        {
            Student s = this.context.Students.Find(id);
            if (s != null)
            {
                s.Firstname = student.Firstname;
                s.Lastname = student.Lastname;
                this.context.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Student student = this.context.Students.Find(id);
            if (student != null)
            {
                this.context.Students.Remove(student);
                this.context.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}

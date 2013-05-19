using System;
using System.Collections.Generic;
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

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}

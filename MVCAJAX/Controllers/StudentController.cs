using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain;
using MVCAJAX.Models;
using System.Web;
using System.Threading.Tasks;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        //private StudentService service = new StudentService();
        //get:Student

        public ActionResult IndexRazor()
        {
            /***var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Address = c.studentAddress,
                             Name = c.studentName
                         }).ToList();
            return View(model);**/
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return View(response.Result.listado);
        }
       
        public JsonResult getStudent(string id)
        {
            //return Json(service.Get(), JsonRequestBehavior.AllowGet);
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult createStudent(StudentModel std)
        {
            /**service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });**/

            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet});
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
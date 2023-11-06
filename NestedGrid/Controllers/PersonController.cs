using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NestedGrid.Controllers
{
    public class PersonController : Controller
    {
        jayaEntities db = new jayaEntities();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InlineEdit()
        {
            return View();
        }
        public JsonResult GetData()
        {
            var data = db.People.ToList();
    return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateData(Person  rowData)
        {
            try
            {
                var persondetails = db.People.Where(p => p.Id == rowData.Id).FirstOrDefault();
                persondetails.Name = rowData.Name;
                persondetails.Gender = rowData.Gender;
                persondetails.DOB = rowData.DOB;
                persondetails.Country = rowData.Country;
                db.Entry(persondetails).State = EntityState.Modified;
                int i = db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
               
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
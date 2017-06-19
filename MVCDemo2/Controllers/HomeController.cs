using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using System.Data;
using System.Data.Entity;

using System.Net;



namespace MVCDemo2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Exemplo de como carregar um combo
            Sample3Entities db = new Sample3Entities();
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Department department in db.Departments)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = department.Name,
                    Value = department.Id.ToString(),
                    Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
                };
                selectListItems.Add(selectListItem);
            }

            ViewBag.Departments = selectListItems;

            // Para montar o combo na View:
            //< p > @Html.DropDownList("Departments", "Select Department") </ p >
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index0()
        {
            Company company = new Company("Pragim");

            ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
            ViewBag.CompanyName = company.CompanyName;

            return View();
        }

        public ActionResult Index1()
        {
            Company company = new Company("Pragim");
            return View(company);
        }
    }


}

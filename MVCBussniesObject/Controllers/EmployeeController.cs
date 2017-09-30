using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCBussniesObject.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int? page)
        {
            int pagesize = 4;
            int pagenumber = (page ?? 1);
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.OrderBy(s => s.Name).ToList();
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

      

            return View(employees.ToPagedList(pagenumber , pagesize));
        }
        // if we use same fuction it engouf to weite the Action Name video 15
        // cette methode pour retourner la partie view de create
        //[HttpGet]
        //public ActionResult Create()
        //{

        //    return View();
        //}
        // pour voir la methode d'ajout comment faire juste affichage sur ecran 
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (string key in formCollection.AllKeys)
        //        {
        //            Response.Write("Key = " + key + "  ");
        //            Response.Write("Value = " + formCollection[key]);
        //            Response.Write("<br/>");
        //        }
        //    }
        //    return View();
        //}
        //1 er method of creation in database  : 
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    Employee employee = new Employee();
        //    // Retrieve form data using form collection
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.Cites = formCollection["Cites"];
        //    employee.DateOfBirth =
        //        Convert.ToDateTime(formCollection["DateOfBirth"]);

        //    EmployeeBusinessLayer employeeBusinessLayer =
        //        new EmployeeBusinessLayer();

        //    employeeBusinessLayer.AddEmmployee(employee);
        //    return RedirectToAction("Index");
        //}


        ////2eme methode of creation 
        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer =
        //            new EmployeeBusinessLayer();

        //        employeeBusinessLayer.AddEmmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //} 


        // 3eme methode
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                Employee employee = new Employee();
                TryUpdateModel<Employee>(employee);
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Methode pour edit 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                   new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.Employedid == id);

            return View(employee);
        }
        // 1ere method to edit All
        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer =
        //            new EmployeeBusinessLayer();
        //        employeeBusinessLayer.SaveEmmployee(employee);

        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}
        //2eme method for edit : include and exclude with bind
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude = "Name")] Employee employee)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employee.Name = employeeBusinessLayer.Employees.Single(x => x.Employedid == employee.Employedid).Name;

        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.SaveEmmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}
        // 3 eme methode method of edit : include and exclude interface
        [HttpPost]
[ActionName("Edit")]
public ActionResult Edit_Post(int id)
{
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer(); 
            Employee employee = employeeBusinessLayer.Employees.Single(x => x.Employedid == id); 
            UpdateModel<IEmployee>(employee); 
            if (ModelState.IsValid) { 
                employeeBusinessLayer.SaveEmmployee(employee); 
                return RedirectToAction("Index"); } 
            return View(employee);
}
        //bad method for deleting ( get it will be free from any effect
        //public ActionResult Delete(int id)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer =
        //        new EmployeeBusinessLayer();
        //    employeeBusinessLayer.DeleteEmployee(id);
        //    return RedirectToAction("Index");
        //}
        // delete with http post 
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                   new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.Employedid == id);

            return View(employee);
        }
        [HttpPost]
        [ActionName("Delete")]
        
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
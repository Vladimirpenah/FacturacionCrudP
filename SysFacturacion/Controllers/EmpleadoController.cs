using SysFacturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysFacturacion.Controllers
{
    public class EmpleadoController : Controller
    {
        private dbfacturacionEntities FacDB = new dbfacturacionEntities();
        // GET: Empleado
        public ActionResult Index()
        {
            List<empleado> EMPList = new List<empleado>();
            using (FacDB)
            {
                EMPList = FacDB.empleadoes.ToList<empleado>();
            }

            return View(EMPList);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
              empleado EMPModel = new empleado();

            using (FacDB)
            {
                EMPModel = FacDB.empleadoes.Where(x => x.IdEmpleado == id).FirstOrDefault();
            }
            return View(EMPModel);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View(new empleado());
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(empleado EMPModel)
        {
            try
            {
                using (FacDB)
                {
                    FacDB.empleadoes.Add(EMPModel);
                    FacDB.SaveChanges();

                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            empleado EMPModel = new empleado();

            using (FacDB)
            {
                EMPModel = FacDB.empleadoes.Where(x => x.IdEmpleado == id).FirstOrDefault();
            }
            return View(EMPModel);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(empleado EMPModel)
        {
            using (FacDB)
            {
                FacDB.Entry(EMPModel).State = System.Data.Entity.EntityState.Modified;
                FacDB.SaveChanges();



            }

            return RedirectToAction("Index");

        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            empleado EMPModel = new empleado();

            using (FacDB)
            {
                EMPModel = FacDB.empleadoes.Where(x => x.IdEmpleado == id).FirstOrDefault();
            }
            return View(EMPModel);
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (FacDB)
            {
              empleado  EMPModel = FacDB.empleadoes.Where(x => x.IdEmpleado == id).FirstOrDefault();
                FacDB.empleadoes.Remove(EMPModel);
                FacDB.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}

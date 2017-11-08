using SysFacturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysFacturacion.Controllers
{
    public class ClienteController : Controller
    {
        private dbfacturacionEntities FacDB = new dbfacturacionEntities();
        // GET: Cliente
        public ActionResult Index()
        {
            List<cliente> CltList = new List<cliente>();
            using (FacDB)
            {
                CltList = FacDB.clientes.ToList<cliente>();
            }

            return View(CltList);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            cliente CLTModel = new cliente();

            using (FacDB)
            {
               CLTModel = FacDB.clientes.Where(x => x.IdCliente == id).FirstOrDefault();
            }
            return View(CLTModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View(new cliente());
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(cliente CLTModel)
        {
            try
            {
                using (FacDB)
                {
                    FacDB.clientes.Add(CLTModel);
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            cliente CLTModel = new cliente();

            using (FacDB)
            {
                CLTModel = FacDB.clientes.Where(x => x.IdCliente == id).FirstOrDefault();
            }
            return View(CLTModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, cliente CLTModel)
        {
            using (FacDB)
            {
                FacDB.Entry(CLTModel).State = System.Data.Entity.EntityState.Modified;
                FacDB.SaveChanges();



            }

            return RedirectToAction("Index");
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            cliente CLTModel = new cliente();

            using (FacDB)
            {
                CLTModel = FacDB.clientes.Where(x => x.IdCliente == id).FirstOrDefault();
            }
            return View(CLTModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (FacDB)
            {
                cliente CLTModel = FacDB.clientes.Where(x => x.IdCliente == id).FirstOrDefault();
                FacDB.clientes.Remove(CLTModel);
                FacDB.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}

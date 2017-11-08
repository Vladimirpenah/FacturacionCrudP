using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysFacturacion.Models;
using System.Net;

namespace SysFacturacion.Controllers
{
    public class ArticuloController : Controller
    {

        private dbfacturacionEntities FacDB = new dbfacturacionEntities();
        // GET: Articulo
        public ActionResult Index()
        {
            List<articulo> ArticuloList = new List<articulo>();
            using (FacDB)
            {
                ArticuloList = FacDB.articuloes.ToList<articulo>();
            }

            return View(ArticuloList);
        }

        
       

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View(new articulo());
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(articulo articuloModel)
        {
            try
            {
                using (FacDB)
                {
                    FacDB.articuloes.Add(articuloModel);
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

        // GET: Articulo/Details/5

        public ActionResult Details(int? id)
        {
            
            //articulo art = FacDB.articuloes.Find(id);

            articulo ArticuloModel = new articulo();

            using (FacDB)
            {
                ArticuloModel = FacDB.articuloes.Where(x => x.IdArticulo == id).FirstOrDefault();
            }
            return View( ArticuloModel);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            articulo ArticuloModel = new articulo();

            using (FacDB)
            {
                ArticuloModel = FacDB.articuloes.Where(x => x.IdArticulo == id).FirstOrDefault();
            }
            return View(ArticuloModel);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(articulo ArticuloModel)
        {
           
                using (FacDB)
                {
                    FacDB.Entry(ArticuloModel).State = System.Data.Entity.EntityState.Modified;
                    FacDB.SaveChanges();



                }

                return RedirectToAction("Index");
            
           
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            articulo ArticuloModel = new articulo();

            using (FacDB)
            {
                ArticuloModel = FacDB.articuloes.Where(x => x.IdArticulo == id).FirstOrDefault();
            }
            return View(ArticuloModel);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (FacDB)
            {
              articulo  ArticuloModel = FacDB.articuloes.Where(x => x.IdArticulo == id).FirstOrDefault();
                FacDB.articuloes.Remove(ArticuloModel);
                FacDB.SaveChanges();

            }
            return RedirectToAction("Index");
           
        }
    }
}

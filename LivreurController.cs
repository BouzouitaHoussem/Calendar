using ConsommiTounsi.Models;
using IronRuby.Runtime;
using Solution.Domain.Entities;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class LivreurController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ILivreurService Service;
        public LivreurController()
        {
            Service = new LivreurService();
        }
        // GET: Livreur
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: Livreur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livreur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livreur/Create
        [HttpPost]
        public ActionResult Create(Livreur livreur)
        {
            
            Service.Add(livreur);
            Service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Livreur/Edit/5
        
        public ActionResult Edit(int id)
        {



            return View(Service.GetById(id));
        }

        // POST: Livreur/Edit/5

        // POST: Livreurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult Edit(int id,Livreur liv)
        {


            try
            {
                Livreur l = Service.GetById(id);
                l.LastName = liv.LastName;
                l.FirstName = liv.FirstName;
                Service.Update(l);
                Service.Commit();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livreur/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(Service.GetById(id));
        }

        // POST: Livreur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Livreur livreur)
        {
            try
            {
                //Service.Delete(client);
                //Service.Commit();
                //Service.Dispose();
                Livreur c = Service.GetById(id);
                Service.Delete(c);
                Service.Commit();

                //Service.Delete(Service.Get(x=>x.ClientId.Equals(c)));
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcPet.Entities;
using mvcPet.UI.Website.Models;
using mvcPet.Services.Contracts;
using mvcPet.Services;

namespace mvcPet.UI.Website.Controllers
{
    public class OperadorController : Controller
    {
        private IOperadorService db = new OperadorService();

        [Authorize]
        public ActionResult Index()
        {
            return View(db.ToList());
        }

        // GET: Operador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Find(id.Value);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Apellido,Nombre,Email,Telefono,Url,Edad,Domicilio")] Operador operador)
        {
            if (ModelState.IsValid)
            {
                db.Add(operador);

                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro agregado a la base de datos.",
                    MessageType = GenericMessages.success
                };

                return RedirectToAction("Index");
            }

            return View(operador);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Find(id.Value);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // POST: Operador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Apellido,Nombre,Email,Telefono,Url,Edad,Domicilio")] Operador operador)
        {
            if (ModelState.IsValid)
            {
                db.Edit(operador);
                TempData["MessageViewBagName"] = new GenericMessageViewModel
                {
                    Message = "Registro editado en la base de datos.",
                    MessageType = GenericMessages.success
                };
                return RedirectToAction("Index");
            }
            return View(operador);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Find(id.Value);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // POST: Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Operador operador = db.Find(id);
            db.Remove(operador);
            TempData["MessageViewBagName"] = new GenericMessageViewModel
            {
                Message = "Registro eliminado de la base de datos.",
                MessageType = GenericMessages.success
            };
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db = null;
            }
            base.Dispose(disposing);
        }
    }
}

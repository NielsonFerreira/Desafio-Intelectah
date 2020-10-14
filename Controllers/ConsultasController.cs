using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio_Intelectah.Models;

namespace Desafio_Intelectah.Controllers
{
    public class ConsultasController : Controller
    {
        private Desafio_IntelectahEntities db = new Desafio_IntelectahEntities();

        // GET: Consultas
        public async Task<ActionResult> Index()
        {
            var consultas = db.Consultas.Include(c => c.Consulta1).Include(c => c.Consulta2);
            return View(await consultas.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente");
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente");
            return View();
        }

        // POST: Consultas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,paciente,tipo_de_exame,data,hora")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,paciente,tipo_de_exame,data,hora")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            ViewBag.id = new SelectList(db.Consultas, "id", "paciente", consulta.id);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consulta consulta = await db.Consultas.FindAsync(id);
            db.Consultas.Remove(consulta);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

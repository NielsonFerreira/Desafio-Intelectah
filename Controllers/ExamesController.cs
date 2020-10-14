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
    public class ExamesController : Controller
    {
        private Desafio_IntelectahEntities db = new Desafio_IntelectahEntities();

        // GET: Exames
        public async Task<ActionResult> Index()
        {
            var exames = db.Exames.Include(e => e.Tipo_de_exame);
            return View(await exames.ToListAsync());
        }

        // GET: Exames/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = await db.Exames.FindAsync(id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // GET: Exames/Create
        public ActionResult Create()
        {
            ViewBag.tipo_exame = new SelectList(db.Tipo_de_exame, "id", "nome");
            return View();
        }

        // POST: Exames/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nome,observacoes,tipo_exame")] Exame exame)
        {
            if (ModelState.IsValid)
            {
                db.Exames.Add(exame);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_exame = new SelectList(db.Tipo_de_exame, "id", "nome", exame.tipo_exame);
            return View(exame);
        }

        // GET: Exames/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = await db.Exames.FindAsync(id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_exame = new SelectList(db.Tipo_de_exame, "id", "nome", exame.tipo_exame);
            return View(exame);
        }

        // POST: Exames/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nome,observacoes,tipo_exame")] Exame exame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exame).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_exame = new SelectList(db.Tipo_de_exame, "id", "nome", exame.tipo_exame);
            return View(exame);
        }

        // GET: Exames/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exame exame = await db.Exames.FindAsync(id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Exame exame = await db.Exames.FindAsync(id);
            db.Exames.Remove(exame);
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

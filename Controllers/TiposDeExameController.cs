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
    public class TiposDeExameController : Controller
    {
        private Desafio_IntelectahEntities db = new Desafio_IntelectahEntities();

        // GET: TiposDeExame
        public async Task<ActionResult> Index()
        {
            return View(await db.Tipo_de_exame.ToListAsync());
        }

        // GET: TiposDeExame/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_exame tipo_de_exame = await db.Tipo_de_exame.FindAsync(id);
            if (tipo_de_exame == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_exame);
        }

        // GET: TiposDeExame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDeExame/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nome,descricao")] Tipo_de_exame tipo_de_exame)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_de_exame.Add(tipo_de_exame);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo_de_exame);
        }

        // GET: TiposDeExame/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_exame tipo_de_exame = await db.Tipo_de_exame.FindAsync(id);
            if (tipo_de_exame == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_exame);
        }

        // POST: TiposDeExame/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nome,descricao")] Tipo_de_exame tipo_de_exame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_de_exame).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_de_exame);
        }

        // GET: TiposDeExame/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_exame tipo_de_exame = await db.Tipo_de_exame.FindAsync(id);
            if (tipo_de_exame == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_exame);
        }

        // POST: TiposDeExame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tipo_de_exame tipo_de_exame = await db.Tipo_de_exame.FindAsync(id);
            db.Tipo_de_exame.Remove(tipo_de_exame);
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

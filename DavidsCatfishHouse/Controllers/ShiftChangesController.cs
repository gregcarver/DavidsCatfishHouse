using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DavidsCatfishHouse.Models;

namespace DavidsCatfishHouse.Controllers
{
    public class ShiftChangesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShiftChanges
        public ActionResult Index()
        {
            return View(db.ShiftChanges.ToList());
        }

        // GET: ShiftChanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChange shiftChange = db.ShiftChanges.Find(id);
            if (shiftChange == null)
            {
                return HttpNotFound();
            }
            return View(shiftChange);
        }

        // GET: ShiftChanges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentEmployee,NewEmployee,Start,End,Reason,Email")] ShiftChange shiftChange)
        {
            if (ModelState.IsValid)
            {
                db.ShiftChanges.Add(shiftChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftChange);
        }

        // GET: ShiftChanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChange shiftChange = db.ShiftChanges.Find(id);
            if (shiftChange == null)
            {
                return HttpNotFound();
            }
            return View(shiftChange);
        }

        // POST: ShiftChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentEmployee,NewEmployee,Start,End,Reason,Email")] ShiftChange shiftChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftChange);
        }

        // GET: ShiftChanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChange shiftChange = db.ShiftChanges.Find(id);
            if (shiftChange == null)
            {
                return HttpNotFound();
            }
            return View(shiftChange);
        }

        // POST: ShiftChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftChange shiftChange = db.ShiftChanges.Find(id);
            db.ShiftChanges.Remove(shiftChange);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendMail(ShiftChangeRequest vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("gregory.carverprovalus@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("youremailid@gmail.com", "password");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
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

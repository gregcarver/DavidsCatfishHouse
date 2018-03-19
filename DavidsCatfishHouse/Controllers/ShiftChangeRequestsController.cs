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
    public class ShiftChangeRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShiftChangeRequests
        public ActionResult Index()
        {
            return View(db.ShiftChangeRequests.ToList());
        }

        // GET: ShiftChangeRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChangeRequest shiftChangeRequest = db.ShiftChangeRequests.Find(id);
            if (shiftChangeRequest == null)
            {
                return HttpNotFound();
            }
            return View(shiftChangeRequest);
        }

        // GET: ShiftChangeRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftChangeRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentEmployee,NewEmployee")] ShiftChangeRequest shiftChangeRequest)
        {
            if (ModelState.IsValid)
            {
                db.ShiftChangeRequests.Add(shiftChangeRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftChangeRequest);
        }

        // GET: ShiftChangeRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChangeRequest shiftChangeRequest = db.ShiftChangeRequests.Find(id);
            if (shiftChangeRequest == null)
            {
                return HttpNotFound();
            }
            return View(shiftChangeRequest);
        }

        // POST: ShiftChangeRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentEmployee,NewEmployee")] ShiftChangeRequest shiftChangeRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftChangeRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftChangeRequest);
        }

        // GET: ShiftChangeRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftChangeRequest shiftChangeRequest = db.ShiftChangeRequests.Find(id);
            if (shiftChangeRequest == null)
            {
                return HttpNotFound();
            }
            return View(shiftChangeRequest);
        }

        // POST: ShiftChangeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftChangeRequest shiftChangeRequest = db.ShiftChangeRequests.Find(id);
            db.ShiftChangeRequests.Remove(shiftChangeRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public ActionResult Index(ShiftChangeRequest vm)
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

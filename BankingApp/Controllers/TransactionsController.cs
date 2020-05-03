using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationLogic.DataModel;
using DataAccess;
using DataAccess.Repositories;
using System.Data;

namespace BankingApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionRepository _context;

        public TransactionsController(TransactionRepository context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = from transaction in _context.GetAll()
                               select transaction;
                               return View(transactions);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Transaction transaction = _context.GetTransactionByTransactionId(id);
            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View(new Transaction());
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(transaction);
                    _context.Update(transaction);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction transaction = _context.GetTransactionByTransactionId(id);

            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(transaction);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Transaction transaction = _context.GetTransactionByTransactionId(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
                Transaction transaction = _context.GetTransactionByTransactionId(id);
                _context.Delete(transaction);
                return RedirectToAction("Index");
        }
    }
}

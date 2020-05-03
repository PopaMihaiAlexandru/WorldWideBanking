using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationLogic.DataModel;
using DataAccess;
using ApplicationLogic.Abstractions;

namespace BankingApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardRepository _context;
        private readonly BankDbContext _contextBank;

        public CardsController(ICardRepository context, BankDbContext contextBank)
        {
            _context = context;
            _contextBank = contextBank;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            var transactions = from transaction in _context.GetAll()
                               select transaction;
            return View(transactions);
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Card card = _context.GetCardByCardId(id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }
            // GET: Cards/Create
        public IActionResult Create()
        {
            return View(new Card());
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card)
        {
            if (ModelState.IsValid)
            {
                card.CardID = Guid.NewGuid();
                _context.Add(card);
                _context.Update(card);
                return RedirectToAction("Index");
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Card card = _context.GetCardByCardId(id);

            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Card card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(card);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Card card = _context.GetCardByCardId(id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Card card = _context.GetCardByCardId(id);
            _context.Delete(card);
            return RedirectToAction("Index");
        }

        private bool CardExists(Guid id)
        {
            return _contextBank.Cards.Any(e => e.CardID == id);
        }
    }
}

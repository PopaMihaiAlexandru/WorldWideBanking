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
using Microsoft.AspNetCore.Authorization;

namespace BankingApp.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _context;
        private readonly BankDbContext _contextBank;

        public ClientsController(IClientRepository context, BankDbContext contextBank)
        {
            _context = context;
            _contextBank = contextBank;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = from client in _context.GetAll()
                           select client;
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = _context.GetClientByClientId(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientID = Guid.NewGuid();
                _context.Add(client);
                _context.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = _context.GetClientByClientId(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Client client)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(client);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = _context.GetClientByClientId(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Client client = _context.GetClientByClientId(id);
            _context.Delete(client);
            return RedirectToAction("Index");
        }

        private bool ClientExists(Guid id)
        {
            return _contextBank.Clients.Any(e => e.ClientID == id);
        }
    }
}

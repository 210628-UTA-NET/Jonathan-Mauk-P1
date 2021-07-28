using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreAppData;
using StoreAppBL;
using StoreModels;
using StoreWebUI.Models;

namespace StoreWebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly StoreAppDBContext _context;

        public CustomersController(StoreAppDBContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            List<CustomerVM> customerVMs = new List<CustomerVM>();
            List<Customer> customers = CustomerBL.ListCustomers();
            foreach (Customer customer in customers)
            {
                customerVMs.Add(new CustomerVM(customer));
            }
            return View(customerVMs);
        }

        public IActionResult CustomerSearch(string p_name)
        {

            List<CustomerVM> customerVMs = new List<CustomerVM>();
            List<Customer> customers;
            if (p_name == "")
            {
                customers = CustomerBL.SearchForCustomers(p_name);
            }
            else
            {
                customers = new List<Customer>();
            }
            foreach (Customer customer in customers)
            {
                customerVMs.Add(new CustomerVM(customer));
            }
            return View(customerVMs);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = CustomerBL.SearchCustomer((int)id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerVM(customer));
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Name,Address,Email,PhoneNumber")] CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                CustomerBL.AddCustomer(customer.Name, customer.Address, customer.Email, customer.PhoneNumber);
                /*_context.Add(customer);
                await _context.SaveChangesAsync();*/
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(new CustomerVM(customer));
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Name,Address,Email,PhoneNumber")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(new CustomerVM(customer));
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerVM(customer));
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreAppData;
using StoreModels;
using StoreAppBL;
using StoreWebUI.Models;

namespace StoreWebUI.Controllers
{
    public class StoreFrontsController : Controller
    {
        private readonly StoreAppDBContext _context;

        public StoreFrontsController(StoreAppDBContext context)
        {
            _context = context;
            CustomerDL._customerDL.ChangeContext(context);
            OrderDL._orderDL.ChangeContext(context);
            OrderLineItemDL._orderLineItem.ChangeContext(context);
            StoreFrontDL._storeFrontDL.ChangeContext(context);
            StoreLineItemDL._storeLineItem.ChangeContext(context);
            ProductDL._productDL.ChangeContext(context);
        }

        // GET: StoreFronts
        public async Task<IActionResult> Index()
        {
            //await _context.StoreFronts.ToListAsync()
            List<StoreFrontVM> storeFrontVMs = new List<StoreFrontVM>();
            foreach (StoreFront item in StoreFrontBL._storeFrontBL.RetrieveStores())
            {
                storeFrontVMs.Add(new StoreFrontVM(item));
            }
            return View(storeFrontVMs);
        }

        // GET: StoreFronts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int storeId = (int)id;
            StoreFront storeFront = StoreFrontBL._storeFrontBL.FindStore(storeId);
            List<LineItems> lineItems = StoreFrontBL._storeFrontBL.GetStoreInventory(storeFront.Id);
            if (storeFront == null)
            {
                return NotFound();
            }

            return View(new StoreFrontDetailsVM(storeFront, lineItems));
        }

        public IActionResult DetailOrders(int? id, int? sort)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (sort == null)
            {
                sort = -1;
            }

            int storeId = (int)id;
            StoreFront storeFront = StoreFrontBL._storeFrontBL.FindStore(storeId);
            List<Orders> storeOrders = StoreFrontBL._storeFrontBL.GetStoreOrders(storeId);
            if (storeFront == null)
            {
                return NotFound();
            }

            switch (sort)
            {
                case 0:
                    storeOrders = storeOrders.OrderBy(date => date.DateOrdered).ToList();
                    break;
                case 1:
                    storeOrders = storeOrders.OrderBy(date => date.DateOrdered).ToList();
                    storeOrders.Reverse();
                    break;
                case 2:
                    storeOrders = storeOrders.OrderBy(price => price.TotalPrice).ToList();
                    break;
                default:
                    break;
            }

            return View(new StoreFrontOrdersVM(storeFront, storeOrders));
        }

        public IActionResult Replenish(int id)
        {
            StoreFront storeFront = StoreFrontBL._storeFrontBL.FindStore(id);
            List<LineItems> lineItems = StoreFrontBL._storeFrontBL.GetStoreInventory(storeFront.Id);
            if (storeFront == null)
            {
                return NotFound();
            }

            return View(new StoreFrontDetailsVM(storeFront, lineItems));
        }

        [HttpPost]
        public IActionResult ReplenishInventory(params string[] p_replenish)
        {
            for (int i = 0; i < p_replenish.Length; i += 2)
            {
                int count = Int32.Parse(p_replenish[i]);
                if(count > 0)
                {
                    StoreFrontBL._storeFrontBL.ReplenishInventory(Int32.Parse(p_replenish[i + 1]), count);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: StoreFronts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreFronts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] StoreFront storeFront)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeFront);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeFront);
        }

        // GET: StoreFronts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFront = await _context.StoreFronts.FindAsync(id);
            if (storeFront == null)
            {
                return NotFound();
            }
            return View(storeFront);
        }

        // POST: StoreFronts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] StoreFront storeFront)
        {
            if (id != storeFront.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeFront);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreFrontExists(storeFront.Id))
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
            return View(storeFront);
        }

        // GET: StoreFronts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeFront = await _context.StoreFronts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeFront == null)
            {
                return NotFound();
            }

            return View(storeFront);
        }

        // POST: StoreFronts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeFront = await _context.StoreFronts.FindAsync(id);
            _context.StoreFronts.Remove(storeFront);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreFrontExists(int id)
        {
            return _context.StoreFronts.Any(e => e.Id == id);
        }
    }
}

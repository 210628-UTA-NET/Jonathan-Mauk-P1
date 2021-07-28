using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreAppData;
using StoreModels;
using StoreWebUI.Models;
using StoreAppBL;

namespace StoreWebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StoreAppDBContext _context;

        public OrdersController(StoreAppDBContext context)
        {
            _context = context;
            CustomerDL._customerDL.ChangeContext(context);
            OrderDL._orderDL.ChangeContext(context);
            OrderLineItemDL._orderLineItem.ChangeContext(context);
            StoreFrontDL._storeFrontDL.ChangeContext(context);
            StoreLineItemDL._storeLineItem.ChangeContext(context);
            ProductDL._productDL.ChangeContext(context);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Orders order = OrderBL.FindOrder((int)id);
            StoreFront store = StoreFrontBL._storeFrontBL.FindStore(order.StoreFrontId);
            Customer customer = CustomerBL.SearchCustomer(order.CustomerId);
            if (order == null)
            {
                return NotFound();
            }

            return View(new OrderVM(order, store.Name, customer.Name));
        }

        // GET: Orders/Create/5
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = CustomerBL.SearchCustomer((int)id);
            List<StoreFront> storeFronts = StoreFrontBL._storeFrontBL.RetrieveStores();
            return View(new CreateOrderFromCustomerVM(customer, storeFronts));
        }

        public IActionResult Cart(int? customerId, int? storeId)
        {
            if (customerId == null || storeId == null)
            {
                return NotFound();
            }
            Customer customer = CustomerBL.SearchCustomer((int)customerId);
            StoreFront chosenStore = StoreFrontBL._storeFrontBL.FindStore((int)storeId);
            Console.WriteLine(storeId);
            List<StoreFront> storeFronts = StoreFrontBL._storeFrontBL.RetrieveStores();
            return View(new CreateOrderFromCustomerVM(customer, chosenStore, storeFronts));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_customerId">The Id of the Customer making the order</param>
        /// <param name="p_storeId">The Id of the store the order is being placed at</param>
        /// <param name="p_orderedLineItem">A list containing string values of
        ///                                 The amount of items being ordered
        ///                                 The Id of the Product being ordered
        ///                                 The Id of the StoreLineItem being ordered from
        ///             These three values repeat for every StoreLineItem in the Store</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Checkout(int p_customerId, int p_storeId, params string[] p_orderedLineItem)
        {
            Customer customer = CustomerBL.SearchCustomer(p_customerId);
            StoreFront store = StoreFrontBL._storeFrontBL.FindStore(p_storeId);
            List<OrderLineItem> orderedItems = new List<OrderLineItem>();
            decimal price = 0;
            for (int i = 0; i < p_orderedLineItem.Length; i += 3)
            {
                int count = Int32.Parse(p_orderedLineItem[i]);
                if (count > 0)
                {
                    OrderLineItem orderLineItem = new OrderLineItem()
                    {
                        Count = count,
                        Product = ProductDL._productDL.FindProduct(Int32.Parse(p_orderedLineItem[i + 1])),
                        FkId = Int32.Parse(p_orderedLineItem[i + 2])
                    };
                    orderedItems.Add(orderLineItem);
                    price += orderLineItem.Product.Price * Int32.Parse(p_orderedLineItem[i]);
                }
            }
            Orders currentOrder = new Orders()
            {
                Id = 0,
                CustomerId = p_customerId,
                StoreFrontId = p_storeId,
                LineItems = orderedItems,
                TotalPrice = price
            };
            return View(new OrderVM(currentOrder, store.Name, customer.Name));
        }

        [HttpPost]
        public IActionResult FinalizeOrder(int p_customerId, int p_storeId, params string[] p_orderedLineItem)
        {
            OrderBL finalOrder = new OrderBL();
            finalOrder.BeginOrder(p_customerId, StoreFrontBL._storeFrontBL.FindStore(p_storeId));
            for (int i = 0; i < p_orderedLineItem.Length; i += 2)
            {
                finalOrder.AddOrderItem(Int32.Parse(p_orderedLineItem[i + 1]), Int32.Parse(p_orderedLineItem[i]));
            }
            finalOrder.FinalizeOrder();
            return RedirectToAction(nameof(Details), "Customers", new { id = p_customerId });
        }
        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalPrice,LocationId,CustomerId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalPrice,LocationId,CustomerId")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}

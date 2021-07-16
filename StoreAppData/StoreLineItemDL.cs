using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreAppData
{
    public class StoreLineItemDL : Repository, ILineItemDL
    {
        // The Singleton for the StoreLineItem class
        public static StoreLineItemDL _storeLineItem = new StoreLineItemDL(new StoreAppDBContext(DatabaseConnection.GetDatabaseOptions()));
        public StoreLineItemDL(StoreAppDBContext p_context) : base(p_context)
        {
            _context = p_context;
        }

        /// <summary>
        /// Converts an Entities.StoreLineItem class to a StoreModels.LineItems class
        /// </summary>
        /// <param name="eLineItem">The Entities.StoreLineItem to be converted</param>
        /// <returns>A converted StoreModels.LineItems class</returns>
        /*public static LineItems EntityToModel(Entities.StoreLineItem eLineItem)
        {
            return new LineItems()
            /*{
                Id = eLineItem.StoreLineItemId,
                FkId = eLineItem.StoreId,
                Product = ProductDL._productDL.FindProduct(eLineItem.ProductId),
                Count = eLineItem.Quantity
            };
        }*/

        public LineItems FindLineItem(int id)
        {
            StoreLineItem storeLineItem = _context.StoreLineItems.Find(id);
            return storeLineItem;
        }

        public List<LineItems> RetrieveLineItems(int fkid)
        {
            return _context.StoreLineItems.Select(
                rest => rest as LineItems
            ).ToList().Where(
                rest => rest.FkId == fkid
            ).ToList();
        }

        /// <summary>
        /// Updates a LineItem in the database
        /// </summary>
        /// <param name="id">The id of the LineItem being updated</param>
        /// <param name="addedQuantity">The number being added to the quantity of the LineItem</param>
        /// <returns>Returns true if the update succeded</returns>
        public bool UpdateLineItem(int id, int addedQuantity)
        {
            try
            {
                StoreLineItem updatedLineItem = _context.StoreLineItems.Find(id);
                updatedLineItem.Count += addedQuantity;
                _context.StoreLineItems.Update(updatedLineItem);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Same functionality as UpdateLineItem except that it does not save changes to the context.
        /// StoreLineItemSave() will need to be called after calling this function
        /// </summary>
        /// <param name="id">The id of the LineItem being updated</param>
        /// <param name="addedQuantity">The number being added to the quantity of the LineItem</param>
        /// <returns></returns>
        public bool UpdateLineItemNoSave(int id, int addedQuantity)
        {
            try
            {
                StoreLineItem updatedLineItem = _context.StoreLineItems.Find(id);
                updatedLineItem.Count += addedQuantity;
                _context.StoreLineItems.Update(updatedLineItem);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves any changes to the StoreLineItemDL._context
        /// </summary>
        public void StoreLineItemSave(){
            _context.SaveChanges();
        }
    }
}
using StoreModels;
using StoreAppData;
using System.Collections.Generic;

namespace StoreAppBL
{
    /// <summary>
    /// Accesses the data layer for operations pertaining to a store front or its inventory
    /// </summary>
    public class StoreFrontBL
    {
        // The Singleton fot StoreFrontBL
        public static StoreFrontBL _storeFrontBL = new StoreFrontBL();

        /// <summary>
        /// Calls the data layer to find a store given the name of the store
        /// </summary>
        /// <param name="name">The name of the store</param>
        /// <returns>The store being searched for or null if no store is found</returns>
        public StoreFront FindStore(string name)
        {
            return StoreFrontDL._storeFrontDL.FindStore(name);
        }

        /// <summary>
        /// Calls the data layer to find a store given the id of the store
        /// </summary>
        /// <param name="id">The id of the store</param>
        /// <returns>The store being searched for or null if no store is found</returns>
        public StoreFront FindStore(int id)
        {
            return StoreFrontDL._storeFrontDL.FindStore(id);
        }

        /// <summary>
        /// Calls the data layer to retrieve a list of all stores in the database
        /// </summary>
        /// <returns>A list containing every store in the database</returns>
        public List<StoreFront> RetrieveStores()
        {
            return StoreFrontDL._storeFrontDL.RetrieveStoreFronts();
        }

        /// <summary>
        /// Calls the data layer to find a StoreLineItem given its id.
        /// Throws an exception if no StoreLineItem is found.
        /// </summary>
        /// <param name="id">The id of the StoreLineItem</param>
        public void FindStoreInventory(int id)
        {
            if(StoreLineItemDL._storeLineItem.FindLineItem(id) == null)
            {
                throw new System.Exception();
            }
        }

        /// <summary>
        /// Calls the data layer to update StoreLineItems in the database
        /// </summary>
        /// <param name="p_storeLineItemId">The id of the StoreLineItem to be updated</param>
        /// <param name="p_addedQuantity">The amount to add to the StoreLineItem's quantity</param>
        /// <returns>True: if the update was successful
        /// False: if the update was unseccessful or p_addedQuantity < 0</returns>
        public bool ReplenishInventory(int p_storeLineItemId, int p_addedQuantity)
        {
            if (p_addedQuantity > 0)
            {
                return StoreLineItemDL._storeLineItem.UpdateLineItem(p_storeLineItemId, p_addedQuantity);
            }
            else
            {
                return false;
            }
        }
    }
}
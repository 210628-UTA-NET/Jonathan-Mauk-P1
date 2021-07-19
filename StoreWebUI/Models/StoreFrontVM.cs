using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class StoreFrontVM
    {
        public StoreFrontVM()
        {

        }

        public StoreFrontVM(StoreFront p_store)
        {
            Id = p_store.Id;
            Name = p_store.Name;
            Address = p_store.Address;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}

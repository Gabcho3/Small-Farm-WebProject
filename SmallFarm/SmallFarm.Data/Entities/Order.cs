﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SmallFarm.Data.Entities
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime OrderedDate { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ClientId { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]
        public ApplicationUser Client { get; set; } = null!;

        [Required]
        public Guid ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public List<ProductOrder> ProductsOrders { get; set; }
    }
}

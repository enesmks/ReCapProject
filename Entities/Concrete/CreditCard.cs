using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        [Key]
        public int CreditId { get; set; }
        public int CustomerId { get; set; }
        public string CartNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvv { get; set; }
        public string CardType { get; set; }
    }
}

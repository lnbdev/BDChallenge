using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public double Balance { get; set; }
    }
}
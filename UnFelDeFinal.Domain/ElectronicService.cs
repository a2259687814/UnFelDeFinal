﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnFelDeFinal.Domain
{
    public class ElectronicService : BaseEntity
    {
        
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string TreasureAccount { get; set; }

        //navigation property
        public virtual ICollection<BillingDetails> BillingDetails { get; set; }
        public virtual ICollection<Iban> Iban { get; set; }
    }
}
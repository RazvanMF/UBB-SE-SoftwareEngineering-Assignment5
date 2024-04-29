﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Data.Models
{
    public class PriceDropAlert : IAlert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public float OldPrice { get; set; }
        public float NewPrice { get; set; }

        public IAlert IAlert
        {
            get => default;
            set
            {
            }
        }

        public IAlert IAlert1
        {
            get => default;
            set
            {
            }
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class ContactDTO
    {
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}

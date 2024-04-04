using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class AppUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
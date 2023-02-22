using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentoSecondo.Models
{
    internal readonly record struct CustomerSpender(int CustomerId, decimal TotalAmount);

}

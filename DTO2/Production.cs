using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO2
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime prodDate { get; set; }
        public decimal amount { get; set; }
        public int typeProdId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Santa_NFT.Models
{
    public class Base
    {
        public bool? IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}

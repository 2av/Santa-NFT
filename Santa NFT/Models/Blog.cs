using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Santa_NFT.Models
{
    public class Blog:Base
    {
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string BlogDescriptions { get; set; }

        public int? BlogCategoryId { get; set; }

        public int? DisplayOrder { get; set; }

        public string BlogBanner { get; set; }
      
    }
}
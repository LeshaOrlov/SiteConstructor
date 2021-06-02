using System;
using System.Collections.Generic;
using System.Text;

namespace SiteConstructor.Framework.Table
{
    public class PaginTable
    {
        public int Offset { get; set; }
        public int Fetch { get; set; }
        public int Count { get; set; }
    }
}

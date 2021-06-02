using Microsoft.EntityFrameworkCore;
using System;

namespace SiteConstructor.Framework.Models
{
    [Owned]
    public class EntityInfo
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
        public string UserCreate { get; set; }
        public string UserLastEdit { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileContext :DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {

        }

        public DbSet<MobileItems> MobileItems { get; set; }

        public DbSet<AccessoryItems> AccessoryItems { get; set; }
    }
}

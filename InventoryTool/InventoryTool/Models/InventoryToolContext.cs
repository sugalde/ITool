using System.Data.Entity;

namespace InventoryTool.Models
{
    public class InventoryToolContext : DbContext
    {
        public InventoryToolContext() : base("name=InventoryToolContext")
        {
        }

        public DbSet<Fleet> Fleets { get; set; }

        public System.Data.Entity.DbSet<InventoryTool.Models.FeeCode> FeeCodes { get; set; }

        public System.Data.Entity.DbSet<InventoryTool.Models.CR> CRs { get; set; }

        public System.Data.Entity.DbSet<InventoryTool.Models.CRdetail> CRdetails { get; set; }

        public System.Data.Entity.DbSet<InventoryTool.Models.Ssupplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<InventoryTool.Models.Acode> Atacodes { get; set; }
    }
}

using CheckAndTransferService.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckAndTransferService.Repository
{
    public partial class MosConsultTestDbContext : DbContext
    {
        public MosConsultTestDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<ItemsTable1> ItemsTable1 { get; set; }
        public virtual DbSet<ItemsTable2> ItemsTable2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsTable1>(entity =>
            {
                entity.Property(e => e.ItemInfo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemsTable2>(entity =>
            {
                entity.Property(e => e.ItemInfo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Table1Item)
                    .WithMany(p => p.ItemsTable2)
                    .HasForeignKey(d => d.Table1ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemsTabl__Table__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

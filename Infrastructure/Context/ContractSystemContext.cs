

namespace Infrastructure.Context
{

    public partial class ContractSystemContext : DbContext
    {

        public ContractSystemContext(DbContextOptions<ContractSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Concod);

                entity.ToTable("CONTACT");

                entity.Property(e => e.Concod)
                    .HasComment("Contact Code")
                    .HasColumnName("CONCOD");
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasComment("Contact Address")
                    .HasColumnName("ADDRESS");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasComment("Contact Name")
                    .HasColumnName("NAME");
                entity.Property(e => e.Note)
                    .HasComment("Contact Note")
                    .HasColumnName("NOTE");
                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasComment("Contact Phone")
                    .HasColumnName("PHONE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
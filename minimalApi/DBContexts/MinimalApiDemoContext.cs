using Microsoft.EntityFrameworkCore;
using minimalApi.Entities;

namespace minimalApi.DBContexts;

public partial class MinimalApiDemoContext : DbContext
{
    public MinimalApiDemoContext()
    {
    }

    public MinimalApiDemoContext(DbContextOptions<MinimalApiDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentCode).HasName("PK__AGENTS__843A8BBA86D33FC6");

            entity.ToTable("AGENTS");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.AgentName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_NAME");
            entity.Property(e => e.Commission)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("COMMISSION");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE_NO");
            entity.Property(e => e.WorkingArea)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("WORKING_AREA");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustCode).HasName("PK__CUSTOMER__8393C4A1C491C22E");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustCode)
                .HasMaxLength(6)
                .HasColumnName("CUST_CODE");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.CustCity)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUST_CITY");
            entity.Property(e => e.CustCountry)
                .HasMaxLength(20)
                .HasColumnName("CUST_COUNTRY");
            entity.Property(e => e.CustName)
                .HasMaxLength(40)
                .HasColumnName("CUST_NAME");
            entity.Property(e => e.Grade).HasColumnName("GRADE");
            entity.Property(e => e.OpeningAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("OPENING_AMT");
            entity.Property(e => e.OutstandingAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("OUTSTANDING_AMT");
            entity.Property(e => e.PaymentAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("PAYMENT_AMT");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(17)
                .HasColumnName("PHONE_NO");
            entity.Property(e => e.ReceiveAmt)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("RECEIVE_AMT");
            entity.Property(e => e.WorkingArea)
                .HasMaxLength(35)
                .HasColumnName("WORKING_AREA");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdNum).HasName("PK__ORDERS__27AB607CE6EC8C44");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdNum)
                .HasColumnType("decimal(6, 0)")
                .HasColumnName("ORD_NUM");
            entity.Property(e => e.AdvanceAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ADVANCE_AMOUNT");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGENT_CODE");
            entity.Property(e => e.CustCode)
                .HasMaxLength(6)
                .HasColumnName("CUST_CODE");
            entity.Property(e => e.OrdAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ORD_AMOUNT");
            entity.Property(e => e.OrdDate).HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdDescription)
                .HasMaxLength(60)
                .HasColumnName("ORD_DESCRIPTION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

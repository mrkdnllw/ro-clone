using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ROCloneAPI.Models;

public partial class Db1Context : DbContext
{
    public Db1Context()
    {
    }

    public Db1Context(DbContextOptions<Db1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Character1> Character1s { get; set; }

    public virtual DbSet<CharacterMonster> CharacterMonster { get; set; }


    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Monster> Monsters { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AMARKLOVELACEII\\SQLEXPRESS;Database=DB1;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHARACTE__3214EC272D4168EA");

            entity.ToTable("CHARACTER1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aspd).HasColumnName("ASPD");
            entity.Property(e => e.Atk).HasColumnName("ATK");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS");
            entity.Property(e => e.Def).HasColumnName("DEF");
            entity.Property(e => e.Hp).HasColumnName("HP");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Sp).HasColumnName("SP");

            entity.HasMany(d => d.Monsters).WithMany(p => p.Chars)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMonster",
                    r => r.HasOne<Monster>().WithMany()
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Character__monst__52593CB8"),
                    l => l.HasOne<Character1>().WithMany()
                        .HasForeignKey("CharId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Character__char___5165187F"),
                    j =>
                    {
                        j.HasKey("CharId", "MonsterId").HasName("PK__Characte__5DED376CB9A7B9C7");
                        j.ToTable("CharacterMonster");
                        j.IndexerProperty<int>("CharId").HasColumnName("char_id");
                        j.IndexerProperty<int>("MonsterId").HasColumnName("monster_id");
                    });
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EB4F3CF8BA");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Monster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__monster__3213E83F795A8D98");

            entity.ToTable("monster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aspd).HasColumnName("aspd");
            entity.Property(e => e.Atk).HasColumnName("atk");
            entity.Property(e => e.Def).HasColumnName("def");
            entity.Property(e => e.Hp).HasColumnName("hp");
            entity.Property(e => e.Matk).HasColumnName("matk");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF0905140A");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F39FE3752");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Fname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Pw)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pw");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

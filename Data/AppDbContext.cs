using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DndCharacterCreator.Models;

namespace DndCharacterCreator.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<ClassTable> ClassTables { get; set; }

    public virtual DbSet<RaceTable> RaceTables { get; set; }

    public virtual DbSet<SpecifiedClass> SpecifiedClasses { get; set; }

    public virtual DbSet<StatTable> StatTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ttrpg;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("character_pkey");

            entity.ToTable("character");

            entity.HasIndex(e => e.CharacterName, "character_character_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CharacterName)
                .HasMaxLength(25)
                .HasColumnName("character_name");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Hp).HasColumnName("hp");
            entity.Property(e => e.Languages).HasColumnName("languages");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Race).HasColumnName("race");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Stats).HasColumnName("stats");
            entity.Property(e => e.Xp)
                .HasDefaultValue(1)
                .HasColumnName("xp");

            entity.HasOne(d => d.Class).WithMany(p => p.Characters)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("character_class_id_fkey");

            entity.HasOne(d => d.RaceNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Race)
                .HasConstraintName("character_race_fkey");

            entity.HasOne(d => d.StatsNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.Stats)
                .HasConstraintName("character_stats_fkey");
        });

        modelBuilder.Entity<ClassTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("class_table_pkey");

            entity.ToTable("class_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RaceTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_table_pkey");

            entity.ToTable("race_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Size)
                .HasMaxLength(20)
                .HasColumnName("size");
            entity.Property(e => e.SubType)
                .HasMaxLength(20)
                .HasColumnName("sub_type");
            entity.Property(e => e.Traits)
                .HasMaxLength(20)
                .HasColumnName("traits");
        });

        modelBuilder.Entity<SpecifiedClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specified_class_pkey");

            entity.ToTable("specified_class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(25)
                .HasColumnName("class_name");
            entity.Property(e => e.SubClassName)
                .HasMaxLength(25)
                .HasColumnName("sub_class_name");
        });

        modelBuilder.Entity<StatTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stat_table_pkey");

            entity.ToTable("stat_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cha).HasColumnName("cha");
            entity.Property(e => e.Con).HasColumnName("con");
            entity.Property(e => e.Dex).HasColumnName("dex");
            entity.Property(e => e.Inte).HasColumnName("inte");
            entity.Property(e => e.Str).HasColumnName("str");
            entity.Property(e => e.Wis).HasColumnName("wis");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UndergroundApi.Entities;

public partial class OcelotUndergroundContext : DbContext
{
    public OcelotUndergroundContext()
    {
    }

    public OcelotUndergroundContext(DbContextOptions<OcelotUndergroundContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Rapper> Rappers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=ocelot_underground;User id=root;Password=martialemblem152;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rapper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

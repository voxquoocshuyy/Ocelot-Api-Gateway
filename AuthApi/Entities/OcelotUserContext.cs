using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Entities;

public partial class OcelotUserContext : DbContext
{
    public OcelotUserContext()
    {
    }

    public OcelotUserContext(DbContextOptions<OcelotUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=ocelot_user;User id=root;Password=martialemblem152;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleId, "Users_Roles_Id_fk");

            // entity.HasOne(d => d.Role).WithMany(p => p.Users)
            //     .HasForeignKey(d => d.RoleId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("Users_Roles_Id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

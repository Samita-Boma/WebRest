using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Models;

namespace WebRest.EF.Data;

public partial class WebRestOracleContext : DbContext
{
    public WebRestOracleContext(DbContextOptions<WebRestOracleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserPasskeys> AspNetUserPasskeys { get; set; }

    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UD_SAMIBOMA")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<AspNetUserPasskeys>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserPasskeys).HasConstraintName("FK_ASP_NET_USER_PASSKEYS_ASP_NET_USERS_USERID");
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.HasMany(d => d.Role).WithMany(p => p.User)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRoles",
                    r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("ASP_NET_USER_ROLES");
                        j.HasIndex(new[] { "RoleId" }, "IX_ASP_NET_USER_ROLES_ROLE_ID");
                        j.IndexerProperty<string>("UserId").HasColumnName("USER_ID");
                        j.IndexerProperty<string>("RoleId").HasColumnName("ROLE_ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

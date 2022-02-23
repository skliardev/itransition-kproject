using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using project.Domain.Entities;
using System;
using project.Domain.Entities.Review;

namespace project.Domain;

public class AppDbContext : IdentityDbContext<UserAccount>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<UserAccount> DbUserAccounts { get; set; } = null!;
    public DbSet<UserReview> DbUserReviews { get; set; } = null!;
    public DbSet<Image> DbImages { get; set; } = null!;
    public DbSet<Group> DbGroups {get; set; } = null!;
    public DbSet<HashTag> DbHashTags {get; set; } = null!;
    public DbSet<Like> DbLikes {get; set; } = null!;
    public DbSet<Comment> DbComments {get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string roleAdminId = Guid.NewGuid().ToString();
        string roleUserId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = roleAdminId,
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole {
                Id = roleUserId,
                Name = "user",
                NormalizedName = "USER"
            }
        );

        string userAdminId = Guid.NewGuid().ToString();
        string userOneId = Guid.NewGuid().ToString();

        builder.Entity<UserAccount>().HasData(
            new UserAccount {
                Id = userAdminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<UserAccount>().HashPassword(null!, "admin"),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            },
            new UserAccount {
                Id = userOneId,
                UserName = "user",
                NormalizedUserName = "USER",
                PasswordHash = new PasswordHasher<UserAccount>().HashPassword(null!, "user"),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> {
                RoleId = roleAdminId,
                UserId = userAdminId
            },
            new IdentityUserRole<string> {
                RoleId = roleUserId,
                UserId = userOneId
            }
        );

        builder.Entity<Group>().HasData(
            new Group {
                Id = Guid.NewGuid(),
                Name = "Movies",
            },
            new Group {
                Id = Guid.NewGuid(),
                Name = "Books",
            },
            new Group {
                Id = Guid.NewGuid(),
                Name = "Games",
            },
            new Group {
                Id = Guid.NewGuid(),
                Name = "Inventions",
            }
        );
    }
}
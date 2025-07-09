using Microsoft.EntityFrameworkCore;
using PlayedOff.DataAccess.Entities;

namespace PlayedOff.DataAccess;

public sealed class PlayedOffDbContext(DbContextOptions<PlayedOffDbContext> options) : DbContext(options)
{
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
}
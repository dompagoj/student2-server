using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Student2.BL.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int UniversityId { get; set; }
        public University University { get; set; } = null!;

        [JsonIgnore] public override string? NormalizedUserName { get; set; }
        [JsonIgnore] public override string? NormalizedEmail { get; set; }
        [JsonIgnore] public override string? PasswordHash { get; set; } = null!;
        [JsonIgnore] public override string? SecurityStamp { get; set; } = null!;

        [JsonIgnore] public override string? ConcurrencyStamp { get; set; } = null!;

        [JsonIgnore] public override bool PhoneNumberConfirmed { get; set; }
        [JsonIgnore] public override bool TwoFactorEnabled { get; set; }
        [JsonIgnore] public override DateTimeOffset? LockoutEnd { get; set; } = null!;
        [JsonIgnore] public override bool LockoutEnabled { get; set; }
        [JsonIgnore] public override int AccessFailedCount { get; set; }

        // [JsonIgnore] public override string? PhoneNumber { get; set; }

        public AppUser() { }
    }
}

using System;
using System.Collections.Generic;

namespace AuthApi.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Scopes { get; set; }

    public string Password { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}

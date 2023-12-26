﻿using System;
using System.Collections.Generic;

namespace AuthApi.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Code { get; set; }

    // public virtual ICollection<User> Users { get; set; } = new List<User>();
}

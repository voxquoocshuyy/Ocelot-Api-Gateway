using System;
using System.Collections.Generic;

namespace UndergroundApi.Entities;

public partial class Rapper
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Squad { get; set; } = null!;
}

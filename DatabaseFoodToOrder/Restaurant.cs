using System;
using System.Collections.Generic;

namespace FoodToOrderAppWPF;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Rname { get; set; } = null!;

    public bool Ropen { get; set; }

    public int UserId { get; set; }
}

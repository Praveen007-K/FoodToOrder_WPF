using System;
using System.Collections.Generic;

namespace FoodToOrderAppWPF;

public partial class Dish
{
    public int Id { get; set; }

    public string DishName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool Availability { get; set; }

    public int RestaurantId { get; set; }
}

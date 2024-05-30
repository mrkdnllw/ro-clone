using System;
using System.Collections.Generic;

namespace ROCloneAPI.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace ROCloneAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }
}

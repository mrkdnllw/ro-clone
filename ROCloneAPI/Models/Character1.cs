using System;
using System.Collections.Generic;

namespace ROCloneAPI.Models;

public partial class Character1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Class { get; set; } = null!;

    public int Hp { get; set; }

    public int Sp { get; set; }

    public int Atk { get; set; }

    public int Def { get; set; }

    public int Aspd { get; set; }

    public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
}

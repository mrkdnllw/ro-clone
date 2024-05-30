using System;
using System.Collections.Generic;

namespace ROCloneAPI.Models;

public partial class Monster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Hp { get; set; }

    public int Atk { get; set; }

    public int Def { get; set; }

    public int Matk { get; set; }

    public int Aspd { get; set; }

    public virtual ICollection<Character1> Chars { get; set; } = new List<Character1>();
}

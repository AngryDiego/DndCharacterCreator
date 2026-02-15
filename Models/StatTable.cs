using System;
using System.Collections.Generic;

namespace DndCharacterCreator.Models;

public partial class StatTable
{
    public int Id { get; set; }

    public int? Str { get; set; }

    public int? Dex { get; set; }

    public int? Con { get; set; }

    public int? Wis { get; set; }

    public int? Inte { get; set; }

    public int? Cha { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}

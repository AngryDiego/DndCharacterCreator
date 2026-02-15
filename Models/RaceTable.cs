using System;
using System.Collections.Generic;

namespace DndCharacterCreator.Models;

public partial class RaceTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Size { get; set; }

    public string? SubType { get; set; }

    public string? Traits { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}

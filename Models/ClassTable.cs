using System;
using System.Collections.Generic;

namespace DndCharacterCreator.Models;

public partial class ClassTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}

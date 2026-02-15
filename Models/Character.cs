using System;
using System.Collections.Generic;

namespace DndCharacterCreator.Models;

public partial class Character
{
    public int Id { get; set; }

    public string CharacterName { get; set; } = null!;

    public int? ClassId { get; set; }

    public int? Race { get; set; }

    public int? Level { get; set; }

    public int? Xp { get; set; }

    public int Hp { get; set; }

    public string? Languages { get; set; }

    public int? Speed { get; set; }

    public int? Stats { get; set; }

    public virtual ClassTable? Class { get; set; }

    public virtual RaceTable? RaceNavigation { get; set; }

    public virtual StatTable? StatsNavigation { get; set; }
}

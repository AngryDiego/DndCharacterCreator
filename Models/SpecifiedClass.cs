using System;
using System.Collections.Generic;

namespace DndCharacterCreator.Models;

public partial class SpecifiedClass
{
    public int Id { get; set; }

    public string? ClassName { get; set; }

    public string? SubClassName { get; set; }
}

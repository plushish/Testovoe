using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Company
{
    public int Id { get; set; }

    public required string NameFull { get; set; } = null!;

    public required string NameShort { get; set; } = null!;

    public required int Inn { get; set; }

    public string? Ogrn { get; set; }

    public required DateOnly CreationDate { get; set; }

    public required DateOnly ChangeDate { get; set; }
}

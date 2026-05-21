using System;
using System.Collections.Generic;

namespace HrizotilApp.Models;

public partial class Quality
{
    public int Id { get; set; }

    public DateOnly DateQuality { get; set; }

    public string IdProduct { get; set; } = null!;

    public int? Sieve135mm { get; set; }

    public int? Dust { get; set; }

    public int? Pk075mm { get; set; }

    public virtual Product Product { get; set; } = null!;
}

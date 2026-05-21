using System;
using System.Collections.Generic;

namespace HrizotilApp.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public int IdGroup { get; set; }

    public int? NormSieve135mmMin { get; set; }

    public int? NormDustMax { get; set; }

    public int? NormPk075mmMax { get; set; }

    public int? BulkDensityTarget { get; set; }

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();

    public virtual ICollection<Quality> Qualities { get; set; } = new List<Quality>();

    public virtual ICollection<Remain> Remains { get; set; } = new List<Remain>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}

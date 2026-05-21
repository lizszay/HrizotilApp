using System;
using System.Collections.Generic;

namespace HrizotilApp.Models;

public partial class Remain
{
    public int IdWarehouse { get; set; }

    public string IdProduct { get; set; } = null!;

    public decimal Quantity { get; set; }

    public DateOnly DateStock { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}

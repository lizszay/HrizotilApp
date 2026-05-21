using System;
using System.Collections.Generic;

namespace HrizotilApp.Models;

public partial class Production
{
    public int Id { get; set; }

    public DateOnly DateProduction { get; set; }

    public string IdProduct { get; set; } = null!;

    public int Shift { get; set; }

    public int PlanQuantity { get; set; }

    public decimal FactQuantity { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace HrizotilApp.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string WarehouseName { get; set; } = null!;

    public virtual ICollection<Remain> Remains { get; set; } = new List<Remain>();

    public virtual ICollection<Shipment> ShipmentIdFromWarehouseNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<Shipment> ShipmentIdToWarehouseNavigations { get; set; } = new List<Shipment>();
}

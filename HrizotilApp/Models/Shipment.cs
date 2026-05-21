namespace HrizotilApp.Models;

public partial class Shipment
{
    public int Id { get; set; }

    public DateOnly DateShipment { get; set; }

    public int IdFromWarehouse { get; set; }

    public int IdToWarehouse { get; set; }

    public string IdProduct { get; set; } = null!;

    public decimal Quantity { get; set; }

    public virtual Warehouse FromWarehouse { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse ToWarehouse { get; set; } = null!;
}

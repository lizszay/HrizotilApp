namespace HrizotilApp.Models;

public partial class Group
{
    public int Id { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

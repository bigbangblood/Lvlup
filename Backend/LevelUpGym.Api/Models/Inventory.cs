using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpGym.Api.Models;

public class Item : BaseEntity
{
    [Key]
    public int IdItem { get; set; }
    
    [StringLength(20)]
    public string? Tipo { get; set; } // 'PRODUCTO' or 'MEMBRESIA'
    
    [StringLength(20)]
    public string? Estado { get; set; }

    // Navigation
    public virtual Membership? Membership { get; set; }
}

[NotMapped]
public class Category : BaseEntity
{
    [Key]
    public int IdCategoria { get; set; }
    
    [StringLength(20)]
    public string? Nombre { get; set; }
    
    [StringLength(255)]
    public string? Descripcion { get; set; }
    
    [StringLength(20)]
    public string? Estado { get; set; }
}

[NotMapped]
public class Product : BaseEntity
{
    [Key]
    public int IdProducto { get; set; }
    
    public int? IdCategoria { get; set; }
    
    public int? IdItem { get; set; }
    
    [StringLength(150)]
    public string? Nombre { get; set; }
    
    public decimal? PrecioVenta { get; set; }
    
    [StringLength(255)]
    public string? Descripcion { get; set; }
    
    [StringLength(20)]
    public string? Estado { get; set; }

    // Navigation
    public virtual Item? Item { get; set; }
}

public class Membership : BaseEntity
{
    [Key]
    public int IdMembresia { get; set; }
    
    public int? IdItem { get; set; }
    
    [StringLength(100)]
    public string? Nombre { get; set; }
    
    [StringLength(255)]
    public string? Descripcion { get; set; }
    
    public decimal? Precio { get; set; }
    
    [StringLength(20)]
    public string? Estado { get; set; }

    // Navigation
    public virtual Item? Item { get; set; }
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}

[NotMapped]
public class Provider : BaseEntity
{
    [Key]
    public int IdProveedor { get; set; }
    
    [StringLength(150)]
    public string? Nombre { get; set; }
    
    [StringLength(20)]
    public string? Telefono { get; set; }
    
    [StringLength(150)]
    public string? Email { get; set; }
    
    [StringLength(200)]
    public string? Direccion { get; set; }
    
    [StringLength(20)]
    public string? Estado { get; set; }
}

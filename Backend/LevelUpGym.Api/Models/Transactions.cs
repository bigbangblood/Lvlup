using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpGym.Api.Models;

[NotMapped]
public class Sale : BaseEntity
{
    [Key]
    public int IdVenta { get; set; }
    
    public int? IdCliente { get; set; }
    
    public int? MetodoPago { get; set; }
    
    public DateTime? Fecha { get; set; }
    
    public decimal? Total { get; set; }
}

[NotMapped]
public class SaleDetail : BaseEntity
{
    [Key]
    public int IdDetalle { get; set; }
    
    public int? IdVenta { get; set; }
    
    public int? IdItem { get; set; }
    
    public int? Cantidad { get; set; }
    
    public decimal? PrecioUnitario { get; set; }
    
    public decimal? SubTotal { get; set; }
}

[NotMapped]
public class Purchase : BaseEntity
{
    [Key]
    public int IdCompra { get; set; }
    
    public int? IdProveedor { get; set; }
    
    public int? MetodoPago { get; set; }
    
    public DateTime? Fecha { get; set; }
    
    public decimal? Total { get; set; }
}

[NotMapped]
public class PurchaseDetail : BaseEntity
{
    [Key]
    public int IdDetalle { get; set; }
    
    public int? IdCompra { get; set; }
    
    public int? IdProducto { get; set; }
    
    public int? Cantidad { get; set; }
    
    public decimal? PrecioUnitario { get; set; }
    
    public decimal? Subtotal { get; set; }
}

public class Subscription : BaseEntity
{
    [Key]
    public int IdSuscripcion { get; set; }
    
    public int IdCliente { get; set; }
    
    public int IdMembresia { get; set; }
    
    public int IdEstado { get; set; }
    
    public DateOnly FechaInicio { get; set; }
    
    public DateOnly FechaFin { get; set; }

    // Navigation
    public virtual Client Client { get; set; } = null!;
    public virtual Membership Membership { get; set; } = null!;
    public virtual SubscriptionStatus Status { get; set; } = null!;
}

public class CashMovement : BaseEntity
{
    [Key]
    public int IdMovimiento { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Tipo { get; set; } = null!; // 'INGRESO' or 'EGRESO'
    
    public decimal Monto { get; set; }
    
    public DateTime? Fecha { get; set; }
    
    [StringLength(255)]
    public string? Descripcion { get; set; }
}

[NotMapped]
public class Cart : BaseEntity
{
    [Key]
    public int IdCarrito { get; set; }
    
    public int IdCliente { get; set; }
}

[NotMapped]
public class CartItem : BaseEntity
{
    [Key]
    public int IdCartItem { get; set; }
    
    public int IdCarrito { get; set; }
    
    public int IdProducto { get; set; }
    
    public int Cantidad { get; set; }
}

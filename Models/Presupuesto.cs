public class Presupuesto
{
    private List<PresupuestoDetalle> detalle;

    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public List<PresupuestoDetalle> Detalle { get => detalle;}

    public Presupuesto()
    {
        detalle = new List<PresupuestoDetalle>();
    }

    public void agregarProducto(Producto prod, int Cantidad)
    {
        PresupuestoDetalle pd = new PresupuestoDetalle();
        pd.agregarProducto(prod);
        pd.Cantidad = Cantidad;

        detalle.Add(pd);
    }
    
    // float montoPresupuesto()
    // {

    // }

    // float montoPresupuestoConIVA()
    // {

    // }

    // int cantidadProductos()
    // {

    // }
}
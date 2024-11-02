interface IPresupuestoRepository
{
    public void InsertPresupuesto(Presupuesto p);
    public List<Presupuesto> GetPresupuestos();
    // public void UpdateProducto(int id, string Descripcion, int precio);
    // public Presupuesto GetPresupuesto(int id);
    // public void DeletePresupuesto(int id);
    // public void AgregarProductoAPresupuesto(int id);
}
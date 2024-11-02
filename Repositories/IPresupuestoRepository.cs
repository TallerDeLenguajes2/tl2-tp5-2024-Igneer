interface IPresupuestoRepository
{
    public void InsertPresupuesto(string Descripcion, int precio);
    public void UpdateProducto(int id, string Descripcion, int precio);
    public List<Presupuesto> GetPresupuesto();
    public Presupuesto GetPresupuesto(int id);
    public void DeletePresupuesto(int id);
    public void AgregarProductoAPresupuesto(int id);
}
interface IProductoRepository
{
    public void InsertProducto(Producto p);

    public void UpdateProducto(int id, Producto p);

    public List<Producto> GetProductos();

    public Producto GetProducto(int id);

    public void DeleteProducto(int id);
}
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoFinalBlazor.Data;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IProductoRepositorio productoRepositorio;

        public ProductoServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            productoRepositorio = new ProductoRepositorio(configuration.CadenaConexion);
        }

        public async Task<bool> Actualizar(Producto producto)
        {
            return await productoRepositorio.Actualizar(producto);
        }

        public async Task<bool> Eliminar(Producto producto)
        {
            return await productoRepositorio.Eliminar(producto);
        }

        public async Task<IEnumerable<Producto>> GetLista()
        {
            return await productoRepositorio.GetLista();
        }

        public async Task<Producto> GetPorCodigo(string producto)
        {
            return await productoRepositorio.GetPorCodigo(producto);
        }

        public async Task<bool> Nuevo(Producto producto)
        {
            return await productoRepositorio.Nuevo(producto);
        }
    }
}

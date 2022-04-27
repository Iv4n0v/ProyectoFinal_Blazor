using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoFinalBlazor.Data;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IPedidoRepositorio pedidoRepositorio;

        public PedidoServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            pedidoRepositorio = new PedidoRepositorio(configuration.CadenaConexion);
        }

        public async Task<bool> Actualizar(Pedido pedido)
        {
            return await pedidoRepositorio.Actualizar(pedido);
        }

        public async Task<bool> Eliminar(Pedido pedido)
        {
            return await pedidoRepositorio.Eliminar(pedido);
        }

        public async Task<IEnumerable<Pedido>> GetLista()
        {
            return await pedidoRepositorio.GetLista();
        }

        public async Task<Pedido> GetPorCodigo(string pedido)
        {
            return await pedidoRepositorio.GetPorCodigo(pedido);
        }

        public async Task<bool> Nuevo(Pedido pedido)
        {
            return await pedidoRepositorio.Nuevo(pedido);
        }

  
    }
}


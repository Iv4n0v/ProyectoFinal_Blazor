using Modelos;

namespace ProyectoFinalBlazor.Interfaces
{
    public interface IPedidoServicio
    {
        Task<bool> Nuevo(Pedido pedido);
        Task<bool> Actualizar(Pedido pedido);
        Task<bool> Eliminar(Pedido pedido);
        Task<IEnumerable<Pedido>> GetLista();
        Task<Pedido> GetPorCodigo(string pedido);
    }
}

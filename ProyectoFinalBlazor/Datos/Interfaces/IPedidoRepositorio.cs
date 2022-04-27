using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<bool> Nuevo(Pedido pedido);
        Task<bool> Actualizar(Pedido pedido);
        Task<bool> Eliminar(Pedido pedido);
        Task<IEnumerable<Pedido>> GetLista();
        Task<Pedido> GetPorCodigo(string pedido);
      
    }
}

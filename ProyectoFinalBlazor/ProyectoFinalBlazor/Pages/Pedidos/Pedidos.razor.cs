using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Pedidos
{
    partial class Pedidos
    {
        [Inject] private IPedidoServicio _pedidoServicio { get; set; }

        private IEnumerable<Pedido> pedidoLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            pedidoLista = await _pedidoServicio.GetLista();
        }
    }
}

using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Pedidos
{
    partial class NuevoPedido
    {
        [Inject] private IPedidoServicio pedidoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Pedido pedido = new Pedido();

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(pedido.Codigo) || pedido.Total ==0 || string.IsNullOrEmpty(pedido.IdProducto) || string.IsNullOrEmpty(pedido.Cliente) || pedido.Cantidad==0)
            {
                return;
            }

            bool edito = await pedidoServicio.Nuevo(pedido);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Nuevo Pedido ingresado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Pedido no se pudo guardar", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Pedidos");

        }

        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Pedidos");
        }
    }
}

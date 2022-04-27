using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Pedidos
{
    partial class EditarPedido
    {
        [Inject] private IPedidoServicio _pedidoServicio { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }
        [Parameter] public String Codigo { get; set; }

        Pedido pedido = new Pedido();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                pedido = await _pedidoServicio.GetPorCodigo(Codigo);
            }
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(Convert.ToString(pedido.Total)) || string.IsNullOrEmpty(pedido.IdProducto) || string.IsNullOrEmpty(pedido.Cliente) || string.IsNullOrEmpty(Convert.ToString(pedido.Cliente)))
            {
                return;
            }

            bool edito = await _pedidoServicio.Actualizar(pedido);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Pedido actualizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Pedido no se pudo actualizar", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Pedidos");

        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Pedidos");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que quiere eliminar el registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await _pedidoServicio.Eliminar(pedido);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Pedido eliminado con exito", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Pedidos");
                }
                else
                {
                    await Swal.FireAsync("Error", "Pedido no se pudo eliminar", SweetAlertIcon.Error);
                }
            }
        }
    }
}

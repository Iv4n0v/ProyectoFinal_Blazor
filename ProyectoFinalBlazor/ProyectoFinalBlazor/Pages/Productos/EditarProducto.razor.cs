using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Productos
{
    partial class EditarProducto
    {
        [Inject] private IProductoServicio _productoServicio { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }
        [Parameter] public string Codigo { get; set; }

        Producto producto = new Producto();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                producto = await _productoServicio.GetPorCodigo(Codigo);
            }
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(producto.Codigo) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(Convert.ToString(producto.Precio)) || string.IsNullOrEmpty(Convert.ToString(producto.Precio)) || string.IsNullOrEmpty(Convert.ToString(producto.Existencia)))
            {
                return;
            }

            bool edito = await _productoServicio.Actualizar(producto);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Producto actualizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Producto no se pudo actualizar", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Productos");

        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Productos");
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
                elimino = await _productoServicio.Eliminar(producto);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Producto eliminado con exito", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Productos");
                }
                else
                {
                    await Swal.FireAsync("Error", "Productos no se pudo eliminar", SweetAlertIcon.Error);
                }
            }
        }

    }
}

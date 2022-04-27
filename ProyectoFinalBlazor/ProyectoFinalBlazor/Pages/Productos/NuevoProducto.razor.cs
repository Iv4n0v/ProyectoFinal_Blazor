using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Productos
{
    partial class NuevoProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Producto producto = new Producto();

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(producto.Codigo) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(Convert.ToString(producto.Precio))  || string.IsNullOrEmpty(Convert.ToString(producto.Existencia)))
            {
                return;
            }

            bool inserto = await productoServicio.Nuevo(producto);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "´Producto creado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Producto no se pudo crear", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Productos");

        }

        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos");
        }
    }
}

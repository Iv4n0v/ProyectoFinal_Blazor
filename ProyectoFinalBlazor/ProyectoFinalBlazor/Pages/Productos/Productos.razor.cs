using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalBlazor.Interfaces;

namespace ProyectoFinalBlazor.Pages.Productos
{
    partial class Productos
    {
        [Inject] private IProductoServicio _productoServicio { get; set; }

        private IEnumerable<Producto> productoLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            productoLista = await _productoServicio.GetLista();
        }
    }
}

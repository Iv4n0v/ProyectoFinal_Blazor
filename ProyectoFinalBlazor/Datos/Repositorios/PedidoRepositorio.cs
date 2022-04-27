using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private string CadenaConexion;

        public PedidoRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }


        public async Task<bool> Actualizar(Pedido pedido)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "UPDATE pedido SET Codigo = @Codigo, Cliente = @Cliente, Total = @Total, IdProducto = @IdProducto,Cantidad = @Cantidad WHERE Codigo = @Codigo ;";
                resultado = await conexion.ExecuteAsync(sql, new
                {
                    pedido.Codigo,
                    pedido.Cliente,
                    pedido.Total,
                    pedido.IdProducto,
                    pedido.Cantidad
                });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Eliminar(Pedido pedido)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "DELETE FROM pedido WHERE Codigo = @Codigo;";
                resultado = await conexion.ExecuteAsync(sql, new { pedido.Codigo });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Pedido>> GetLista()
        {
            IEnumerable<Pedido> lista = new List<Pedido>();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT unidad2.pedido.Codigo," +
                    "unidad2.pedido.Cliente," +
                    "unidad2.pedido.Total," +
                    "unidad2.pedido.IdProducto," +
                    "unidad2.producto.Descripcion," +
                    "unidad2.pedido.Cantidad " +
                    "FROM unidad2.pedido " +
                    "JOIN unidad2.producto " +
                    "ON unidad2.pedido.IdProducto = unidad2.producto.Codigo; ";
                lista = await conexion.QueryAsync<Pedido>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Pedido> GetPorCodigo(string codigo)
        {
            Pedido pedido = new Pedido();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM pedido WHERE Codigo = @Codigo;";
                pedido = await conexion.QueryFirstAsync<Pedido>(sql, new { codigo });
            }
            catch (Exception)
            {
            }
            return pedido;
        }

        public async Task<bool> Nuevo(Pedido pedido)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "INSERT INTO pedido (Codigo, Cliente, Total, IdProducto,Cantidad) VALUES (@Codigo, @Cliente, @Total, @IdProducto,@Cantidad)";
                resultado = await conexion.ExecuteAsync(sql, pedido);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Producto> GetPorCodigoProducto(string codigo)
        {
            Producto producto = new Producto();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT Descripcion FROM producto WHERE Codigo = @Codigo;";
                producto = await conexion.QueryFirstAsync<Producto>(sql, new { codigo });
            }
            catch (Exception)
            {
            }
            return producto;
        }   
    }
}

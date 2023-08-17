using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using TiendaAPI.DAL;
using TiendaAPI.Modelo;

namespace TiendaAPI.Servicios
{
    public class DProductos
    {
        ConexionBD cn = new ConexionBD();
        public async Task <List<MProductos>> mostrarProductos()
        {
            var list = new List<MProductos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var items = await cmd.ExecuteReaderAsync())
                    {
                        while (await items.ReadAsync())
                        {
                            var mproductos = new MProductos();
                            mproductos.id = (int)items["id"];
                            mproductos.descripcion = (string)items["descripcion"];
                            mproductos.precio = (decimal)items["precio"];
                            list.Add(mproductos);
                        }
                    }
                }
            }
            return list;
        }
        public async Task insertarProductos(MProductos parametros)
        {
            using(var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using(var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task editarProductos(MProductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task eliminarProductos(MProductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

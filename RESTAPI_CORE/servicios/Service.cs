
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

using RESTAPI_CORE.Modelos;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RESTAPI_CORE.servicios

{
    public class Service
    {

        



        public static  List<Cliente> Listar(string cadenaSQL)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_clientes", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Cliente
                            {
                                identifiacion = rd["id"].ToString(),
                                nombre = rd["Nombre"].ToString(),
                                correo = rd["correo"].ToString(),
                                monto = rd["monto"].ToString(),
                            });
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                return lista;

            }


        }
    }
}

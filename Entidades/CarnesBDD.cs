﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductosNs;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Entidades
{
    public static class CarnesBDD
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;
        //static SqlDataReader dataReader;

        static CarnesBDD()
        {
            connectionString = @"Data Source = DESKTOP-KSE67HS;
                                Database = UTN_D2;
                                Trusted_Connection = True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        //public static List<Carne> Leer()
        //{
        //    List<Carne> carnes = new List<Carne>();

        //    try
        //    {
        //        connection.Open();
        //        command.CommandText = "SELECT ID, DESCRIPCION, CORTE, KG_EN_STOCK, PRECIO_POR_KG FROM CARNES";

        //        SqlDataReader dataReader /*= command.ExecuteReader()*/;

        //        using (dataReader = command.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                carnes.Add(new Carne(Convert.ToInt32(dataReader["id"]),
        //                                         (float)dataReader.GetDouble(dataReader.GetOrdinal("PRECIO_POR_KG")),
        //                                         Convert.ToInt32(dataReader["KG_EN_STOCK"]),
        //                                         dataReader["DESCRIPCION"].ToString(),
        //                                         dataReader["CORTE"].ToString()));
        //            }
        //        }

        //        return carnes;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ExcepcionesPropias("Error al leer la base de datos de carnes");
        //    }
        //    finally { connection.Close(); }
        //}

        public static void ModificarCarne(Carne carne)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE PRODUCTOS SET DESCRIPCION = @DESCRIPCION, CORTE = @CORTE WHERE PRODUCTOS.ID = {carne.Id}";
                command.Parameters.AddWithValue("@DESCRIPCION", carne.Animal);
                command.Parameters.AddWithValue("@CORTE", carne.Corte);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException || ex is InvalidOperationException || ex is SqlNullValueException || ex is DbException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al modificar el producto", innerExceptions);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivarTexto
    {
        //static string facturaTxt = "Factura.txt";
        //static string todaFacturaTxt = "todaFactura.txt";
        static StreamWriter streamWriter;

        public static void GuardarFacturaTexto(string factura, string nombreArchivo)
        {
            try
            {
                if (!File.Exists(nombreArchivo))
                {
                    streamWriter = new StreamWriter(nombreArchivo);
                    streamWriter.Write(factura);
                }
                else
                {
                    streamWriter = new StreamWriter(nombreArchivo, true);
                    streamWriter.Write(factura);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                if (streamWriter is not null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
        public static string AbrirFacturaTexto(string nombreArchivo)
        {
            string factura = "";

            try
            {
                if (File.Exists(nombreArchivo))
                {
                    factura = File.ReadAllText(nombreArchivo);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return factura;
        }
    }
}

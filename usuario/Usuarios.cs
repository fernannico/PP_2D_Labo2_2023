﻿using ProductosNs;

namespace usuarios
{
    public abstract class Usuario
    {
        protected string mail;
        protected string contrasena;

        protected Usuario(string mail, string contrasena)
        {
            this.mail = mail;
            this.contrasena = contrasena;
        }

        protected virtual string MailPropiedad
        {
            get { return mail; }
        }

        protected virtual string PwdPropiedad
        {
            get { return contrasena; }
        }
    }

    public class Vendedor : Usuario
    {
        //● Puede vender productos seleccionando a un cliente de la lista de clientes.
        //● Puede ver los detalles de los productos
        //● Puede reponer los productos de la heladera principal
        //● Fijar precios por kilo
        //● Fijar tipos de cortes de carnes
        public Vendedor(string mail, string contrasena) : base(mail, contrasena)
        {

        }

        public override string ToString()
        {
            return $"Vendedor - {mail}";
        }

        public void FijarPrecioKg(Productos producto, float nuevoPrecio)
        {
            if (producto is not null && nuevoPrecio > 0) 
                producto.PrecioPropiedad = nuevoPrecio;
        }
        public void FijarCorteDeCarne(Carne carneItem, string corte)
        {
            if( carneItem is not null && corte is not null)
            {
                carneItem.CortePropiedad = corte;
            }
        }
        public void ReponerProductos(Productos producto, int kgAReponer)
        {
            producto.KgEnStockPropiedad = producto.KgEnStockPropiedad + kgAReponer;
        }
        public string VerDetallesProducto(Productos producto)
        {
            return producto.MostrarDetalle();
        }
    }

    public class Cliente : Usuario
    {
        int gastoMaximo;
        public Cliente(string mail, string contrasena) : base(mail, contrasena)
        {

        }
        public int GastoMaximoPropiedad
        {
            get { return gastoMaximo; }
            set { gastoMaximo = value; }
        }
        public override string ToString()
        {
            return $"Cliente - {mail}";
        }
         
    }
}
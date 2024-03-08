using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class HabitacionHotel:Alojamiento
    {
        int nroHabitacion;
        string tipo;
        int estrellas;
        string nombre;
        public int NroHabitacion
        {
            set {
                if (value > 0)
                    nroHabitacion = value;
            }
            get { return nroHabitacion; }
        }
        public string Tipo
        {
            set {
                if (value==null||value.Length > 0)
                    tipo = value; 
            }
            get { return tipo; }
        }
        public int Estrellas
        {
            set {
                if (value > 0)
                    estrellas = value; 
            }
            get { return estrellas; }
        }
        public string Nombre
        {
            get { return nombre; }
        }
      
        public HabitacionHotel(
            string dir, 
            ref int nroPro, 
            double pb, 
            string tipo,
            int estrellas,
            string nom,
            Propietario p,
            string ciudad
        ):base(dir,ref nroPro,pb,p, ciudad)
        {
            this.tipo = tipo;
            this.estrellas = estrellas;
            this.nombre = nom;
        }
        public HabitacionHotel(int nroPro): base( nroPro){}

        public override Reserva Reservar(DateTime inicio, DateTime egreso, ref int contReservas, int cantPersonas, Cliente reservante)
        {
            try
            {
                if (cantPersonas > base.MaxCantHuespedes)
                    throw new Exception("La cantidad de personas excede el límite del alojamiento");
                Reserva aux=null;    
                int[,] auxDres= new int[diasFaltantes, 2];

                Array.Copy(diasReservados, auxDres, diasFaltantes);                
                bool correcto = Reservar(inicio, egreso, ref auxDres);
                if (correcto)
                {
                    contReservas++;
                    Array.Copy(auxDres, diasReservados, diasFaltantes);
                    aux = new Reserva(inicio, egreso,contReservas, cantPersonas, reservante);
                    aux.Alojamiento = this;
                    base.reservas.Add(aux);
                    
                }
                else
                {
                    throw new Exception("Has seleccionado días ya reservados");
                }
                return aux;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Te retorna la base del precio
        public override double CalcularPrecio()
        {
            double precoTotal = PrecioBase;
            //Segun el tamaño de la habitacion
            if(this.tipo=="doble")
                precoTotal += PrecioBase*0.8;
            else if (this.tipo == "triple")
                precoTotal+= PrecioBase * 1.5;

            //3 estrellas
            if(this.estrellas==3)
                precoTotal+=PrecioBase * 0.4;


            return precoTotal;
        }
        public override string ToString()
        {
            return $"Hotel {nombre} ({estrellas} Estrellas), Habitación {tipo} n° {nroHabitacion} - {base.ToString()}";
        }

        public override string Info()
        {
            return $"HabitacionHotel;{Direccion};{PrecioBase};{tipo};{estrellas};{nombre};{Propietario.Nombre};{Propietario.Apellido};{Propietario.Dni};{MaxCantHuespedes};{NroHabitacion};{Ciudad};{base.InformacionServicios()}";
        }
    }
}

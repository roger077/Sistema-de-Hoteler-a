using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class Casa:Alojamiento
    {
        int minimoDias;
        //List<string> servicios = new List<string>();
        public int MinimoDias
        {
            set 
            {
                if(value>0)
                    minimoDias = value; 
            }
            get { return minimoDias; }
        }   

        public Casa(string dir, ref int nroPro, double pb, Propietario p, string ciudad) : base(dir, ref nroPro, pb, p, ciudad) { }
        public Casa(int nroPro):base(nroPro) { }

        public override double CalcularPrecio()
        {
            return PrecioBase;
        }

        public override Reserva Reservar(DateTime inicio, DateTime egreso, ref int contReservas, int cantPersonas,Cliente reservante)
        {
            try
            {
                if (cantPersonas > base.MaxCantHuespedes)
                    throw new Exception("La cantidad de personas excede el límite del alojamiento");
                Reserva aux = null;
                int[,] auxDres = new int[diasFaltantes, 2];
                int cantDias = (egreso - inicio).Days;
                if (cantDias+1 < minimoDias)
                    throw new Exception($"Se puede reservar durante {minimoDias} días como mínimo");
                Array.Copy(diasReservados, auxDres, diasFaltantes);

                bool correcto = Reservar(inicio, egreso, ref auxDres);

                if (correcto)
                {
                    contReservas++;
                    Array.Copy(auxDres, diasReservados, diasFaltantes);
                    aux = new Reserva(inicio, egreso, contReservas, cantPersonas, reservante);
                    aux.Alojamiento = this;
                    reservas.Add(aux);
                }
                else
                {
                    throw new Exception("Has seleccionado días ya reservados");
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
#pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        public void AgregarServicio(string servicio)
#pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        {
            servicios.Add(servicio);
        }
        public override string ToString()
        {
            return $"Casa - {base.ToString()}";
        }
        public override string Info()
        {
            return $"Casa;{Direccion};{PrecioBase};{Propietario.Nombre};{Propietario.Apellido};{Propietario.Dni};{MaxCantHuespedes};{MinimoDias};{base.Ciudad};{base.InformacionServicios()}";
        }
    }
}

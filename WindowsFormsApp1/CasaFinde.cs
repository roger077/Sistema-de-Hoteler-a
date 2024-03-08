using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class CasaFinde : Casa
    {
        public CasaFinde(string dir, ref int nroPro, double pb, Propietario p, string ciudad) : base(dir, ref nroPro, pb, p, ciudad) { }
        public CasaFinde(int nroPro) : base(nroPro) { }
        public override Reserva Reservar(DateTime inicio, DateTime egreso, ref int contReservas, int cantPersonas, Cliente reservante)
        {
            try
            {

                Reserva re = null;
                if (((int)inicio.DayOfWeek) > 4 && ((int)egreso.DayOfWeek) < 8)
                {
                    re = base.Reservar(inicio, egreso, ref contReservas, cantPersonas, reservante);
                }
                else
                {
                    throw new Exception("Este alojamiento solo se puede reservar durante fines de semana");
                }
                return re;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return $"Casa fin de semana - ${base.ToString()}";
        }
        public override string Info()
        {
            //string[] serv = new string[5];
            //return $"CasaFinde;{Direccion};{PrecioBase};{Propietario.Nombre};{Propietario.Apellido};{Propietario.Dni};{MaxCantHuespedes};{Ciudad};{base.Info()}";
            return $"CasaFinde;{Direccion};{PrecioBase};{Propietario.Nombre};{Propietario.Apellido};{Propietario.Dni};{MaxCantHuespedes};{Ciudad};{base.Info()}";
        }
    }
}

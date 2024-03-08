using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class Reserva : IComparable
    {
        int cantDias;
        int codReserva;
        int cantPersonas;
        DateTime realizacion;
        DateTime ingreso;
        DateTime egreso;
        Alojamiento alojamiento;
        List<Cliente> huespedes = new List<Cliente>();
        Cliente reservante;

        //Constructor
        public Reserva(DateTime ing, DateTime egr, int c, int cantPersonas, Cliente reservante)
        {

            realizacion = DateTime.Now;
            ingreso = ing;
            egreso = egr;
            codReserva = c;
            this.cantDias = egr.Subtract(ing).Days;
            this.reservante = reservante;
            huespedes.Add(reservante);
            this.cantPersonas = cantPersonas;
        }

        public Cliente Reservante
        {
            get { return reservante; }
        }

        //Calcula el costo total segun dias, etc
        public double CostoTotal
        {
            get {
                double costoTotal = 0;

                //Si es hotel
                if (Alojamiento is HabitacionHotel)
                    costoTotal = alojamiento.CalcularPrecio() * cantDias + cantDias * alojamiento.CalcularPrecio() * 0.03;

                //Si es casa
                else if (Alojamiento is Casa)
                {   

                    if (cantDias <= ((Casa)Alojamiento).MinimoDias)
                    {
                        costoTotal = alojamiento.CalcularPrecio() * cantDias;
                    }
                    else
                    {
                        int diasExtra = (cantDias - ((Casa)Alojamiento).MinimoDias);

                        double precioBase = alojamiento.CalcularPrecio();

                        costoTotal = precioBase * ((Casa)Alojamiento).MinimoDias - diasExtra * (precioBase * 0.03);

                    }
                }
                return costoTotal;
            }
        }

        public DateTime Ingreso {
            get {
                return ingreso;
            }
            set
            {
                if (value != null)
                    ingreso = value;
            }
        }
        public DateTime Egreso 
        { 
            get 
            { 
                return egreso; 
            }
            set
            {
                if (value != null)
                    egreso = value;
            }
        }

        //Retorna la lista de huespedes
        public List<Cliente> Huespedes
        { 
            get {
                return huespedes;
            } 
            private set { } 
        }

        //Te devuelve solamente el precio por dia, no el total
        public double CostoPorDia
        {
            get { return alojamiento.CalcularPrecio(); }
        }

        //El dia que hiciste la reserva
        public DateTime Realizacion
        {
            get { return realizacion; }
        }

        public Alojamiento Alojamiento
        {
            set {
                if(value!=null)
                    alojamiento = value; 
            }
            get { return alojamiento; }
        }


        public int CantDias
        {
            set
            {
                if (value > 0)
                {
                    cantDias = value;
                    egreso = ingreso.AddDays(cantDias);
                }
            }
            get 
            {
                return cantDias;
            }
        }
        
        public int CodReserva
        {
            get { return codReserva; }
        }

        public int CantPersonas
        {
            get { return cantPersonas; }
            set 
            {
                if(value >0)
                    cantPersonas = value; 
            }
        }

        public int CompareTo(Object obj)
        {
            return this.codReserva.CompareTo(((Reserva)obj).CodReserva);
        }

        //Para comboBox, etc
        public override string ToString()
        {
            return $"{codReserva}; {ingreso.Date.Day}/{ingreso.Date.Month}/{ingreso.Year} - {egreso.Date.Day}/{egreso.Date.Month}/{egreso.Year}; {cantPersonas} huéspedes";
        }

        public void AgregarHuesped(Cliente huesped)
        {
            try
            {
                if (huesped == null)
                    throw new Exception("El cliente no puede ser nulo");
                if(huespedes.Count==cantPersonas)
                    throw new Exception("No puedes exceder el límite de huéspedes");

                huespedes.Add(huesped);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Esta es la informacion para cuando exportas
        public string Info()
        {
            return $"Reserva;{ingreso.DayOfYear};{egreso.DayOfYear};{cantPersonas};{reservante.Nombre};{reservante.Apellido};{reservante.Dni}";
        }
    }
}

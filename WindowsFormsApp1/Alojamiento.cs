using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
  
namespace WindowsFormsApp1
{
    [Serializable]
    internal abstract class Alojamiento:IComparable,IPrint
    {
        string direccion;
        string ciudad;
        int nroPropiedad;
        double precioBase;
        protected int diasFaltantes;
        int maxCantHuespedes;

        //diasReservados es una matriz bidimencional que contiene en la columna 0 los dias del año, y en la columna 1 contiene 1 y 0 segun este o no ocupado ese dia
        protected int[,] diasReservados;

        //Lista de los servicios disponibles, es estatico y publico asi podemos acceder desde otra clases, son servicios que cualquier alojamiento podria llegar a tener
        public static string[] serviciosDisponibles = { "Desayuno", "Piscina", "Wifi", "Aire acondicionado", "Cochera" };

        //En esta lista se agregan los string de los servicios que efectivamente tiene el alojamiento
        protected List<string> servicios = new List<string>();

        List<Image> imagenes = new List<Image>();

        Propietario propietario = null;

        protected List<Reserva> reservas = new List<Reserva>();
        public Propietario Propietario { get { return propietario; }  set { if (value != null) propietario = value; } }

        public string Ciudad { get { return ciudad; } private set { } }


        //Devuelve la ultima reserva
        public Reserva UltimaReserva
        {
            get
            {
                return reservas[reservas.Count-1];
            }
            private set
            {

            }
        }


        public Alojamiento(string dir,ref int nroPro, double pb,Propietario prop, string ciudad)
        {
            propietario = prop;
            this.ciudad = ciudad;
            direccion = dir;
            nroPro ++;
            nroPropiedad = nroPro;
            precioBase = pb;

            DateTime fecha = DateTime.Now;
            DateTime fechaTresMeses = fecha.AddMonths(3);
            TimeSpan dif = fechaTresMeses - fecha;

            diasFaltantes = dif.Days;

            //diasFaltantes son los DayOfYear, es decir la columna 0 se va a llenar de por ejemplo numeros como 365 (31 de dicembre) en el for que le sigue
            diasReservados = new int[diasFaltantes, 2];

            //Se creas los diasReservados, como recien se crea todos los dias van a tener 0 en la 1 columna 
            for (int i = 0; i < diasFaltantes; i++)
            {
                diasReservados[i, 0] = i + fecha.DayOfYear;
                diasReservados[i, 1] = 0;
            }
        }

        //Este constructor lo usamos para el binarySearch unicamente
        public Alojamiento(int nroPro)
        {
            nroPropiedad = nroPro;
        }


        //Propiedades
        public string Direccion
        {
            set 
            {
                if(value != null || value.Length>0)
                    direccion = value; 
            }
            get { return direccion; }
        }
        public int NroPropiedad
        {
            private set { }
            get { return nroPropiedad; }
        }
        public List<Image> Imagenes
        {
            get{ return imagenes; } 
        }

        //Retorna todas las reservas una por una, de esta forma no damos acceso a la lista de reservas para que no puedan manipular la lista de Reservas sin antes pasar por las comprobaciones y los metedos encargas de realizar esta accion
        public Reserva[] Reservas
        {
            get {
                Reserva[] retReservas = new Reserva[reservas.Count];

                for (int i = 0; i < reservas.Count; i++)
                    retReservas[i] = reservas[i];
                return retReservas;  
            }
        }

        //La propiedad retorna los servicios que efectivamente el alojamiento tiene
        public List<string> Servicios
        {
            get { return servicios; }
        }

        public double PrecioBase
        {
            set {
                if(value>0)
                    precioBase = value; 
            }
            get { return precioBase; }
        }

        public int MaxCantHuespedes 
        {
            set {
                if(value>0)
                    maxCantHuespedes = value; 
            }
            get { return maxCantHuespedes; }
        }


        //Metodo abstracto para crear las reservas
        public abstract Reserva Reservar(DateTime inicio, DateTime egreso, ref int contReservas, int cantPersonas, Cliente reservante);
        

        //El argumetno de reserva es la nueva supuesta reserva
        //Este metodo modifica la reserva usando una copia de la matriz diasReservados y modificando esta copia, si se puede, retorna un true y se copia a la matriz original. 
        public void ModificarReserva(Reserva reserva)
        {
            try
            {
                
                //reservaAuxiliar va a tener los datos de la reserva original
                Reserva reservaAuxiliar = BuscarReserva(reserva.CodReserva);

                if (reservaAuxiliar != null)
                {
                    //auxDiasRestantes es una matriz que contiene los dias y 0 o 1 si estan ocupados o no.
                    int[,] auxDiasRestantes = new int[diasFaltantes, 2];

                    //Le pasa el array de diasReservados a la auxiliar, para evitar cambios no deseados
                    Array.Copy(diasReservados, auxDiasRestantes, diasFaltantes);

                    int dia = reserva.Ingreso.DayOfYear;

                    int inicial = 0;

                    while (auxDiasRestantes[inicial, 0] != dia)
                        inicial++;

                    int cantDias = (reserva.Egreso - reserva.Ingreso).Days;

                    for (int d = inicial; d < cantDias + inicial; d++)
                    {
                        auxDiasRestantes[d, 1] = 0;                       
                    }

                    //Este metodo modifica los dias con las fechas pasadas y chequea si se puede modificar 
                    bool correcto = Reservar(reserva.Ingreso, reserva.Egreso,ref auxDiasRestantes);

                    if(!correcto)
                        throw new Exception("Has seleccionado días ya reservados");

                    reservaAuxiliar.Ingreso = reserva.Ingreso;
                    reservaAuxiliar.Egreso = reserva.Egreso;
                    reservaAuxiliar.CantDias = reserva.CantDias;

                    //Se copia el auxiliar que tiene las fechas modificadas al diasReservados que pertenece al alojamiento y contiene todas las fechas ocupadas. Se copian todas las fechas
                    Array.Copy(auxDiasRestantes, diasReservados, diasFaltantes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Este metodo se encarga de cambiar los dias reservados de 1 a 0, el "maestro" de este metodo es DarDeBajaReserva
        void CancelarReserva(Reserva r)
        {
            int dia = r.Ingreso.DayOfYear;
            int inicial = 0;

            //La razon de este while es para calcular en que posicion del vector se encuentra el dia donde arranca la reserva. Por ejemplo si vos reservaste el 23 de diciembre significa que en el vector sera la posicion 9 (Hoy 13 de diciembre)
            while (diasReservados[inicial, 0] != dia && inicial<diasReservados.GetLength(1))
                inicial++;

            int cantDias = (r.Egreso - r.Ingreso).Days;

            //Como explicamos arriba, en el ejemplo que redactamos, el for va a empezaria en la posicion 9
            for (int d = inicial; d < cantDias + inicial; d++)
            {
                diasReservados[d, 1] = 0;
            }
        }

        //Le pasomos la referencia de los dias restantes para poder modificar los 0 y 1 de la matriz de los dias restantes
        protected bool Reservar(DateTime inicio, DateTime egreso, ref int[,] diasRestantes)
        {
            bool correcto = true;

            int dia = inicio.DayOfYear;
            
            int cantDias = (egreso - inicio).Days;

            //Depende de la reserva, la fecha inicial cambia. Ej la matriz arranca en 0 con el dia 50 del año, y vos le estas pasando una reserva que arranca el dia 60. 
            int inicial = 0;
            while (diasRestantes[inicial, 0] != dia)
                inicial++;

            //Arranca la matriz en el dia incial y llega hasta el dia final, cantDias + inicial es porque si vos te hospedas 9 dias y el dia inicial del año es el 350, entonces el for tiene que llegar a 359 dias
            for (int diaInicial = inicial; diaInicial < cantDias + inicial && correcto; diaInicial++)
            {
                if (diasRestantes[diaInicial, 1] == 0) diasRestantes[diaInicial, 1] = 1;
                else correcto = false;
            }
            return correcto;
        }

        //La razon de este metodo es que a diferencia del de arriba no modifica los dias
        public bool ChequearDisponibilidad(DateTime inicio, DateTime egreso)
        {
            bool correcto = true;
            int inicial = 0;

            int dia = inicio.DayOfYear;
    
            int cantDias = (egreso - inicio).Days;


            while (diasReservados[inicial, 0] != dia && inicial < diasReservados.GetLength(1))
                inicial++;

            for (int d = inicial; d < cantDias + inicial && correcto; d++)
            {
                //Cuando es distinto de 0 significa que esta ocupado
                if (diasReservados[d, 1] != 0)
                {
                    correcto = false;
                }
            }
            return correcto;

        }

        //Este metodo da de baja la reserva 
        public void DarDeBajaReserva(int cod)
        {
            try
            {
                Reserva reserva = BuscarReserva(cod);

                if (reserva == null)
                    throw new Exception("Reserva no encontrada");

                CancelarReserva(reserva);
                reservas.Remove(reserva);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para buscar la reserva con BinarySearch
        Reserva BuscarReserva(int cod)
        {
            Reserva aBuscar = new Reserva(DateTime.Now, DateTime.Now, cod,0,null);
            Reserva ret = null;

            reservas.Sort();

            int orden = reservas.BinarySearch(aBuscar);

            if (orden >= 0)
                ret = reservas[orden];

            return ret;
        }

        public abstract double CalcularPrecio();
        
        //Este metodo sirve para agregar imagenes al respectivo 
        public void AgregarImagen(Image img)
        {
            try
            {
                imagenes.Add(img);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarServicio(string s)
        {
            servicios.Add(s);
        }

        public int CompareTo(object obj)
        {
            return this.nroPropiedad.CompareTo(((Alojamiento)obj).NroPropiedad);
        }

        public double GananciasTotaes()
        {
            double acumGan=0;

            foreach (Reserva r in reservas)
                acumGan += r.CostoTotal;

            return acumGan;
        }

        public override string ToString()
        {
            return $"Ciudad: {ciudad}, Dirección: {direccion}, Precio ${CalcularPrecio()}, Propietario: {propietario.Nombre} {propietario.Apellido} - {propietario.Dni}";
        }
   

        //Devuelve 0 y 1 segun que servicios tenga el alojamiento, para exportar 
        public string InformacionServicios()
        {
            string[] auxServ = new string[5];
            

            for(int i = 0; i < serviciosDisponibles.Length; i++)
            {
                bool encontrado = false;


                for(int j = 0; j < servicios.Count && !encontrado; j++)
                {
                    //Compara si el servicio[i] es igual a los servicios que efectivamente tenes, Si encuentra el servicio en la lista efectiva de servicios devuelve true
                    if (serviciosDisponibles[i] == servicios[j])
                        encontrado = true;
                }

                if (encontrado)
                {
                    auxServ[i] = "1";
                }
                else
                {
                    auxServ[i] = "0";
                }
            }
            return $"{auxServ[0]};{auxServ[1]};{auxServ[2]};{auxServ[3]};{auxServ[4]}";
        }

        public abstract string Info();


        //Interfaz que
        public string Print()
        {
            //La razon de un stringBuilder es porque va acambiar muchas veces asi evitamos tener que estar creando muchos string 
            StringBuilder datos = new StringBuilder();

            foreach(Reserva reserva in reservas)
            {
                datos.AppendLine($"{reserva.Alojamiento.NroPropiedad};{reserva.Reservante.Dni};{reserva.Ingreso};{reserva.Egreso}");

                //Se escribe tambien el dni, nombre y apellido del reservante ya que se lo considera tambien como cliente
                foreach (Cliente cliente in reserva.Huespedes)
                {
                    datos.AppendLine($"{cliente.Dni};{cliente.Nombre};{cliente.Apellido}");
                }
            }

            return datos.ToString();
        }

    }
}

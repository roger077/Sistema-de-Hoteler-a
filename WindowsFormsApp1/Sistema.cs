using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [Serializable]
    internal class Sistema
    {

        Dictionary<string, string> usuarios = new Dictionary<string, string> ();



        List<Alojamiento> alojamientos = new List<Alojamiento>();
        //List<Reserva> reservas = new List<Reserva>();
        int contReservas =0;

        List<string> ciudades = new List<string>();


        public Sistema()
        {
            usuarios.Add("admin", "admin");
            usuarios.Add("pedro", "1234");
        }
        public bool AgregarUsuarios(string usuario, string contraseña)
        {
            bool result = false;
            if (!usuarios.ContainsKey(usuario))
            {
                usuarios.Add(usuario, contraseña);
                result = true;
            }
            else
            {
                throw new Exception("Este nombre de usuario esta ocupado.");
            }
            return result;
        }
        public bool CambiarContraseña(string usuario, string contraseña, string nuevaContraseña)
        {
            bool result = false;
            if (usuarios.ContainsKey(usuario))
            {
                if (usuarios[usuario]==contraseña)
                {
                    usuarios[usuario] = nuevaContraseña;
                    result = true;
                }
            }
            else
            {
                throw new Exception("Usuario/Contraseña incorrecta. Intente de nuevo!");
            }
            
            return result;
        }
        public Dictionary<string, string> Usuarios
        {
            get
            {
                return usuarios;
            }
        }
        public List<string> Ciudades
        {
            get
            {
                return ciudades;
            }
            private set
            {

            }
            
        }


        public string DireccionIcon
        {
            get { return $"{Application.StartupPath}\\icon.png"; }
        }

        public bool AgregarCiudad(string ciudad)
        {
            //Si ciudades no contiene a la nueva, la agrega
            bool ret = false;
            if (!ciudades.Contains(ciudad))
            {
                ciudades.Add(ciudad);
                ret=true;
            }
            return ret;
        }


        //Agrega a la lista de alojamientos
        public void AgregarAlojamiento(Alojamiento alojamiento)
        {
            alojamientos.Add(alojamiento);
        }

        //Retorna un vector de alojamientos para evitar que puedan modificar la lista
        public Alojamiento[] Alojamientos
        {
            get
            {
                Alojamiento[] al = new Alojamiento[alojamientos.Count];
                for (int i = 0; i < alojamientos.Count; i++)
                    al[i] = alojamientos[i];
                return al;
            }       
        }

        //Modifica los alojamientos
        public void ModificarAlojamiento(Alojamiento alojamiento)
        {
            try
            {
                //La razon de no utilizar directamente el alojamiento pasado como argumento es que asi verificamos que este pasando un alojamiento que efectivamente este en la inmobiliria
                Alojamiento aux = BuscarAlojamiento(alojamiento.NroPropiedad);
                if (aux != null)
                {
                    //Los sets de las propiedades de alojamiento se encargan de que no tengan errores
                    aux.Direccion = alojamiento.Direccion;
                    aux.PrecioBase = alojamiento.PrecioBase;
                    aux.MaxCantHuespedes = alojamiento.MaxCantHuespedes;

                    if(aux is Casa)
                    {
                        Casa auxCasa = (Casa)aux;
                        auxCasa.MinimoDias = ((Casa)alojamiento).MinimoDias;

                    }

                    else if(aux is HabitacionHotel)
                    {
                        HabitacionHotel auxHotel = (HabitacionHotel)aux;
                        auxHotel.Estrellas = ((HabitacionHotel)alojamiento).Estrellas;
                    }
                }

                else
                {
                    throw new Exception("Alojamiento no encontrado");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BinarySearch para encontrar alojamiento
        public Alojamiento BuscarAlojamiento(int nroProp)
        {
            Casa c = new Casa(nroProp);
            Alojamiento aBuscar=null;
            alojamientos.Sort();
            int orden = alojamientos.BinarySearch(c);
            if (orden >= 0)
                aBuscar = alojamientos[orden];
            return aBuscar;
        }


        public void DarDeBajaAlojamiento(int nroProp)
        {
            try
            {
                Alojamiento aBorrar = BuscarAlojamiento(nroProp);
                if (aBorrar == null)
                {
                    throw new Exception("Alojamiento no encontrado");
                }
                else
                {
                    alojamientos.Remove(aBorrar);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Agrega una reserva al alojamiento de parametro
        public void Reservar(Alojamiento alojamiento, DateTime inicio, DateTime egreso, int cantPersonas, Cliente reservante)
        {
            try
            {
                if (alojamiento == null)
                    throw new Exception("Debes indicar el alojamiento para reservar");

                //Chequea si egreso e ingreso son el mismo dia
                if (inicio.DayOfYear == egreso.DayOfYear)
                {
                    throw new Exception("La reserva debe durar una noche al menos");
                }
                if (!(inicio<DateTime.Now))
                {
                    Reserva nuevaR = alojamiento.Reservar(inicio, egreso, ref contReservas, cantPersonas, reservante);

                    nuevaR.Alojamiento = alojamiento;
                }
                else
                {
                    MessageBox.Show("Hubo una reserva importada que usaba fechas del pasado");
                }



            }catch(Exception ex)
            {
                throw ex;
            }

        }



        public void ModificarReserva(Alojamiento alojamiento, Reserva reserva)
        {
            try
            {
                if (alojamiento == null)
                {
                    throw new Exception("Alojamiento incorrecto");
                }
                //Le pasamos pasamos la que se supone, si todo es validado, sera la nueva reserva 
                alojamiento.ModificarReserva(reserva);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
        //Dar de baja con btnInhabilitar 
        public void DarDeBajaReserva(Alojamiento al, Reserva res)
        {
            try
            {
                if (al == null)
                    throw new Exception("Alojamiento incorrecto");

                al.DarDeBajaReserva(res.CodReserva);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

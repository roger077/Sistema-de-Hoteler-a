using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
#pragma warning disable CS0105 // La directiva using apareció anteriormente en este espacio de nombre
#pragma warning restore CS0105 // La directiva using apareció anteriormente en este espacio de nombre
using System.IO;
//using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        int contAlojamientos = 0;

        Regex regexNumerica = new Regex(@"^[1-9]\d*$");

        Sistema miSistema = new Sistema();
        BinaryFormatter datos = new BinaryFormatter();
        bool admin;
        bool usuarioCorrecto;

        //Este metodo sirve para cosas secretas
        public void BloquearTodo()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            menuStrip1.Enabled = false;
        }

        //El Load del Form tiene multiples funciones, 1-La persistencia de datos, carga los datos anteriormente creados si existen 2-Se encarga de la parte de loggeo a la aplicacion
        private void Form1_Load(object sender, EventArgs e)
        {
            //Carga los datos, esto es asi porque necesita saber y tener acceso al diccionario de usuarios
            string direccion = Application.StartupPath + "\\datos.txt";
            if (File.Exists(direccion))
            {
                FileStream archivo = new FileStream(direccion, FileMode.Open, FileAccess.Read);
                miSistema = (Sistema)datos.Deserialize(archivo);
                archivo.Close();

                foreach (Alojamiento alojamiento in miSistema.Alojamientos)
                {
                    cbAlojamiento.Items.Add(alojamiento);

                }
                foreach (string ciudad in miSistema.Ciudades)
                {
                    cbCiudades.Items.Add(ciudad);
                }

            }
            else
            {
                miSistema = new Sistema();
            }


            //Comprobacion de usuarios
            FormUsuarios formUsuarios = new FormUsuarios();

            bool bandera = false;

            //La razon de este bool es para que por si fallan, los enable = false, igualmente un no admin no pueda agregar usuarios
            admin = false;

            int intentos = 0;

            Dictionary<string, string> usuarios = miSistema.Usuarios;

            //Este While sirve para que puedas ingresar varias veces la contraseña si te equivocas
            while (!bandera)
            {
                intentos++;

                DialogResult dialogResult = formUsuarios.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {


                    string usuario = formUsuarios.tbUsuario.Text;
                    string contraseña = formUsuarios.tbUsuario.Text;

                    if (usuarios.ContainsKey(usuario))
                    {
                        if (usuarios[usuario] == contraseña)
                        {
                            bandera = true;
                            usuarioCorrecto = true;

                            //La razon de usuario admin es que solo puede haber una Key con un valor en concreto, por lo tanto no va a haber muchos admin porque no se puede
                            if (usuario == "admin")
                            {
                                admin = true;
                            }
                            else
                            {
                                btnInRes.Enabled = false;
                                btnDarBajaAl.Enabled = false;
                                btnAgregarAlojamiento.Enabled = false;
                                crearUsariosToolStripMenuItem.Enabled = false;
                                btnImportar.Enabled = false;
                            }

                        }

                    }
                    if (usuarioCorrecto == false)
                    {
                        if (intentos <= 4)
                        {
                            MessageBox.Show("Usuario Incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (intentos > 4)
                        {
                            MessageBox.Show($"Usuario Incorrecto, le quedan {7 - intentos} intentos ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Si le erraste mas de 7 intentos no te deja ingresar y bloquea todo
                            if (intentos == 7)
                            {
                                BloquearTodo();
                                bandera = true;
                            }
                        }
                    }
                }
                //Si cerraste la ventana para iniciar sesion te bloquea todo. 
                else
                {
                    DialogResult deseaSeguirIntentado = MessageBox.Show("Esta seguro que no quiere ingresar sesion, no va a poder utlizar ninguna funcion?\n Desea probar una vez mas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deseaSeguirIntentado == DialogResult.No)
                    {
                        BloquearTodo();
                        bandera = true;
                    }


                }


            }

        }

        //Actualiza todo lo visual, le paso obj porque Alojamiento al ser internal, el Form no puede acceder 
        public void Actualizar_Visual(Object obj)
        {
            Alojamiento alojamiento = (Alojamiento)obj;

            lbReservas.Items.Clear();
            lbServicios.Items.Clear();
            btnDarBajaAl.Enabled = true;

            btnAgregarImagen.Enabled = !(alojamiento != null && (alojamiento).Imagenes.Count == 2);

            PintarImagenesSegunAlojamiento(alojamiento);
            PintarReservasSegunAlojamiento(alojamiento);
            PintarLabelSegunAlojamiento(alojamiento);
            btnModificar.Enabled = true;
            btnReservar.Enabled = true;
            btnAgregarImagen.Enabled = true;
        }


        //Este metodo sirve para agregar un nuevo alojamiento
        private void btnAgregarAlojamiento_Click(object sender, EventArgs e)
        {
            try
            {

                Falojamiento ventanaAlojamiento = new Falojamiento();
                if (ventanaAlojamiento.ShowDialog() == DialogResult.OK)
                {
                    //Verificaciones de textBox
                    if (ventanaAlojamiento.tbDireccion.Text.Length == 0)
                        throw new Exception("Se requiere una dirección para añadir un nuevo alojamiento");
                    if (ventanaAlojamiento.tbPrecioBase.Text.Length == 0)
                        throw new Exception("Se requiere un Precio base para añadir un nuevo alojamiento");
                    if (!regexNumerica.IsMatch(ventanaAlojamiento.tbPrecioBase.Text))
                        throw new Exception("Precio base incorrecto para añadir un nuevo alojamiento");
                    if (ventanaAlojamiento.tbNomPropietario.Text.Length == 0)
                        throw new Exception("Se requiere el nombre del propietario");
                    if (ventanaAlojamiento.tbApePropietario.Text.Length == 0)
                        throw new Exception("Se requiere el apellido del propietario");
                    if (ventanaAlojamiento.tbDniPropietario.Text.Length < 7 || !regexNumerica.IsMatch(ventanaAlojamiento.tbDniPropietario.Text))
                        throw new DniIncorrectoExepcion();
                    if (ventanaAlojamiento.tbCiudad.Text.Length == 0)
                        throw new Exception("Se requiere el nombre de la ciudad");

                    Alojamiento nuevoAlojamiento = null;
                    Propietario propietario = new Propietario(ventanaAlojamiento.tbNomPropietario.Text, ventanaAlojamiento.tbApePropietario.Text, Convert.ToInt32(ventanaAlojamiento.tbDniPropietario.Text));

                    //Que tipo de alojamiento es
                    if (ventanaAlojamiento.rbHotel.Checked)
                    {
                        if (ventanaAlojamiento.tbNombreHotel.Text.Length == 0)
                            throw new Exception("Se requiere el nombre del hotel para añadir una habitación de hotel");
                        if (ventanaAlojamiento.cbTipo.SelectedItem == null)
                            throw new Exception("Se requiere el tipo del Hotel para añadir una habitación de hotel");

                        nuevoAlojamiento = new HabitacionHotel(
                            ventanaAlojamiento.tbDireccion.Text,
                            ref contAlojamientos,
                            Convert.ToDouble(ventanaAlojamiento.tbPrecioBase.Text),
                            ventanaAlojamiento.cbTipo.SelectedItem.ToString(),
                            Convert.ToInt32(ventanaAlojamiento.nudEstrellas.Value),
                            ventanaAlojamiento.tbNombreHotel.Text,
                            propietario,
                            ventanaAlojamiento.tbCiudad.Text
                        );
                        ((HabitacionHotel)nuevoAlojamiento).NroHabitacion = Convert.ToInt32(ventanaAlojamiento.nudNroHab.Value);
                    }

                    else if (ventanaAlojamiento.rbCasa.Checked)
                    {
                        nuevoAlojamiento = new Casa(ventanaAlojamiento.tbDireccion.Text, ref contAlojamientos, Convert.ToDouble(ventanaAlojamiento.tbPrecioBase.Text), propietario, ventanaAlojamiento.tbCiudad.Text);
                        ((Casa)nuevoAlojamiento).MinimoDias = Convert.ToInt32(ventanaAlojamiento.nudMinimoDias.Value);
                    }

                    else if (ventanaAlojamiento.rbCasaFinde.Checked)
                    {
                        nuevoAlojamiento = new CasaFinde(ventanaAlojamiento.tbDireccion.Text, ref contAlojamientos, Convert.ToDouble(ventanaAlojamiento.tbPrecioBase.Text), propietario, ventanaAlojamiento.tbCiudad.Text);
                    }


                    if (nuevoAlojamiento != null)
                    {

                        //Agregamos los servicios al alojamiento
                        nuevoAlojamiento.MaxCantHuespedes = Convert.ToInt32(ventanaAlojamiento.nudMaxHues.Value);
                        if (ventanaAlojamiento.chbAc.Checked)
                            nuevoAlojamiento.Servicios.Add("Aire acondicionado");
                        if (ventanaAlojamiento.chbCochera.Checked)
                            nuevoAlojamiento.Servicios.Add("Cochera");
                        if (ventanaAlojamiento.chbDesayuno.Checked)
                            nuevoAlojamiento.Servicios.Add("Desayuno");
                        if (ventanaAlojamiento.chbPiscina.Checked)
                            nuevoAlojamiento.Servicios.Add("Piscina");
                        if (ventanaAlojamiento.chbWifi.Checked)
                            nuevoAlojamiento.Servicios.Add("Wifi");

                        //Agregamos la ciudad al sistema
                        miSistema.AgregarAlojamiento(nuevoAlojamiento);
                        cbAlojamiento.Items.Add(nuevoAlojamiento);

                        //Agregamos la ciudadal comboBox de Ciudades
                        if (miSistema.AgregarCiudad(nuevoAlojamiento.Ciudad))
                            cbCiudades.Items.Add(nuevoAlojamiento.Ciudad);

                    }
                }

                ventanaAlojamiento.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Este metodo sirve para hacer una reserva, llama a la ventana y crea un reserva en el alojamiento seleccionado
        private void btnReservar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantHuespedes = 0;

                Freserva ventanaReserva = new Freserva();

                Alojamiento alojamiento = null;

                //Le damos prioridad a reservar con el alojamiento seleccionado en el comboBox
                if (cbAlojamiento.SelectedItem != null)
                {
                    alojamiento = (Alojamiento)cbAlojamiento.SelectedItem;
                }
                else 
                {
                    //Hacemos esto porque porque nos parece mas eficiente que consultar si el listbox tiene seleccionado y tambien si el comboBox tiene seleccionado, con esto si esta seleccionado el comboBox, el programa se va a manejar simplemente con ese alojamiento, en caso de que sea null tira la excepcion  
                    if (lbBusqueda.SelectedItem != null)
                    {
                        alojamiento = (Alojamiento)lbBusqueda.SelectedItem;
                    }
                }

                if (alojamiento == null)
                {
                    throw new Exception("No se selecciono ningun alojamiento");
                }

                ventanaReserva.nudCantHues.Maximum = alojamiento.MaxCantHuespedes;

                if (ventanaReserva.ShowDialog() == DialogResult.OK)
                {
                    if (alojamiento != null)
                    {
                        if (ventanaReserva.tbNomRes.Text.Length == 0)
                            throw new Exception("Debes indicar el nombre del reservante para reservar");

                        if (ventanaReserva.tbApeRes.Text.Length == 0)
                            throw new Exception("Debes indicar el apellido del reservante para reservar");

                        if (ventanaReserva.tbDni.Text.Length < 7 || !regexNumerica.IsMatch(ventanaReserva.tbDni.Text))
                            throw new Exception("DNI incorrecto");
                        if (ventanaReserva.calendarioReservas.SelectionStart.DayOfYear < DateTime.Now.DayOfYear)
                            throw new Exception("No estamos en volver al futuro");

                        //Reservante
                        Cliente c = new Cliente(ventanaReserva.tbNomRes.Text, ventanaReserva.tbApeRes.Text, Convert.ToInt32(ventanaReserva.tbDni.Text));

                        //Nos basamos en el numericDownUp para la cantidad de huesped
                        cantHuespedes = Convert.ToInt32(ventanaReserva.nudCantHues.Value);


                        //Crea la reserva
                        miSistema.Reservar(
                            alojamiento,
                            ventanaReserva.calendarioReservas.SelectionStart,
                            ventanaReserva.calendarioReservas.SelectionEnd,
                            cantHuespedes,
                            c
                        );

                        //PintarReservasSegunAlojamiento(alojamiento);
                    }


                }
                //Liberamos los recursos de la ventana donde se reserva
                ventanaReserva.Dispose();

                //Contamos el reservante como huesped
                int contadorHuespedes = 1;

                //Ventana para agregar huespedes
                FAgregarCliente ventanaAgregarHuesped = new FAgregarCliente();
                while (contadorHuespedes < cantHuespedes)
                {
                    if (ventanaAgregarHuesped.ShowDialog() == DialogResult.OK)
                    {
                        if (ventanaAgregarHuesped.tbNomPropietario.Text.Length == 0)
                            throw new Exception("Nombre inválido");
                        if (ventanaAgregarHuesped.tbApePropietario.Text.Length == 0)
                            throw new Exception("Apellido inválido");
                        if (ventanaAgregarHuesped.tbDni.Text.Length < 7 || !regexNumerica.IsMatch(ventanaAgregarHuesped.tbDni.Text))
                            throw new Exception("DNI incorrecto");


                        //Agregas un huesped a la reserva
                        try
                        {
                            //Se agrega los huesped a la ultima reserva realizada
                            alojamiento.Reservas[alojamiento.Reservas.Length - 1].AgregarHuesped(new Cliente(ventanaAgregarHuesped.tbNomPropietario.Text, ventanaAgregarHuesped.tbApePropietario.Text, Convert.ToInt32(ventanaAgregarHuesped.tbDni.Text)));
                            contadorHuespedes++;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al cargar el huesped");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Este metodo borra las reservas anteriores del listBox y agrega las del nuevo listbox
        private void PintarReservasSegunAlojamiento(Alojamiento alojamiento)
        {
            if (alojamiento != null)
            {
                lbReservas.Items.Clear();
                foreach (Reserva r in alojamiento.Reservas)
                {
                    lbReservas.Items.Add(r);
                }
            }
        }

        //Este metodo actualiza las imagenes al alojamiento seleccionado
        private void PintarImagenesSegunAlojamiento(Alojamiento alojamiento)
        {
            try
            {
                if (alojamiento == null)
                {
                    throw new Exception("El alojamiento es nulo");
                }
                int iImg = 0;
                if (alojamiento.Imagenes.Count == 0)
                {
                    pbImg1.Image = null;
                    pbImg2.Image = null;
                }
                else
                {
                    foreach (System.Drawing.Image img in alojamiento.Imagenes)
                    {
                        if (iImg == 0)
                            pbImg1.Image = img;
                        else if (iImg == 1)
                            pbImg2.Image = img;

                        iImg++;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudieron cargar las imagenes");
            }


        }

        //Cuando cambia el indice del comboBox cambia todas sus iamgenes, etc
        private void cbAlojamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alojamiento alojamiento = (Alojamiento)cbAlojamiento.SelectedItem;
            Actualizar_Visual(alojamiento);
        }


        //Este metodo sirve para subir una foto para un determinado alojamiento
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            try
            {
                if (cbAlojamiento.SelectedItem == null)
                    throw new Exception("Seleccione un alojamiento para modificar");

                Alojamiento alojamiento = (Alojamiento)cbAlojamiento.SelectedItem;

                if (alojamiento.Imagenes.Count == 2)
                    throw new Exception("Solo se pueden agregar dos imágenes del alojamiento");

                openFileDialog.Filter = " Imagenes (*.JPG; *.PNG) | *.jpg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Usamos System.Drawing.Image porque si no nos da una ambiguedad 
                    alojamiento.AgregarImagen(System.Drawing.Image.FromFile(openFileDialog.FileName));
                    PintarImagenesSegunAlojamiento(alojamiento);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                openFileDialog.Dispose();
            }
        }

        //Este metodo sirve para camibar los labels segun el alojamiento dado como argumento
        private void PintarLabelSegunAlojamiento(Alojamiento alojamiento)
        {
            if (alojamiento != null)
            {
                lblDireccion.Text = alojamiento.Direccion;
                lblNroProp.Text = alojamiento.NroPropiedad.ToString();
                lblMaxPer.Text = alojamiento.MaxCantHuespedes.ToString();
                if (alojamiento is HabitacionHotel)
                {
                    lblMinPer.Text = "-";
                    lblEstrellas.Text = ((HabitacionHotel)alojamiento).Estrellas.ToString();
                }
                else if (alojamiento is Casa)
                {
                    lblEstrellas.Text = "-";
                    lblMinPer.Text = ((Casa)alojamiento).MinimoDias.ToString();
                }
                foreach (string s in alojamiento.Servicios)
                    lbServicios.Items.Add(s);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void lbReservas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Modifica segun cambies las cosas
        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                Alojamiento alojamiento;

                if (cbAlojamiento.SelectedItem == null)
                    throw new Exception("Seleccione un alojamiento para modificar");

                //Creamos un nuevo alojamiento usando el numero de propiedad de la ya existente
                if (cbAlojamiento.SelectedItem is HabitacionHotel)
                {
                    alojamiento = new HabitacionHotel(((Alojamiento)cbAlojamiento.SelectedItem).NroPropiedad);
                    ((HabitacionHotel)alojamiento).Estrellas = Convert.ToInt32(nudEstrellas.Value);
                }

                else if (cbAlojamiento.SelectedItem is CasaFinde)
                {
                    alojamiento = new CasaFinde(((Alojamiento)cbAlojamiento.SelectedItem).NroPropiedad);
                }

                else
                {
                    alojamiento = new Casa(((Alojamiento)cbAlojamiento.SelectedItem).NroPropiedad);
                    ((Casa)alojamiento).MinimoDias = Convert.ToInt32(nudMinimoDias.Value);
                }

                //Los sets de las propiedades de alojamiento se encargan de que no tengan errores
                alojamiento.Direccion = tbCamDir.Text;
                alojamiento.PrecioBase = Convert.ToDouble(nudPb.Value);
                alojamiento.MaxCantHuespedes = Convert.ToInt32(nudMaxPersonas.Value);

                miSistema.ModificarAlojamiento(alojamiento);

                //Busca el modificado para actualizar 
                Alojamiento modificado = miSistema.BuscarAlojamiento(alojamiento.NroPropiedad);

                //Actualiza la parte visual
                PintarLabelSegunAlojamiento(modificado);


                MessageBox.Show("Alojamiento modificado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Este metodo sirve para dar de baja un alojamiento
        private void btnDarBajaAl_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAlojamiento.SelectedItem == null)
                    throw new Exception("Seleccione un alojamiento para inhabilitar");

                Alojamiento alojamiento = (Alojamiento)cbAlojamiento.SelectedItem;

                //Lo da de baja del sistema
                miSistema.DarDeBajaAlojamiento(alojamiento.NroPropiedad);

                //Borra la parte visual
                cbAlojamiento.Items.Remove(cbAlojamiento.SelectedItem);
                lblDireccion.Text = "-";
                lblNroProp.Text = "-";
                lblMaxPer.Text = "-";
                lblMinPer.Text = "-";
                lblEstrellas.Text = "-";
                lbServicios.Items.Clear();
                lbReservas.Items.Clear();
                pbImg1.Image = null;
                pbImg2.Image = null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Este metodo sirve para modificar una reserva en el alojamiento seleccionado
        private void btnModRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAlojamiento.SelectedItem == null)
                    throw new Exception("Seleccione un alojamiento para la reserva");

                if (lbReservas.SelectedItem == null)
                    throw new Exception("Seleccione una reserva para inhabilitar");


                Reserva reserva = (Reserva)lbReservas.SelectedItem;

                FInfoReserva ventanaFireserva = new FInfoReserva();

                //Actualiza la informacion de la ventana modal con la informacion de la reserva
                ventanaFireserva.lblIncio.Text = $"{reserva.Ingreso.Day}/{reserva.Ingreso.Month}/{reserva.Ingreso.Year}";
                ventanaFireserva.lblFin.Text = $"{reserva.Egreso.Day}/{reserva.Egreso.Month}/{reserva.Egreso.Year}";
                ventanaFireserva.lblPrecio.Text = $"{reserva.CostoPorDia}";
                ventanaFireserva.lblPrecioTotal.Text = $"{reserva.CostoTotal}";
                ventanaFireserva.lblCliente.Text = $"{reserva.Reservante.Nombre} {reserva.Reservante.Apellido}";
                ventanaFireserva.lblDni.Text = $"{reserva.Reservante.Dni}";
                ventanaFireserva.lblCantDias.Text = $"{reserva.CantDias}";
                ventanaFireserva.lblCantPersonas.Text = $"{reserva.CantPersonas}";
                ventanaFireserva.dtpInicio.Value = reserva.Ingreso;
                ventanaFireserva.dtpFin.Value = reserva.Egreso;


                if (ventanaFireserva.ShowDialog() == DialogResult.OK)
                {
                    if (ventanaFireserva.dtpInicio.Value >= ventanaFireserva.dtpFin.Value)
                        throw new Exception("La fecha de inicio no puede superar o igualar a la de egreso");

                    //Se crea una nueva reserva con los datos de la ventana modal
                    Reserva auxReserva = new Reserva(ventanaFireserva.dtpInicio.Value, ventanaFireserva.dtpFin.Value, reserva.CodReserva, reserva.CantPersonas, reserva.Reservante);

                    auxReserva.Ingreso = ventanaFireserva.dtpInicio.Value.Date;
                    auxReserva.Egreso = ventanaFireserva.dtpFin.Value.Date;
                    auxReserva.CantPersonas = Convert.ToInt32(ventanaFireserva.nudCantPersonas.Value);

                    //La nueva supuesta reserva
                    miSistema.ModificarReserva((Alojamiento)cbAlojamiento.SelectedItem, auxReserva);

                    PintarReservasSegunAlojamiento((Alojamiento)cbAlojamiento.SelectedItem);

                    MessageBox.Show("Reserva modificada con éxito");
                }
                ventanaFireserva.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Este metodo sirve para borrar una reserva
        private void btnInRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAlojamiento.SelectedItem == null)
                    throw new Exception("Seleccione un alojamiento para modificar la reserva");

                if (lbReservas.SelectedItem == null)
                    throw new Exception("Seleccione una reserva para modificar");

                Alojamiento alojamiento = (Alojamiento)cbAlojamiento.SelectedItem;
                Reserva reserva = (Reserva)lbReservas.SelectedItem;

                miSistema.DarDeBajaReserva(alojamiento, reserva);
                lbReservas.Items.Remove(lbReservas.SelectedItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //String de servicios 
        string[] servicios = Alojamiento.serviciosDisponibles;

        //Este es el meotodo para importar todos los servicios 
        private void btnImportar_Click(object sender, EventArgs e)
        {
            FileStream miArchivo = null;
            StreamReader sr = null;
            try
            {
                openFileDialog1.Filter = "archivo de valores separados por coma (*.txt) | *.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string archivo = openFileDialog1.FileName;
                    miArchivo = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(miArchivo);
                    string renglon;

                    Alojamiento ultimoAlojamiento = null;

                    while (!sr.EndOfStream)
                    {
                        renglon = sr.ReadLine();
                        string[] datos = renglon.Split(';');
                        switch (datos[0])
                        {
                            case "CasaFinde":
                                {
                                    Propietario p = new Propietario(datos[3], datos[4], Convert.ToInt32(datos[5]));
                                    ultimoAlojamiento = new CasaFinde(datos[1], ref contAlojamientos, Convert.ToDouble(datos[2]), p, datos[7]);
                                    ultimoAlojamiento.MaxCantHuespedes = Convert.ToInt32(datos[6]);

                                    //8 es el numero donde arranca los datos de servicio
                                    AgregarServicioAl(8, ultimoAlojamiento, datos);

                                    //Se agregan al sistema y comboBox
                                    miSistema.AgregarAlojamiento(ultimoAlojamiento);
                                    cbAlojamiento.Items.Add(ultimoAlojamiento);

                                    //Agregamos la ciudad
                                    if (!miSistema.AgregarCiudad(datos[7]))
                                        cbCiudades.Items.Add(datos[7]);
                                }
                                break;
                            case "Casa":
                                {
                                    Propietario p = new Propietario(datos[3], datos[4], Convert.ToInt32(datos[5]));
                                    ultimoAlojamiento = new Casa(datos[1], ref contAlojamientos, Convert.ToDouble(datos[2]), p, datos[8]);
                                    ultimoAlojamiento.MaxCantHuespedes = Convert.ToInt32(datos[6]);
                                    ((Casa)ultimoAlojamiento).MinimoDias = Convert.ToInt32(datos[7]);

                                    //8 es el numero donde arranca los datos de servicio
                                    AgregarServicioAl(9, ultimoAlojamiento, datos);

                                    //Se agregan al sistema y comboBox
                                    miSistema.AgregarAlojamiento(ultimoAlojamiento);
                                    cbAlojamiento.Items.Add(ultimoAlojamiento);

                                    //Agregamos la ciudad
                                    if (!miSistema.AgregarCiudad(datos[8]))
                                        cbCiudades.Items.Add(datos[8]);
                                }
                                break;
                            case "HabitacionHotel":
                                {
                                    Propietario p = new Propietario(datos[6], datos[7], Convert.ToInt32(datos[8]));
                                    ultimoAlojamiento = new HabitacionHotel(datos[1], ref contAlojamientos, Convert.ToDouble(datos[2]), datos[3], Convert.ToInt32(datos[4]), datos[5], p, datos[11]);
                                    ultimoAlojamiento.MaxCantHuespedes = Convert.ToInt32(datos[9]);
                                    ((HabitacionHotel)ultimoAlojamiento).NroHabitacion = Convert.ToInt32(datos[10]);

                                    //12 es el numero donde arranca los datos de servicio
                                    AgregarServicioAl(12, ultimoAlojamiento, datos);

                                    //Se agregan al sistema y comboBox
                                    miSistema.AgregarAlojamiento(ultimoAlojamiento);
                                    cbAlojamiento.Items.Add(ultimoAlojamiento);

                                    //Agregamos la ciudad
                                    if (!miSistema.AgregarCiudad(datos[11]))
                                        cbCiudades.Items.Add(datos[11]);
                                }
                                break;
                            case "Reserva":
                                {
                                    Cliente c = new Cliente(datos[4], datos[5], Convert.ToInt32(datos[6]));
                                    DateTime ing = new DateTime(DateTime.Now.Year, 1, 1).AddDays(Convert.ToInt32(datos[1]) - 1);
                                    DateTime egr = new DateTime(DateTime.Now.Year, 1, 1).AddDays(Convert.ToInt32(datos[2]) - 1);
                                    miSistema.Reservar(ultimoAlojamiento, ing, egr, Convert.ToInt32(datos[3]), c);
                                }
                                break;
                            case "Cliente":
                                {
                                    if (ultimoAlojamiento != null)
                                    {
                                        Reserva reservaHuesped = null;
                                        //Agregamos los huespedes a la ultima reserva del ultimo alojamiento, estan exportados en forma ordenada. El reservante lo condiseramos huesped.
                                        if (ultimoAlojamiento.UltimaReserva != null)
                                        {
                                            reservaHuesped = ultimoAlojamiento.UltimaReserva;
                                        }
                                        if (reservaHuesped != null)
                                        {
                                            reservaHuesped.AgregarHuesped(new Cliente(datos[1], datos[2], Convert.ToInt32(datos[3])));
                                        }

                                    }

                                }
                                break;
                        }


                    }
                    MessageBox.Show("Se agrego con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (miArchivo != null)
                {
                    miArchivo.Close();
                    if (sr != null)
                        sr.Close();
                }
            }
        }

        //Este metodo sirve para ir recorrinedo los servicios que tiene un alojamiento, la eleccion de hacerlo en el form es porque este metodo agrega los servicios pero porque estamos importando este alojamiento con estos servicios, no agregando como tal
        void AgregarServicioAl(int inicio, Alojamiento alojamiento, string[] datos)
        {
            int iServicios = 0;
            for (int i = inicio; i < inicio + 5; i++)
            {
                if (datos[i] == "1")
                {
                    alojamiento.AgregarServicio(servicios[iServicios]);
                }
                iServicios++;
            }
        }

        //Metodo que sirve para exportar todos los alojamientos, reservas y clientes
        private void btnExportar_Click(object sender, EventArgs e)
        {
            FileStream miArchivo = null;
            StreamWriter streamWriter = null;

            try
            {
                string archivo = "datos.txt";

                saveFileDialog1.FileName = archivo;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    archivo = saveFileDialog1.FileName;

                    if (File.Exists(archivo)) File.Delete(archivo);

                    miArchivo = new FileStream(archivo, FileMode.CreateNew, FileAccess.Write);
                    streamWriter = new StreamWriter(miArchivo);


                    foreach (Alojamiento alojamiento in miSistema.Alojamientos)
                    {
                        streamWriter.WriteLine(alojamiento.Info());

                        foreach (Reserva reserva in alojamiento.Reservas)
                        {
                            //Toda la informacion de la reserva
                            streamWriter.WriteLine(reserva.Info());

                            //Escribe los huespedes en nueva linea, consideramos que los huespedes son Clientes
                            //El i = 1 es porque el reservante ya esta escrito en el archivo y lo contamos como un huesped mas
                            for (int i = 1; i < reserva.Huespedes.Count; i++)
                            {
                                if (reserva.Huespedes[i] != null)
                                    streamWriter.WriteLine(reserva.Huespedes[i].ToString());
                            }
                        }
                    }

                    MessageBox.Show("Se exporto con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    if (miArchivo != null)
                    {
                        miArchivo.Close();
                    }
                }
            }
        }

        private void pbImg1_Click(object sender, EventArgs e)
        {

        }

        //Muestra en un Form las ganancias de todos los alojamientos
        private void btnTotal_Click(object sender, EventArgs e)
        {

            GananciasTotales ventanaGananciasTotales = new GananciasTotales();

            foreach (Alojamiento al in miSistema.Alojamientos)
            {
                ventanaGananciasTotales.lbGanancias.Items.Add($"{al.Direccion} - ${al.GananciasTotaes()} - {al.Reservas.Length} reservas");
            }
                
            ventanaGananciasTotales.Show();
        }

        //Este metodo sirve para exportar todas las ganancias de los alojamientos
        private void btnExportarGanancias_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                string miArchivo = "ganancias.txt";
                saveFileDialog1.FileName = miArchivo;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    miArchivo = saveFileDialog1.FileName;

                    if (File.Exists(miArchivo)) File.Delete(miArchivo);


                    fs = new FileStream(miArchivo, FileMode.CreateNew, FileAccess.Write);
                    sw = new StreamWriter(fs);


                    foreach (Alojamiento al in miSistema.Alojamientos)
                    {
                        sw.WriteLine($"{al.Direccion};${al.GananciasTotaes()};{al.Reservas.Length} reservas");
                    }
                        

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    if (fs != null)
                        fs.Close();
                }
            }
        }


        //Este metodo lanza la ventana para imprimir que a su vez llama al metodo printDocument1_PrintPage
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbReservas.SelectedItem == null)
                    throw new Exception("Debes seleccionar una reserva para imprimir");

                Cliente c = ((Reserva)lbReservas.SelectedItem).Reservante;

                for (int i = 0; i < 2; i++)
                {
                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.Print();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }


        //Grafica el documento a imprimir
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Reserva reserva = null;
            try
            {
                if (lbReservas.SelectedItem != null)
                {
                    reserva = lbReservas.SelectedItem as Reserva;
                }
                else
                {
                    throw new Exception("Seleccione una reserva");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (reserva != null)
            {
                try
                {
                    //Graficos para imprimir
                    Graphics grafico = e.Graphics;
                    Font font = new Font("Impact", 18);
                    Brush brush = new SolidBrush(Color.Red);


                    //Encabezados
                    grafico.DrawString("Nombre", font, brush, 30, 30);
                    grafico.DrawString("Apellido", font, brush, 150, 30);
                    grafico.DrawString("Dni", font, brush, 490, 30);


                    //Grafico icono de la empresa
                    System.Drawing.Image icono = System.Drawing.Image.FromFile(miSistema.DireccionIcon);
                    grafico.DrawImage(icono, 800, 0, 50, 50);


                    //Graficos de imagenes
                    Alojamiento alojamiento = reserva.Alojamiento;

                    float x = 100; //Ubicacion X de la imagen
                    foreach (System.Drawing.Image imagen in alojamiento.Imagenes)
                    {
                        grafico.DrawImage(imagen, x, 800, 100, 100);
                        x += 200;
                    }



                    //Posicion inicial de los datos de huesped
                    float y = 60;

                    foreach (Cliente huesped in reserva.Huespedes)
                    {
                        if (huesped != null)
                        {
                            grafico.DrawString(huesped.Nombre, font, new SolidBrush(Color.Black), 30, y);
                            grafico.DrawString(huesped.Apellido, font, new SolidBrush(Color.Black), 150, y);
                            grafico.DrawString(huesped.Dni.ToString(), font, new SolidBrush(Color.Black), 490, y);

                            //Aumenta la posicion Y
                            y += 50;
                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }


        //Este metodo hace que cuando cambio el indice del listBox muestre tambien sus datos facilitando saber los datos de los alojamientos en el apartado de Busqueda
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alojamiento alojamiento = (Alojamiento)lbBusqueda.SelectedItem;
            Actualizar_Visual(alojamiento);
        }


        //Este boton sirve para buscar alojamientos segun lo que el usuario busque 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lbBusqueda.Items.Clear();
            string ciudad = "";

            //Fechas
            DateTime ingreso = dtpInicio.Value; ;
            DateTime egreso = dtpFin.Value; ;


            int cantidadHuespedes = Convert.ToInt32(nudCantHuespedes.Value);

            if (cbCiudades.SelectedItem != null)
            {
                ciudad = cbCiudades.SelectedItem.ToString();
            }


            foreach (Alojamiento alojamiento in miSistema.Alojamientos)
            {
                //Si no se ha seleccionado ciudad pasa
                if ((alojamiento.Ciudad == ciudad) || (ciudad == ""))
                {
                    //Si no seleccionaste nada, pasa
                    if ((alojamiento.MaxCantHuespedes >= cantidadHuespedes) || cantidadHuespedes == 0)
                    {
                        //Chequea si esta disponible en esas fechas y si no seleccionaste nada, significa que el dia de egreso va a ser el dia de hoy, por lo tanto no entra 
                        if (alojamiento.ChequearDisponibilidad(ingreso, egreso) || (egreso.DayOfYear == DateTime.Now.DayOfYear))
                        {
                            lbBusqueda.Items.Add(alojamiento);
                        }
                    }
                }
            }
            if (lbBusqueda.Items.Count == 0)
            {
                MessageBox.Show("No hay propiedades disponibles con tus requisitos");
            }
        }

        //Boton para exportar solamente clientes y reservas
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                string miArchivo = "reservasYclientes.txt";
                saveFileDialog1.FileName = miArchivo;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    miArchivo = saveFileDialog1.FileName;

                    if (File.Exists(miArchivo)) File.Delete(miArchivo);

                    fs = new FileStream(miArchivo, FileMode.CreateNew, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    foreach (Alojamiento alojamiento in miSistema.Alojamientos)
                    {
                        string alojamientoPrint = alojamiento.Print().Trim();
                        sw.WriteLine(alojamientoPrint);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    if (fs != null)
                        fs.Close();
                }
            }
        }

        //Este metodo sirve para una vez se cierre el Form, guarde todos los datos de miSistema asegurando asi la persistencia de datos
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileStream archivo = null;
            try
            {
                string direccion = Application.StartupPath + "\\datos.txt";

                if (File.Exists(direccion)) File.Delete(direccion);

                archivo = new FileStream(direccion, FileMode.CreateNew, FileAccess.Write);
                datos.Serialize(archivo, miSistema);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                archivo.Close();
            }

            


        }

        //Este metodo sirve para borrar la seleccion del comboBox de Ciudades en el apartado de busqueda.
        private void btnBorrarCiudad_Click(object sender, EventArgs e)
        {
            cbCiudades.SelectedIndex = -1;
        }

        //Este metodo sirve para crear usuarios nuevos, solamente se puede si esta loggeado el administrador
        private void crearUsariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin)
                {
                    FormUsuarios formUsuarios = new FormUsuarios();

                    if (formUsuarios.ShowDialog() == DialogResult.OK)
                    {
                        string usuario = formUsuarios.tbUsuario.Text;
                        string contraseña = formUsuarios.tbContraseña.Text;

                        if (miSistema.AgregarUsuarios(usuario, contraseña))
                        {
                            MessageBox.Show("Agregado con exito");
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Este metodo sirve para cambiar la contraseña de un usuario, optamos por que puedas cambiar la contraseña de cualquier usuario y no la del actual usuario loggeado.
        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormUsuarios formUsuarios = new FormUsuarios();

                //Activamos los campos de nueva contraseña
                formUsuarios.tbNueva.Visible = true;
                formUsuarios.lbNueva.Visible = true;

                if (formUsuarios.ShowDialog() == DialogResult.OK)
                {

                    string usuario = formUsuarios.tbUsuario.Text;
                    string contraseña = formUsuarios.tbContraseña.Text;
                    string contraseñaNueva = formUsuarios.tbNueva.Text;

                    if (miSistema.CambiarContraseña(usuario, contraseña, contraseñaNueva))
                    {
                        MessageBox.Show("Contraseña cambiada!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            //pictureBox1.Invalidate();

        }

        //Metodo no utilizado
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(10, 10, 200, 200);
        }

        //Vector de colores
        Color[] Colores = new Color[10] {
            Color.Red,     // Rojo
            Color.Blue,    // Azul
            Color.Green,   // Verde
            Color.Yellow,  // Amarillo
            Color.Orange,  // Naranja
            Color.Purple,  // Púrpura
            Color.Brown,   // Marrón
            Color.Magenta, // Magenta
            Color.Cyan,    // Cian
            Color.Gray     // Gris
        };

        //Este metodo pinta el grafico torta de si son Casa, CasaFinde o Hotel
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Usamos diccionario por su facil implementacion para estos casos
            Dictionary<string, float> Lista = new Dictionary<string, float>();


            foreach (Alojamiento alojamiento in miSistema.Alojamientos)
            {
                if (alojamiento is CasaFinde)
                {
                    if (Lista.ContainsKey("CasaFinde"))
                    {
                        Lista["CasaFinde"] += 1;
                    }
                    else
                    {
                        Lista["CasaFinde"] = 1;
                    }

                }
                else if (alojamiento is Casa)
                {
                    if (Lista.ContainsKey("Casa"))
                    {
                        Lista["Casa"] += 1;
                    }
                    else
                    {
                        Lista["Casa"] = 1;
                    }

                }
                else if (alojamiento is HabitacionHotel)
                {
                    if (Lista.ContainsKey("Hotel"))
                    {
                        Lista["Hotel"] += 1;
                    }
                    else
                    {
                        Lista["Hotel"] = 1;
                    }

                }
            }
            float total = miSistema.Alojamientos.Count();

            Graphics g = e.Graphics;

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            #region margenes
            float m = 20;
            #endregion

            #region area cliente
            float wc = w - 2 * m;
            float hc = h - 2 * m;
            #endregion

            #region centro
            float x0 = wc / 2 + m;
            float y0 = hc / 2 + m;
            #endregion

            float startAngle = 0;
            int n = 0;

            Font etiquetaFont = new Font("Arial", 15);


            foreach (KeyValuePair<string, float> key in Lista)
            {
                n++;
                Brush brush = new SolidBrush(Colores[n]);

                string clave = key.Key;


                float sweepAngle = key.Value / total * 360; // Calcula el ángulo proporcional
                g.FillPie(brush, x0 - w / 2, y0 - hc / 2, wc, hc, startAngle, sweepAngle);

                if (clave == "Casa")
                {
                    lbCasa.ForeColor = Colores[n];
                    lbCasa.Text = $"Casa {((key.Value / total) * 100).ToString("f2")} %";
                }
                if (clave == "CasaFinde")
                {
                    lbCasaFinde.ForeColor = Colores[n];
                    lbCasaFinde.Text = $"CasaFinde {((key.Value / total) * 100).ToString("f2")} %";
                }
                if (clave == "Hotel")
                {
                    lbHotel.ForeColor = Colores[n];
                    lbHotel.Text = $"Hotel {((key.Value / total) * 100).ToString("f2")} %";
                }


                startAngle += sweepAngle;
                n++;



            }

        }
        private int GetMaximo(Dictionary<string, int> Lista)
        {

            int maximo = 0;
            int n = 0;
            foreach (KeyValuePair<string, int> key in Lista)
            {
                string clave = key.Key;
                int valor = Convert.ToInt32(key.Value);

                if (n == 0 || valor >= maximo)
                    maximo = valor;

                n++;
            }

            return maximo;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pbHuespedesReserva.Invalidate();
        }

        //Este metodo pinta el grafico de barras de la cantidad de personas por reservas 
        private void pbHuespedesReserva_Paint(object sender, PaintEventArgs e)
        {
            //Usamos este diccionario para contar los huespedes
            Dictionary<string, int> Lista = new Dictionary<string, int>();

            foreach (Alojamiento alojamiento in miSistema.Alojamientos)
            {
                foreach (Reserva reserva in alojamiento.Reservas)
                {
                    //El enunciado dice dos huesped pero obtamos por poner menor a dos
                    if (reserva.Huespedes.Count <= 2)
                    {
                        if (Lista.ContainsKey("Dos"))
                        {
                            Lista["Dos"] += 1;
                        }
                        else
                        {
                            Lista["Dos"] = 1;
                        }
                    }
                    else if (reserva.Huespedes.Count == 3)
                    {
                        if (Lista.ContainsKey("Tres"))
                        {
                            Lista["Tres"] += 1;
                        }
                        else
                        {
                            Lista["Tres"] = 1;
                        }
                    }
                    else if (reserva.Huespedes.Count == 4)
                    {
                        if (Lista.ContainsKey("Cuatro"))
                        {
                            Lista["Cuatro"] += 1;
                        }
                        else
                        {
                            Lista["Cuatro"] = 1;
                        }
                    }
                    else if (reserva.Huespedes.Count == 5)
                    {
                        if (Lista.ContainsKey("Cinco"))
                        {
                            Lista["Cinco"] += 1;
                        }
                        else
                        {
                            Lista["Cinco"] = 1;
                        }
                    }
                    else if (reserva.Huespedes.Count >= 6)
                    {
                        if (Lista.ContainsKey("6mas"))
                        {
                            Lista["6mas"] += 1;
                        }
                        else
                        {
                            Lista["6mas"] = 1;
                        }
                    }
                }
            }

            Graphics g = e.Graphics;

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            
            int maximo = GetMaximo(Lista);
            float factorEscala = 1f * h / maximo;



            int wbarra = (w - 10) / 6;//6 barras

            int pos = 0;

            Font etiquetaFont = new Font("Arial", 11);

            //Iteramos sobre el par Key-Value
            foreach (KeyValuePair<string, int> key in Lista)
            {

                Brush brush = new SolidBrush(Colores[pos]);
                string clave = key.Key;
                int valor = Convert.ToInt32(key.Value);

                int hbarra = (int)factorEscala * valor;

                int x0 = 10 + pos * wbarra;
                int y0 = (h - 10) - hbarra;
                int wh = wbarra - 2;
                int hh = hbarra;

                pos++;

                Pen pen = new Pen(Color.Black);
                g.FillRectangle(brush, x0, y0, wh, hh);

                //Este string es el cartel
                Brush brushX = new SolidBrush(Colores[pos + 1]);
                g.DrawString(clave, etiquetaFont, brushX, x0, y0 + 10);



            }
        }

        GenHTML genHTML = new GenHTML();
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pathUbi = Application.StartupPath+@"\..\..\..\..\web\acercaDe.html\";
                genHTML.GenerarAcercaDeHTML(pathUbi);
                Fhtml fhtml = new Fhtml();
                fhtml.wbCasosUso.Navigate(pathUbi);
                fhtml.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

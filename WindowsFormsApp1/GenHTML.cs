using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class GenHTML
    {
        public void GenerarCasosDeUsoHTML(string pathRootWeb)
        {
            if (!File.Exists(pathRootWeb))
                Directory.CreateDirectory(pathRootWeb);
            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(pathRootWeb, FileMode.OpenOrCreate, FileAccess.Write);
                sr = new StreamWriter(fs);
                sr.WriteLine("<html>");
                    sr.WriteLine("<head>");
                        sr.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">");
                        sr.WriteLine("<title>Casos de uso</title>");
                        sr.WriteLine("<style>");
                            
                        sr.WriteLine("</style>");
                    sr.WriteLine("</head>");
                    sr.WriteLine("<body>");
                        sr.WriteLine("<h2>Casos de uso</h2>");
                    sr.WriteLine("</body>");
                sr.WriteLine("</html>");
            }
            catch (Exception ex)
            {
                throw ex;
                //completar!
            }
            finally
            {
                if (fs != null)
                {
                    if (sr != null) sr.Close();
                    fs.Close();
                }
            }
            //return "";
        }

        public void GenerarAcercaDeHTML(string pathRootWeb)
        {
            if (!File.Exists(pathRootWeb))
                Directory.CreateDirectory(pathRootWeb);
            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(pathRootWeb, FileMode.OpenOrCreate, FileAccess.Write);
                sr = new StreamWriter(fs);
                sr.WriteLine("<html>");
                sr.WriteLine("<head>");
                sr.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">");
                sr.WriteLine("<title>Acerca de</title>");
                sr.WriteLine("<style>");

                sr.WriteLine("</style>");
                sr.WriteLine("</head>");
                sr.WriteLine("<body>");
                    sr.WriteLine("<h2>Real State Company</h2>");
                    sr.WriteLine("<p>\r\n¡Bienvenido a Real State Company!\\n\\nEn Real State Company, estamos dedicados a transformar tus experiencias de viaje en momentos inolvidables. Nos enorgullece ser líderes en la industria de la gestión de reservas de alojamientos, ofreciendo un servicio excepcional que va más allá de tus expectativas.\\n\\nNuestra misión es simplificar y enriquecer cada etapa de tu viaje, desde la planificación hasta la estadía, proporcionándote acceso a una amplia gama de alojamientos cuidadosamente seleccionados, que incluyen hoteles de lujo, acogedoras casas de fin de semana y mucho más. Creemos en la importancia de personalizar tu experiencia, y es por eso que te ofrecemos una variedad de opciones para adaptarnos a tus preferencias y necesidades individuales.\\n\\nLo que nos distingue es nuestro compromiso con la excelencia en el servicio al cliente. Nuestro equipo altamente capacitado está disponible las 24 horas del día, los 7 días de la semana, para asegurarse de que cada detalle de tu reserva se maneje con precisión y eficiencia. Queremos que te sientas respaldado en cada paso del camino, desde la consulta inicial hasta el momento en que vuelvas a casa con recuerdos inolvidables.\\n\\nEn Real State Company, valoramos la transparencia y la confiabilidad. Trabajamos incansablemente para garantizar que cada propiedad cumpla con los más altos estándares de calidad y comodidad, brindándote la tranquilidad de saber que tu alojamiento será impecable.\\n\\nDescubre el placer de viajar con Real State Company. Permítenos ser tu socio confiable en la exploración del mundo, donde cada reserva es una invitación a vivir experiencias únicas.\\n\\nBienvenido a un mundo de posibilidades, bienvenido a Real State Company. Tu viaje comienza aquí.</p>");

                sr.WriteLine("</body>");
                sr.WriteLine("</html>");
            }
            catch (Exception ex)
            {
                throw ex;
                //completar!
            }
            finally
            {
                if (fs != null)
                {
                    if (sr != null) sr.Close();
                    fs.Close();
                }
            }
        }
    }
}

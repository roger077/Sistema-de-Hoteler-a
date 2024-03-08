using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DniIncorrectoExepcion:Exception
    {
        const string message = "El DNI no tiene el formato correcto";

        public DniIncorrectoExepcion() : base(message) { }

        public DniIncorrectoExepcion(Exception innerException) : base(message, innerException) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PROYECTO_FINAL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form4 apex = new Form4();
            Application.Run(apex);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}

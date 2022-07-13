using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace PROYECTO_FINAL
{
    public class Arduino
    {
        SerialPort PuertoSerial;
        bool conexionDefinida;

        public Arduino(string NombrePuerto, int bauds)
        {
            try
            {
                PuertoSerial = new SerialPort(NombrePuerto, bauds);
                MessageBox.Show("Conexión Establecida" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                conexionDefinida = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la asignacion del puerto del arduino. " + ex, "Error de Inicializacion de Puerto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexionDefinida = false;
            }
        }


        public bool Iniciar_Comunicacion()
        {
            if (conexionDefinida)
            {
                try
                {
                    if (!PuertoSerial.IsOpen) //Si el puerto esta cerrado
                        PuertoSerial.Open();
                    PuertoSerial.ReadTimeout = 95;
                    PuertoSerial.Write("probar");
                    if (PuertoSerial.ReadChar() == 'a')
                    {
                        MessageBox.Show("Comunicacion Establecida", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la asignacion del puerto del arduino. " + ex, "Error de Inicializacion de Puerto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Cerrar_Puerto()
        {
            if (PuertoSerial.IsOpen)
                PuertoSerial.Close();
        }

        public void Detener()
        {
            if (conexionDefinida)
            {
                PuertoSerial.Write("s");
            }
        }

        public int Tomar_Dato()
        {
            int dato = -1;
            try
            {

                if (conexionDefinida)
                {
                    PuertoSerial.Write("r");
                    dato = PuertoSerial.ReadChar();
                }
            }
            catch
            {
                MessageBox.Show("Error Interno al obtener Lectura, la aplicacion se cerrara", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return dato;
        }

        public bool Prender_Led()
        {
            try
            {

                if (conexionDefinida)
                {
                    PuertoSerial.Write("t");
                    if (PuertoSerial.ReadChar() == 't')
                    {
                        MessageBox.Show("Led Encendido", "Acción Ejecutada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Interno al obtener Lectura, la aplicacion se cerrara", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return false;
        }

        public bool Apagar_Led()
        {
            try
            {

                if (conexionDefinida)
                {
                    PuertoSerial.Write("k");
                    if (PuertoSerial.ReadChar() == 'k')
                    {
                        MessageBox.Show("Led Apagado", "Acción Ejecutada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Interno al obtener Lectura, la aplicacion se cerrara", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return true;
        }

    }
}

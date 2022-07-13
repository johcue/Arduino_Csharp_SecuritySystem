using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace PROYECTO_FINAL
{
    public partial class Form4 : Form
    {
        public static Arduino nino = null;
        int dato = 0;
        bool LedEncendido = false;
        public Form4()
        {
            InitializeComponent();
        }
        private void Cargar_Puertos()
        {
            cboPuertos.Items.Clear();
            string[] puertos = SerialPort.GetPortNames();

            foreach (string port in puertos)
            {
                cboPuertos.Items.Add(port);
            }
        }
        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                nino.Cerrar_Puerto();
            }
            catch
            {
            }
        }

        private void cboPuertos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizarPuertos_Click(object sender, EventArgs e)
        {
            Cargar_Puertos();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (this.cboPuertos.Items.Count > 0)
            {
                if (this.cboPuertos.SelectedIndex > -1)
                {
                    nino = new Arduino(this.cboPuertos.Text, 115200);//Inicializamos arduino a 115200 bauds
                    nino.Iniciar_Comunicacion();
                    btnIniciar.Enabled = false;
                    btnDetener.Enabled = true;
                    timer1.Enabled = false;
                    btnForm1_Click(null, null);
                }
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                nino.Detener();
                nino.Cerrar_Puerto();
                nino = null;
                btnDetener.Enabled = false;
                btnIniciar.Enabled = true;
                timer1.Enabled = false;
            }
            catch
            {
                nino = null;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Tomar_Dato();
        }
        private void Tomar_Dato()
        {
            double datofloat = 0.0;

            if (nino != null)
            {

                dato = nino.Tomar_Dato();
                
            }
        }

        private void btnForm1_Click(object sender, EventArgs e)
        {

            // Mostrar el de registro
            Form1 Key = new Form1();

            this.AddOwnedForm(Key);
            Key.Show();
            this.Hide();

            

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            Cargar_Puertos();
        }

    }
}

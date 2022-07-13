using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PROYECTO_FINAL
{
    public partial class Form2 : Form
    {
        Arduino arduino = null;
        int dato = 0;
        public Form2()
        {
            InitializeComponent();
            panel1.Visible = false;
            btnIng1.Visible = false;
            brnIng2.Visible = false;
            brnIng3.Visible = false;
            brnIng4.Visible = false;
            brnIng5.Visible = false;
            brnIng6.Visible = false;
            brnIng7.Visible = false;
            brnIng8.Visible = false;
            brnIng9.Visible = false;
            brnIng0.Visible = false;
            btnDel.Visible = false;
            btnEnter.Visible = false;
            lblTitulo.Visible = false;
            txtLogin.Visible = false;


        }
        public static string Usuario = "";
        public static string Contraseña = "";
        bool[] usado= new bool[3];

        StreamReader Lector;
        string RutaUsuarios;
        private FilterInfoCollection Dispositivos;
        private VideoCaptureDevice FuenteDeVideo;

        public void NORecibir(string nombre)//Nombre de usuario
        {
            lblUsuario2.Text = nombre;
        }

        private void btnIng1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "1";
            }
            
        }

        private void brnIng2_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "2";
            }
        }

        private void brnIng3_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "3";
            }
        }

        private void brnIng4_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "4";
            }
        }

        private void brnIng5_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "5";
            }
        }

        private void brnIng6_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "6";
            }
        }

        private void brnIng7_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "7";
            }
        }

        private void brnIng8_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "8";
            }
        }

        private void brnIng9_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "9";
            }
        }

        private void brnIng0_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length != 6)
            {
                txtLogin.Text += "0";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != string.Empty)
            {
                txtLogin.Text = txtLogin.Text.Remove(txtLogin.Text.Length - 1, 1);
            }
            else
            { txtLogin.Text = "Usted no ha ingresado la clave"; }
        }

        //Empezamos la adquisicion de imagen

        private void Form2_Load(object sender, EventArgs e)
        {
            Dispositivos= new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo x in Dispositivos)
            {
                comboBox1.Items.Add(x.Name);
            }
            comboBox1.SelectedIndex=0;
            arduino = Form4.nino;
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            VideoCaptureDevice FuenteDeVideo = new VideoCaptureDevice(Dispositivos[comboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = FuenteDeVideo;
            videoSourcePlayer1.Start();
            panel1.Visible = true;
            panel1.Visible = true;
            btnIng1.Visible = true;
            brnIng2.Visible = true;
            brnIng3.Visible = true;
            brnIng4.Visible = true;
            brnIng5.Visible = true;
            brnIng6.Visible = true;
            brnIng7.Visible = true;
            brnIng8.Visible = true;
            brnIng9.Visible = true;
            brnIng0.Visible = true;
            btnDel.Visible = true;
            btnEnter.Visible = true;
            lblTitulo.Visible = true;
            txtLogin.Visible = true;
            timer1.Enabled = true;
                }
             
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 Invocar = Owner as Form1;
            Invocar.Show();
            this.Hide();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Usuario=lblUsuario2.Text;
            Contraseña = txtLogin.Text;
            bool permitir = false;

            for (int k = 1; k <= 3; k++)
            {
                RutaUsuarios = Application.StartupPath + "\\Usuarios\\Usuario" + k.ToString() + ".txt";

                try
                {
                    Lector = new StreamReader(RutaUsuarios);

                    while (Lector.Peek() > -1)
                    {
                        string lineaLeida = Lector.ReadLine();
                        string[] lineaDividida = lineaLeida.Split(';');

                        if (Usuario == lineaDividida[0] && Contraseña == lineaDividida[1])
                        {
                            permitir = true;
                            break;
                        }

                    }

                    if (permitir)
                        break;

                    Lector.Close();
                }
                catch
                {

                }
            }

            if (permitir)
            {
                //Aqui entra a la caja registradora
                MessageBox.Show("Ingreso satisfactorio.", "¡Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 Access = new Form3();
                this.AddOwnedForm(Access);
                Access.Show();
                Access.Recibir(lblUsuario2.Text);

                this.Hide();
            }
            else
            {
                //aqui va el llamado al arduino        
                Bitmap Imagen = videoSourcePlayer1.GetCurrentVideoFrame();
                pctFoto.Image = Imagen;
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
                //Guardar.ShowDialog();
                pctFoto.Image.Save("seguridad.jpg");//+consecutivo);+".jpg");
                MessageBox.Show("Contraseña incorrecta. Se ha tomado su Foto.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cambio;
            cambio = 1;

            if (arduino != null)
            {
                cambio = arduino.Tomar_Dato();
                if (cambio != 1)
                {
                    //aqui va el llamado al arduino        
                    Bitmap Imagen = videoSourcePlayer1.GetCurrentVideoFrame();
                    pctFoto.Image = Imagen;
                    SaveFileDialog Guardar = new SaveFileDialog();
                    Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
                    //Guardar.ShowDialog();

                    timer1.Enabled = false;

                    // pctFoto.Image.Save("seguridad"+ dato +".jpg");
                    dato += 1;

                    timer1.Enabled = true;
                }


            }
        }
        private void Tomar_Dato()
        {
            int cambio;
            cambio = 0;

            if (arduino != null)
            {
                cambio = arduino.Tomar_Dato();
                if (cambio != 0)
                {
                    timer1.Enabled = false;
                    // lbl0.Text = "Detecta cambio";
                    Bitmap Imagen = videoSourcePlayer1.GetCurrentVideoFrame();
                    pctFoto.Image = Imagen;
                    SaveFileDialog Guardar = new SaveFileDialog();
                    Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
                    //Guardar.ShowDialog();
                    pctFoto.Image.Save("seguridad.jpg");//+consecutivo);+".jpg");
                    timer1.Enabled = true;
                }

                
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                arduino.Cerrar_Puerto();
            }
            catch
            {
            }
        }

        private void pctFoto_Click(object sender, EventArgs e)
        {

        }

        
    
        }
               
    
        }


   


 

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


namespace PROYECTO_FINAL
{
    public partial class Form1 : Form
    {
        public static string Usuario = "";
        public static string Contraseña = "";
        public static string Rol = "";

       
        bool[] usado= new bool[3];

        StreamReader Lector;
        string RutaUsuarios;

        public Form1()
        {

            for (int i = 0; i < 3; i++)
            {
                usado[i] = false;
            }

            InitializeComponent();

            for (int k = 1; k <= 3; k++)
            {
                RutaUsuarios = Application.StartupPath + "\\Usuarios\\Usuario" + k.ToString() + ".txt";
                try
                {
                    Lector = new StreamReader(RutaUsuarios);
                    usado[k - 1] = true;

                    Lector.Close();
                }
                catch
                {

                }
            }
            combo.SelectedIndex = 1;
        }
        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = MessageBox.Show("¿Esta seguro?", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resultado == DialogResult.OK)
            {
                string ruta = Path.Combine(Application.StartupPath, "ManualdeUsuario.txt");
                System.Diagnostics.Process.Start(ruta);
            }
            else
            {
                MessageBox.Show("No se pudo abrir el Manual de Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void btnAcc_Click(object sender, EventArgs e)
        {
            Usuario = ingUser.Text;
            Contraseña = ingContra.Text;
            Rol = Convert.ToString(combo.Items[combo.SelectedIndex]);

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

                        if (Usuario == lineaDividida[0] && Contraseña == lineaDividida[1] && Rol == lineaDividida[2])
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
                Access.Recibir(ingUser.Text);

                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos No Encontrados ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //aqui entra a form2
                Form2 AccesoNeg = new Form2();
                this.AddOwnedForm(AccesoNeg);
                AccesoNeg.Show();
                AccesoNeg.NORecibir(ingUser.Text);

                this.Hide();
               
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Usuario = ingUser.Text;
            Contraseña = ingContra.Text;

            StreamWriter Creador;
            bool posible = false;

            for (int k = 1; k <= 3; k++)
            {
                RutaUsuarios = Application.StartupPath + "\\Usuarios\\Usuario" + k.ToString() + ".txt";

                if (!usado[k - 1])
                {
                    Creador = new StreamWriter(RutaUsuarios);
                    Creador.WriteLine(Usuario + ";" + Contraseña + ";" + combo.Items[combo.SelectedIndex]);
                    Creador.Close();
                    usado[k - 1] = true;
                    posible = true;
                    break;
                }
            }

            if (posible)
            {
                MessageBox.Show("Usuario nuevo creado.", "Creación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAcc_Click(null, null);
            }
            else
            {
                MessageBox.Show("No se pudo crear el usuario. Límite máximo (3) de usuarios alcanzado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



     

       
        
    }
}

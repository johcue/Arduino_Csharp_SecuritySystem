namespace PROYECTO_FINAL
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnActualizarPuertos = new System.Windows.Forms.Button();
            this.cboPuertos = new System.Windows.Forms.ComboBox();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnForm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActualizarPuertos
            // 
            this.btnActualizarPuertos.Location = new System.Drawing.Point(197, 78);
            this.btnActualizarPuertos.Name = "btnActualizarPuertos";
            this.btnActualizarPuertos.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarPuertos.TabIndex = 4;
            this.btnActualizarPuertos.Text = "Actualizar Puertos ";
            this.btnActualizarPuertos.UseVisualStyleBackColor = true;
            this.btnActualizarPuertos.Click += new System.EventHandler(this.btnActualizarPuertos_Click);
            // 
            // cboPuertos
            // 
            this.cboPuertos.FormattingEnabled = true;
            this.cboPuertos.Location = new System.Drawing.Point(12, 80);
            this.cboPuertos.Name = "cboPuertos";
            this.cboPuertos.Size = new System.Drawing.Size(179, 21);
            this.cboPuertos.TabIndex = 3;
            this.cboPuertos.SelectedIndexChanged += new System.EventHandler(this.cboPuertos_SelectedIndexChanged);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(160, 123);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 23);
            this.btnDetener.TabIndex = 5;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(46, 123);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cargar Puertos";
            // 
            // btnForm1
            // 
            this.btnForm1.Location = new System.Drawing.Point(160, 217);
            this.btnForm1.Name = "btnForm1";
            this.btnForm1.Size = new System.Drawing.Size(109, 23);
            this.btnForm1.TabIndex = 7;
            this.btnForm1.Text = "Abrir Registro";
            this.btnForm1.UseVisualStyleBackColor = true;
            this.btnForm1.Click += new System.EventHandler(this.btnForm1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnForm1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizarPuertos);
            this.Controls.Add(this.cboPuertos);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarPuertos;
        private System.Windows.Forms.ComboBox cboPuertos;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnForm1;
    }
}
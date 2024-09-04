namespace Login_Teste
{
    partial class RegisterForm
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
            panel1 = new Panel();
            campoConfirmaSenha = new TextBox();
            campoSenha = new TextBox();
            campoUsuario = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(campoConfirmaSenha);
            panel1.Controls.Add(campoSenha);
            panel1.Controls.Add(campoUsuario);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(12, 11);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 244);
            panel1.TabIndex = 3;
            // 
            // campoConfirmaSenha
            // 
            campoConfirmaSenha.Location = new Point(46, 120);
            campoConfirmaSenha.Margin = new Padding(3, 2, 3, 2);
            campoConfirmaSenha.Name = "campoConfirmaSenha";
            campoConfirmaSenha.PasswordChar = '*';
            campoConfirmaSenha.Size = new Size(174, 23);
            campoConfirmaSenha.TabIndex = 4;
            // 
            // campoSenha
            // 
            campoSenha.Location = new Point(46, 80);
            campoSenha.Margin = new Padding(3, 2, 3, 2);
            campoSenha.Name = "campoSenha";
            campoSenha.PasswordChar = '*';
            campoSenha.Size = new Size(174, 23);
            campoSenha.TabIndex = 3;
            // 
            // campoUsuario
            // 
            campoUsuario.Location = new Point(46, 35);
            campoUsuario.Margin = new Padding(3, 2, 3, 2);
            campoUsuario.Name = "campoUsuario";
            campoUsuario.Size = new Size(174, 23);
            campoUsuario.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(46, 164);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(173, 22);
            button1.TabIndex = 0;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(70, 201);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(125, 22);
            button2.TabIndex = 1;
            button2.Text = "Logar-se";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 265);
            Controls.Add(panel1);
            Name = "RegisterForm";
            Text = "Form3";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox campoConfirmaSenha;
        private TextBox campoSenha;
        private TextBox campoUsuario;
        private Button button1;
        private Button button2;
    }
}
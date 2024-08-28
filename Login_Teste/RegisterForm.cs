using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Login_Teste
{
    public partial class RegisterForm : Form
    {
        private UserManager userManager = new UserManager();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = campoUsuario.Text;
            string password = campoSenha.Text;
            string confirmPassword = campoConfirmaSenha.Text;

            string resultado = userManager.Registrar(username, password, confirmPassword);

            MessageBox.Show(resultado);

            if (resultado == "Usuário registrado com sucesso!")
            {
                LoginForm form1 = new LoginForm();
                this.Hide();
                form1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm form1 = new LoginForm();
            this.Hide();
            form1.Show();
        }
    }
}

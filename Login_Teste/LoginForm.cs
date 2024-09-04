using System.Text;
using System.Security.Cryptography;

namespace Login_Teste
{
    public partial class LoginForm : Form
    {

        private UserManager userManager = new UserManager();

        public LoginForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string username = campoUsuario.Text;
            string password = campoSenha.Text;

            // Chama o método Logar da classe UserManager
            string resultado = userManager.Logar(username, password);

            MessageBox.Show(resultado);

            if (resultado == "Logado com sucesso!")
            {
                HomeForm form2 = new HomeForm();
                this.Close();
                form2.Show();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //abrir formulario de registro
            RegisterForm form3 = new RegisterForm();
            this.Hide();
            form3.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Ruan Lindo";
        }
    }
}

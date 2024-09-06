using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RedeSocial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new UserManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tabMenu.SelectedIndex == 1)
            {
                tabMenu.Height = 533;
            }
            else
            {
                tabMenu.Height = 358;
            }
        }

        private void ButtonEntrar_Click(object sender, RoutedEventArgs e)
        {
            string username = areaUsuario.Text;
            string password = areaSenha.Password;

            // Chama o método Logar da classe UserManager
            string resultado = userManager.Logar(username, password);

            MessageBox.Show(resultado);

            // Abre a tela principal (mas ainda não tem T_T)
            /*if (resultado == "Logado com sucesso!")
            {
                Principal form2 = new Principal();
                this.Close();
                form2.Show();
            }*/
        }

        private void buttonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string username = areaID.Text;
            string password = areaSenhaCadastro.Password;
           
            string confirmPassword = areaRepetirSenha.Password;

            string resultado = userManager.Registrar(username, password, confirmPassword);

            MessageBox.Show(resultado);

            //Como tá na mesma tela, não vai precisar disso. Mas dá pra colocar pra entrar direto na tela principal ou voltar pro tab de login
            if (resultado == "Usuário registrado com sucesso!")
            {
                /*LoginForm form1 = new LoginForm();
                this.Hide();
                form1.Show();*/

                //Apaga os campos
                areaID.Clear();
                areaSenhaCadastro.Clear();
                areaRepetirSenha.Clear();
                areaEmail.Clear();
                areaNome.Clear();
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

  
        private void areaSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(areaSenha.Password))
            {
                labelSenha.Text = "Senha";
            }
            else
            {
                labelSenha.Text = string.Empty;
            }
        }

        private void areaSenhaCadastro_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(areaSenhaCadastro.Password))
            {
                labelSenhaCadastro.Text = "Senha";
            }
            else
            {
                labelSenhaCadastro.Text = string.Empty;

            }
        }

        private void areaRepetirSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(areaRepetirSenha.Password))
            {
                labelRepetirSenha.Text = " Repetir senha";
            }
            else
            {
                labelRepetirSenha.Text = string.Empty;

            }

        }
    }
}
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
            if (tabMenu.SelectedIndex == 1)
            {
                tabMenu.Height = 533;
            }
            else
            {
                tabMenu.Height = 358;
            }
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

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string email = areaEmail.Text;
            string id = areaID.Text;
            string password = areaSenhaCadastro.Password;
            string confirmPassword = areaRepetirSenha.Password;
            string fullName = areaNome.Text;

            if (!AreaNascimento.SelectedDate.HasValue)
            {
                MessageBox.Show("Por favor, selecione uma data de nascimento.");
                return;
            }
            DateOnly birthDate = DateOnly.FromDateTime(AreaNascimento.SelectedDate.Value);

            string resultado = userManager.Registrar(email, id, password, confirmPassword, fullName, birthDate);
            MessageBox.Show(resultado);

            if (resultado == "Usuário registrado com sucesso!")
            {
                //Apaga os campos
                /*areaEmail.Clear();
                areaID.Clear();
                areaSenhaCadastro.Clear();
                areaRepetirSenha.Clear();
                areaNome.Clear();
                AreaNascimento.SelectedDate = null; */
                tabMenu.SelectedIndex = 0;
            }
        }

        private void botaoEntrar_Click(object sender, RoutedEventArgs e)
        {
            string email = areaEmail.Text;
            string password = areaSenha.Password;

            string resultado = userManager.Logar(email, password);
            MessageBox.Show(resultado);


            if (resultado == "Logado com sucesso!")
            {
                Home homeWindow = new();
                homeWindow.Show();
                this.Close();
            }
        }
    }
}
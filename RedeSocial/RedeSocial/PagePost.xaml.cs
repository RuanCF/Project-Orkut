using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace RedeSocial
{
    /// <summary>
    /// Interação lógica para PagePost.xam
    /// </summary>
    public partial class PagePost : Page
    {
        private PostManager postManager = new PostManager();
        private UserManager userManager = new UserManager();

        int codUsuario;
        string enderecoMidia;
        string exibicaoPost;
        string projectPath; //Caminho até o projeto para poder adicionar fotos e ícones
        public PagePost(int codUser)
        {
            InitializeComponent();

            //Atribuições para teste
            exibicaoPost = "proprio";
            codUsuario = codUser;
            enderecoMidia = "";
            projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            projectPath = projectPath.Remove(projectPath.Length - 4);

            //Altera o fundo
            //fundo.ImageSource = new BitmapImage(new Uri(projectPath + "\\Fundo\\fundoPadraoBranco.jpg", UriKind.RelativeOrAbsolute));

            atualizarPaginaPostProprio();

            botaoPostProprio.Background = Brushes.Gray;
        }

        //Coloca todos os posts do próprio usuário na página
        public void atualizarPaginaPostProprio()
        {
            gridPosts.Children.Clear();

            for (int i = postManager.BuscarQuantidade() - 1; i >= 0; i--)
            {
                if (postManager.VerificarPostProprio(i, codUsuario))
                {
                    publicarPost(i);
                }
            }
        }

        //Coloca todos os posts de todos na página
        public void atualizarPaginaPostGeral()
        {
            gridPosts.Children.Clear();

            for (int i = postManager.BuscarQuantidade() - 1; i >= 0; i--)
            {
                publicarPost(i);
            }
        }

        //Insere o post na página
        public void publicarPost(int i)
        {
            //Cria a grid do autor
            Grid gridAutor = new Grid();
            gridAutor.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            gridAutor.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            gridAutor.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            gridAutor.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            //Grid para os botões Curtir e Recomendar
            Grid gridBotoes = new Grid();
            gridBotoes.ColumnDefinitions.Add(new ColumnDefinition());//Botão curtir
            gridBotoes.ColumnDefinitions.Add(new ColumnDefinition());//Botão recomendar
            //Borda do gridBotoes
            Border borderBotoes = new Border()
            {
                BorderBrush = Brushes.DarkGray,
                BorderThickness = new Thickness(0, 1, 0, 1)
            };
            borderBotoes.Child = gridBotoes;

            //Botão curtir 
            Grid gridCurtir = new Grid();
            gridCurtir.ColumnDefinitions.Add(new ColumnDefinition());//Ícone curtir
            gridCurtir.ColumnDefinitions.Add(new ColumnDefinition());//Quantidade de curtidas
            //Ícone curtir
            Image newIconeCurtir = new Image()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 20,
                Width = 20,
                Margin = new Thickness(10),
                Source = new BitmapImage(new Uri(projectPath + "\\Icones\\Like.png", UriKind.RelativeOrAbsolute))
            };
            //Quantidade de curtidas
            TextBlock newQuantidadeCurtida = new TextBlock()
            {
                Text = postManager.buscarQuantidadeLike(i).ToString(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 14
            };
            gridCurtir.MouseLeftButtonUp += (sender, e) => gridCurtir_Click(sender, e, i, gridCurtir, newQuantidadeCurtida);
            Grid.SetColumn(newIconeCurtir, 0);
            Grid.SetColumn(newQuantidadeCurtida, 1);
            gridCurtir.Children.Add(newIconeCurtir);
            gridCurtir.Children.Add(newQuantidadeCurtida);

            //Botão recomendar
            Grid gridRecomendar = new Grid();
            //Texto recomendar
            TextBlock newRecomendar = new TextBlock()
            {
                Text = "Recomendar",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 14
            };
            gridRecomendar.Children.Add(newRecomendar);

            //Cria o balão
            Grid gridPostCorpo = new Grid();
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Autor do post
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Título
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Texto
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Mídia
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Quantidade de Likes, comentários e recomendações
            gridPostCorpo.RowDefinitions.Add(new RowDefinition());//Botão Curtir, Comentar e Recomendar

            //Cria uma nova row no gridMensagens
            gridPosts.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            //Cria a foto do autor
            Ellipse newAutorFoto = new Ellipse()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 45,
                Width = 45,
                Stroke = Brushes.DarkGray,
                Margin = new Thickness(10),
                Fill = new ImageBrush(new BitmapImage(new Uri(userManager.BuscarFoto(postManager.BuscarRemetente(i)), UriKind.Relative)))
            };

            //Cria o nome do autor
            TextBlock newAutorNome = new TextBlock()
            {
                Text = userManager.BuscarNome(postManager.BuscarRemetente(i)),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5, 15, 0, 0)
            };

            //Cria a data e horário
            TextBlock newDataHora = new TextBlock()
            {
                Text = postManager.BuscarData(i),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5, -10, 0, 0)
            };

            //Cria o título
            TextBlock newTitulo = new TextBlock()
            {
                Text = postManager.BuscarTitulo(i),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 16,
                Margin = new Thickness(15, 5, 15, 5)
            };

            //Cria o texto
            // Usa RichTextBox para manter a formatação do texto
            RichTextBox newTexto = new RichTextBox()
            {
                Padding = new Thickness(15,0,0,0),
                Style = (Style)FindResource("RichTextBoxPost")
            };
            newTexto.IsReadOnly = true; // Define RichTextBox como somente leitura
            newTexto.Document.Blocks.Clear();

            // Carrega o texto formatado do Xaml armazenado
            string textoFormatado = postManager.BuscarTexto(i);
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(textoFormatado)))
            {
                TextRange range = new TextRange(newTexto.Document.ContentStart, newTexto.Document.ContentEnd);
                range.Load(stream, DataFormats.Xaml);
            }

            //Cria a foto do post
            Image newMidia = new Image()
            {
                Source = new BitmapImage(new Uri(postManager.BuscarMidia(i), UriKind.RelativeOrAbsolute)),
                MaxHeight = 150,
                MaxWidth = 150,
                Margin = new Thickness(0, 0, 0, 10)
            };

            //Cria a borda arredondada
            Border border = new Border()
            {
                Background = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0, 10, 0, 0),
                CornerRadius = new CornerRadius(5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Child = gridPostCorpo
            };

            //Adiciona a borda no gridMensagens
            gridPosts.Children.Add(border);

            //Adiciona a foto e nome na gridAutor
            Grid.SetRow(newAutorFoto, 0);
            Grid.SetRowSpan(newAutorFoto, 2);
            Grid.SetColumn(newAutorFoto, 0);
            Grid.SetRow(newAutorNome, 0);
            Grid.SetColumn(newAutorNome, 1);
            Grid.SetRow(newDataHora, 1);
            Grid.SetColumn(newDataHora, 1);
            gridAutor.Children.Add(newAutorFoto);
            gridAutor.Children.Add(newAutorNome);
            gridAutor.Children.Add(newDataHora);

            //Adiciona os botões na gridBotoes
            Grid.SetColumn(gridCurtir, 0);
            Grid.SetColumn(gridRecomendar, 1);
            gridBotoes.Children.Add(gridCurtir);
            gridBotoes.Children.Add(gridRecomendar);

            //Adiciona tudo no gridPostCorpo
            Grid.SetRow(gridAutor, 0);
            Grid.SetRow(newTitulo, 1);
            Grid.SetRow(newTexto, 2);
            Grid.SetRow(newMidia, 3);
            Grid.SetRow(borderBotoes, 4);
            gridPostCorpo.Children.Add(gridAutor);
            gridPostCorpo.Children.Add(newTitulo);
            gridPostCorpo.Children.Add(newTexto);
            gridPostCorpo.Children.Add(newMidia);
            gridPostCorpo.Children.Add(borderBotoes);

            //Adiciona o post na tela
            Grid.SetRow(border, gridPosts.RowDefinitions.Count - 1);
            Grid.SetColumn(border, 0);

            //Altera a cor do botão do like
            alterarCorBotaoLike(i, gridCurtir);
        }

        //Função do botão Curtir
        private void gridCurtir_Click(object sender, EventArgs e, int i, Grid grid, TextBlock textBlock)
        {
            if (!postManager.verificarUsuarioLike(i, codUsuario))
            {
                postManager.AdicionarLike(i, codUsuario);
                grid.Background = new SolidColorBrush(Colors.PowderBlue);
                textBlock.Text = postManager.buscarQuantidadeLike(i).ToString();
            }
            else
            {
                postManager.RemoverLike(i, codUsuario);
                grid.Background = new SolidColorBrush(Colors.White);
                textBlock.Text = postManager.buscarQuantidadeLike(i).ToString();
            }
        }

        private void alterarCorBotaoLike(int i, Grid grid)
        {
            if (postManager.verificarUsuarioLike(i, codUsuario))
            {
                grid.Background = new SolidColorBrush(Colors.PowderBlue);
            }
            else
            {
                grid.Background = new SolidColorBrush(Colors.White);
            }
        }

        //Apagar a label "Título" quando digitar
        private void campoTitulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(campoTitulo.Text))
            {
                labelTitulo.Visibility = Visibility.Visible;
            }
            else
            {
                labelTitulo.Visibility = Visibility.Hidden;
            }
        }

        //Apagar a label "Texto" quando digitar
        private void campoTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(campoTexto.Document.ContentStart, campoTexto.Document.ContentEnd);
            string texto = textRange.Text.Trim();
            if (String.IsNullOrEmpty(texto))
            {
                labelTexto.Visibility = Visibility.Visible;
            }
            else
            {
                labelTexto.Visibility = Visibility.Hidden;
            }
        }

        //Botão para postar o post
        private void botaoPostar_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(campoTexto.Document.ContentStart, campoTexto.Document.ContentEnd);
            string textoFormatado;
            using (MemoryStream stream = new MemoryStream())
            {
                textRange.Save(stream, DataFormats.Xaml);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    textoFormatado = reader.ReadToEnd();
                }
            }

            // Verifica se o texto formatado contém apenas a estrutura vazia do XAML
            bool isRichTextBoxEmpty = string.IsNullOrWhiteSpace(textRange.Text.Trim()) || textoFormatado.Trim().Equals("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" />");

            if (isRichTextBoxEmpty && string.IsNullOrEmpty(enderecoMidia))
            {
                MessageBox.Show("Escreva algum texto ou selecione uma imagem.");
            }
            else
            {
                postManager.ArmazenarPost(codUsuario, campoTitulo.Text, textoFormatado, enderecoMidia, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                campoTitulo.Clear();
                campoTexto.Document.Blocks.Clear(); // Limpar o RichTextBox
                enderecoMidia = "";

                removerPrevia(); // Remove a prévia da foto após postar
                botaoImagem.Content = "Selecionar imagem";
            }

            if (exibicaoPost == "proprio")
            {
                atualizarPaginaPostProprio();
            }
            else if (exibicaoPost == "geral")
            {
                atualizarPaginaPostGeral();
            }
        }
        //Permite selecionar uma foto para a postagem
        private void botaoImagem_Click(object sender, RoutedEventArgs e)
        {
            if (enderecoMidia == "")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == true)
                {
                    enderecoMidia = openFileDialog.FileName;
                    previaFoto();
                    botaoImagem.Content = "Remover imagem";
                }
            }
            else
            {
                enderecoMidia = "";
                removerPrevia();
                botaoImagem.Content = "Selecionar imagem";
            }
        }

        private void botaoNegrito_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = campoTexto.Selection;
            if (!selectedText.IsEmpty)
            {
                if (selectedText.GetPropertyValue(TextElement.FontWeightProperty).Equals(FontWeights.Bold))
                {
                    selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            }
        }

        private void botaoItalico_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = campoTexto.Selection;
            if (!selectedText.IsEmpty)
            {
                if (selectedText.GetPropertyValue(TextElement.FontStyleProperty).Equals(FontStyles.Italic))
                {
                    selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                }
            }
        }

        private void botaoSublinhado_Click(object sender, RoutedEventArgs e)
        {
            TextSelection selectedText = campoTexto.Selection;
            if (!selectedText.IsEmpty)
            {
                TextDecorationCollection textDecorations = (TextDecorationCollection)selectedText.GetPropertyValue(Inline.TextDecorationsProperty);
                if (textDecorations == TextDecorations.Underline)
                {
                    selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                }
                else
                {
                    selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                }
            }
        }

        //Mostra uma prévia da foto selecionada
        private void previaFoto()
        {
            BitmapImage minhaBitmapImage = new BitmapImage();
            minhaBitmapImage.BeginInit();
            minhaBitmapImage.UriSource = new Uri(enderecoMidia, UriKind.RelativeOrAbsolute);
            minhaBitmapImage.EndInit();

            Image newMidia = new Image()
            {
                Source = minhaBitmapImage,
                MaxHeight = 150,
                MaxWidth = 150,
                Margin = new Thickness(0, 10, 0, 0)
            };

            Grid.SetRow(newMidia, 2);
            gridFormPost.Children.Add(newMidia);
        }

        //Remove a prévia da foto
        private void removerPrevia()
        {
            var elementsInRow = gridFormPost.Children.Cast<UIElement>().Where(n => Grid.GetRow(n) == 2).ToList();
            foreach (var element in elementsInRow)
            {
                gridFormPost.Children.Remove(element);
            }
        }

        //Mostrar postagens próprias
        private void botaoPostProprio_Click(object sender, RoutedEventArgs e)
        {
            atualizarPaginaPostProprio();
            exibicaoPost = "proprio";

            botaoPostProprio.Background = Brushes.Gray;
            botaoPostGeral.Background = Brushes.White;
        }

        //Mostrar postagens de todos
        private void botaoPostGeral_Click(object sender, RoutedEventArgs e)
        {
            atualizarPaginaPostGeral();
            exibicaoPost = "geral";

            botaoPostProprio.Background = Brushes.White;
            botaoPostGeral.Background = Brushes.Gray;
        }
    }
}

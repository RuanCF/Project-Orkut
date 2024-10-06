using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Controls;

namespace RedeSocial.Models
{
    public class Teste
    {
        UserManager usuarioManager = new UserManager();
        PostManager postManager = new PostManager();
        RichTextBox richTextBox;
        public void AdicionarUsuario()
        {
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            projectPath = projectPath.Remove(projectPath.Length - 4);
            usuarioManager.AdicionarUsuario("jojo@email.com", "jojo", "123123", "Johnny Mukai", new DateOnly(2000, 12, 13), projectPath + "\\Fotos\\Pukki.jpg");
            usuarioManager.AdicionarUsuario("gojojo@email.com", "gojojo", "123123", "Satoru Gojo", new DateOnly(1996, 12, 07), projectPath + "\\Fotos\\Gojo.jpg");
            usuarioManager.AdicionarUsuario("jeje@email.com", "jeje", "123123", "Jennifer Lawrence", new DateOnly(1990, 08, 15), projectPath + "\\Fotos\\Jennifer.jpeg");
            usuarioManager.AdicionarUsuario("gigi@email.com", "gigi", "123123", "Luigi", new DateOnly(1981, 10, 11), projectPath + "\\Fotos\\Luigi.png");
        }

        public void AdicionarAmigo()
        {
            usuarioManager.AdicionarAmigo(0, 2);
            usuarioManager.AdicionarAmigo(2, 0);
        }

        public void AdicionarPost()
        {
            postManager.ArmazenarPost(0, "El Pudinho", FormatarTextoPost("Fiz um pudim muito bom!"), "", "22/09/2024 10:10");
            postManager.ArmazenarPost(1, "", FormatarTextoPost("Alguém sabe onde eu coloquei minha carteira?"), "", "22/09/2024 10:54");
            postManager.ArmazenarPost(0, "", FormatarTextoPost("Olha esse elefante gigante"), "", "22/09/2024 11:13");
            postManager.ArmazenarPost(1, "", FormatarTextoPost("Deixa o Like!"), "", "23/09/2024 15:33");
            postManager.ArmazenarPost(3, "", FormatarTextoPost("Que Mario?"), "", "23/09/2024 19:27");
            postManager.ArmazenarPost(2, "", FormatarTextoPost("Estou com fome"), "", "24/09/2024 01:11");
        }

        public void AdicionarLike()
        {
            postManager.AdicionarLike(0, 2);
            postManager.AdicionarLike(0, 3);
            postManager.AdicionarLike(0, 4);
            postManager.AdicionarLike(1, 4);
            postManager.AdicionarLike(4, 2);
        }

        public void AdicionarComentario()
        {
            postManager.AdicionarComentario(2, 1, "Comentário legal!");
            postManager.AdicionarComentario(2, 2, "Comentário legal 2!");
            postManager.AdicionarComentario(5, 0, "UHUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU");
        }

        public void AdicionarRecomendar()
        {
            postManager.AdicionarRecomendador(4, 2);
        }

        public string FormatarTextoPost(string texto)
        {
            richTextBox = new RichTextBox()
            {
                FontSize = 14
            };

            richTextBox.AppendText(texto);
            TextRange tempTextRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            string TextoFormatado;
            using (MemoryStream stream = new MemoryStream())
            {
                tempTextRange.Save(stream, DataFormats.Xaml);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    TextoFormatado = reader.ReadToEnd();
                }
            }
            return TextoFormatado;
        }
    }
}

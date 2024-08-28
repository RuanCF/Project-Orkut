using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Login_Teste
{
    internal class UserManager
    {
        // Dicionário para armazenar usuários (username, passwordHash)
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        // Método para criar o hash da senha
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Registrar um novo usuário
        public string Registrar(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return "Não é permitido espaço em branco no nome de usuário.";
            }

            if (string.IsNullOrWhiteSpace(password) && string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Não é permitido espaço em branco no na senha.";
            }

            if (password != confirmPassword)
            {
                return "As senhas não coincidem. Tente novamente.";
            }

            if (users.ContainsKey(username))
            {
                return "Nome de usuário já existe. Tente novamente.";
            }

            string passwordHash = HashPassword(password);
            users.Add(username, passwordHash);
            return "Usuário registrado com sucesso!";
        }

        //Realizar login
        public string Logar(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return "Não é permitido espaço em branco no nome de usuário.";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "Não é permitido espaço em branco no na senha.";
            }

            if (!users.ContainsKey(username))
            {
                return "Usuário não encontrado!";
            }

            string passwordHash = HashPassword(password);
            if (users[username] == passwordHash)
            {
                return "Logado com sucesso!";
            }
            else
            {
                return "Senha ou usuário incorretos!";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace RedeSocial
{
    public class User
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }
    }

    public class UserManager
    {
        private const int AgeLimit = 16; // Limite de idade mínima

        // Dicionário para armazenar usuários e suas informações
        // Dicionário para armazenar usuários e suas informações
        private static Dictionary<string, User> users = new Dictionary<string, User>();

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

        // Verifica se a pessoa tem pelo menos 16 anos
        private bool IsValidAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) age--; // Ajusta a idade caso o aniversário não tenha ocorrido ainda este ano

            return age >= AgeLimit;
        }

        // Valida o formato do email
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Valida o formato da senha
        private bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }

        // Valida o formato do telefone
        private bool IsValidPhone(string phone)
        {
            string phonePattern = @"^\(\d{2}\)\d{5}-\d{4}$";
            return Regex.IsMatch(phone, phonePattern);
        }

        // Registrar um novo usuário
        public string Registrar(string email, string password, string confirmPassword, string fullName, string phone, DateTime birthDate)
        {
            /////////////////// EMAIL  /////////////////
            if (string.IsNullOrWhiteSpace(email))
            {
                return "O email não pode ser vazio.";
            }
            if (!IsValidEmail(email))
            {
                return "O email não é válido.";
            }
            if (users.ContainsKey(email))
            {
                return "Email já cadastrado. Tente novamente.";
            }
            ///////////////////////////////////////////
            /////////////////// Senha ////////////////
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                return "Não é permitido espaço em branco na senha.";
            }
            if (!IsValidPassword(password))
            {
                return "A senha deve ter pelo menos 6 caracteres.";
            }
            if (password != confirmPassword)
            {
                return "As senhas não coincidem. Tente novamente.";
            }
            ///////////////////////////////////////////
            ///////////////// Nome ///////////////////
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "O nome completo não pode ser vazio.";
            }
           
            ///////////////////////////////////////
            ///////////// Data Nascimento ////////
            if (!IsValidAge(birthDate))
            {
                return $"Você deve ter pelo menos {AgeLimit} anos para se registrar.";
            }
            /////////////////////////////////////
            ///
            string passwordHash = HashPassword(password);

            // Criar novo usuário
            User newUser = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                FullName = fullName,
                BirthDate = birthDate
            };

            users.Add(email, newUser);
            return "Usuário registrado com sucesso!";
        }

        // Realizar login usando o Email
        public string Logar(string email, string password)
        {
            if (!users.ContainsKey(email))
            {
                return "Usuário não encontrado!";
            }

            string passwordHash = HashPassword(password);
            if (users[email].PasswordHash == passwordHash)
            {
                return "Logado com sucesso!";
            }
            else
            {
                return "Senha ou email incorretos!";
            }
        }

        // Obter usuário pelo Email
        public User ObterUsuario(string email)
        {
            if (users.ContainsKey(email))
            {
                return users[email];
            }
            return null;
        }
    }
}

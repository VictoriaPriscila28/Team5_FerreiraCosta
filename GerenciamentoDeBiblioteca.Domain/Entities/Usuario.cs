using GerenciamentoDeBiblioteca.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public Usuario(int id, string nome, string email)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(nome, email);

        }

        public Usuario(string nome, string email)
        {
           ValidateDomain(nome,email);
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

       

        private void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(nome.Length > 250, "O nome não pode ultrapassar de 250 caracteres.");
            DomainExceptionValidation.When(email.Length > 200, "O email não pode ultrapassar de 200 caracteres.");
            DomainExceptionValidation.When(nome == null, "O nome é obrigatório.");
            DomainExceptionValidation.When(email == null, "O email é obrigatório.");

            Nome = nome;
            Email = email;
        }
    }
}

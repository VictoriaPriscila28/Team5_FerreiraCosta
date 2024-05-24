using GerenciamentoDeBiblioteca.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string CliCPF { get; private set; }
        public string CliNome { get; private set; }
        public string CliEndereco {get; private set;}
        public string CliCidade { get; private set; }
        public string CliBairro { get; private set; }
        public string CliNumero { get; private set; }
        public string CliTelefoneCelular { get; private set; }
        public string CliTelefoneFixo { get; private set; }



        public Cliente(int id, string cliCPF, string cliNome, string cliEndereco,
            string cliCidade, string cliBairro, string cliNumero,
            string cliTelefoneCelular, string cliTelefoneFixo)
        {
            DomainExceptionValidation.When(id < 0, "O Id do cliente deve ser positivo.");
            Id =id;
            ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro,
                cliNumero, cliTelefoneCelular, cliTelefoneFixo);

        }

        public Cliente(string cliCPF, string cliNome, string cliEndereco,
            string cliCidade, string cliBairro, string cliNumero,
            string cliTelefoneCelular,string cliTelefoneFixo)
        {
           
          ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro,
              cliNumero, cliTelefoneCelular, cliTelefoneFixo);
            
        }

        public void Update(string cliCPF, string cliNome, string cliEndereco,
            string cliCidade, string cliBairro, string cliNumero,
            string cliTelefoneCelular, string cliTelefoneFixo)
        {
            ValidateDomain(cliCPF, cliNome, cliEndereco, cliCidade, cliBairro,
             cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }

        public void ValidateDomain(string cliCPF, string cliNome, string cliEndereco,
            string cliCidade, string cliBairro, string cliNumero,
            string cliTelefoneCelular, string cliTelefoneFixo)
        {
            DomainExceptionValidation.When(cliCPF.Length != 11, "O CPF deve ter 11 caracteres.");
            DomainExceptionValidation.When(cliNome.Length > 200, "O nome deve ter, no máximo, 200 caracteres.");
            DomainExceptionValidation.When(cliEndereco.Length > 50, "O endereço deve ter, no máximo, 50 caracteres.");
            DomainExceptionValidation.When(cliCidade.Length > 50, "A cidade deve ter, no máximo, 50 caracteres.");
            DomainExceptionValidation.When(cliBairro.Length > 50, "O bairro deve ter,no máximo, 50 caracteres.");
            DomainExceptionValidation.When(cliNumero.Length > 20 , "O número deve ter, no máximo, 20 caracteres.");
            DomainExceptionValidation.When(cliTelefoneCelular.Length > 11, "O celular deve ter, no máximo, 11 caracteres.");
            DomainExceptionValidation.When(cliTelefoneFixo.Length != 10, "O telefone fixo deve ter, no máximo 10 caracteres.");

            CliCPF = cliCPF;
            CliNome = cliNome;
            CliEndereco = cliEndereco;
            CliCidade = cliCidade;
            CliBairro = cliBairro;
            CliNumero = cliNumero;
            CliTelefoneCelular = cliTelefoneCelular;
            CliTelefoneFixo = cliTelefoneFixo;
        }
    }
}

using System.ComponentModel;

namespace GerenciamentoDeBiblioteca_core.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Negado")]
        Negado = 2,
        [Description("Devolvido")]
        Devolvido = 3,
    }
}

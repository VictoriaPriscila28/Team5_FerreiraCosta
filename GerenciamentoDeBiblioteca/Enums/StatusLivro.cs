using System.ComponentModel;

namespace GerenciamentoDeBiblioteca.Enums
{
    public enum StatusLivro
    {
        [Description ("Disponivel")]
        Disponivel = 1,
        [Description ("Emprestado")]
        Emprestado = 2,
        [Description ("Devolvido")]
        Devolvido = 3,




    }
}

using GerenciamentoDeBiblioteca_core.ModificarEntidades;

namespace GerenciamentoDeBiblioteca.Respostas
{
    public class RespostasApi<T>
    {
        public RespostasApi(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadado Meta { get; set; }
    }
}

namespace Projeto_Confitec.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(int idUsuario, string nomeUsuario, string sobrenomeUsuario, string emailUsuario, DateTime dataNascimento, int nivelEscolarId) 
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            SobrenomeUsuario= sobrenomeUsuario; 
            EmailUsuario= emailUsuario;
            DataNascimento = dataNascimento;
            NivelEscolarId = nivelEscolarId;

        }
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string SobrenomeUsuario { get; set; }

        public string EmailUsuario { get; set; }

        public DateTime DataNascimento { get; set; }

        public NivelEscolar NivelEscolar { get; set; }

        public int NivelEscolarId { get; set; }
    }
}

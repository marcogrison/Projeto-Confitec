namespace Projeto_Confitec.Models
{
    public class NivelEscolar
    {
        public NivelEscolar() { }

        public NivelEscolar(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set;}
    }
}

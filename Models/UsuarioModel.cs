namespace gestao_residuos.Models
{
    public class UsuarioModel
    {

        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }

    }
}

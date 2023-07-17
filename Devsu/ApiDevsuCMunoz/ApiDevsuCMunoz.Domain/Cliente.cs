namespace ApiDevsuCMunoz.Domain
{
    public class Cliente : Persona
    {
        public long Id { get; set; }
        public string? Contrasenia { get; set; }
        public string? Estado { get; set; }
    }
}

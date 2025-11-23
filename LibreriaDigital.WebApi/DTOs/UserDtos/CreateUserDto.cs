namespace LibreriaDigital.WebApi.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}

namespace programacion2proyecto
{

    using System;
    using System.Text.RegularExpressions;

    namespace programacion2proyecto.Models
    {
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public string Direccion { get; set; }
            public DateTime FechaRegistro { get; set; }

            public static bool ValidarEmail(string email)
            {
                string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, patron);
            }

            public static bool ValidarTelefono(string telefono)
            {
                string patron = @"^\+?[0-9]{8,15}$";
                return Regex.IsMatch(telefono, patron);
            }

            public override string ToString()
            {
                return $"Cliente: {Nombre} | Email: {Email} | Tel: {Telefono}";
            }
        }
    }
    public class Cliente
    {
    }
}

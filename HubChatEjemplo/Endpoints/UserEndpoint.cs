using HubChatEjemplo.Data;
using HubChatEjemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace HubChatEjemplo.Endpoints
{
    public static class UserEndpoint
    {
        public static void MapUsuarioEndpoints(this WebApplication app)
        {
            // GET: Buscar usuario por correo
            app.MapGet("/api/usuarios", async (string email, AppDbContext db) =>
            {
                var usuario = await db.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email);

                return usuario is not null
                    ? Results.Ok(usuario)
                    : Results.NotFound($"No se encontró el usuario con el correo: {email}");
            });
        }
    }
}

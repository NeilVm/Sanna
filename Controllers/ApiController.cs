using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registrosanna.Data;
using registrosanna.Models;
using registrosanna.Services;

namespace registrosanna.Controllers
{
    [ApiController]
    [Route("Sanna")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        public ApiController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        [HttpPost]
        [Route("registrar")]
        public IActionResult GuardarRegistro([FromBody] Registro registro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioExistente = _context.Registros.FirstOrDefault(r => r.Documento == registro.Documento);
                    if (usuarioExistente != null)
                    {
                        return BadRequest("El Usuario ya está registrado.");
                    }

                    // Hash de la contraseña antes de almacenarla
                    string contrasenaPlana = registro.ContrasenaHash;
                    string contrasenaHash = BCrypt.Net.BCrypt.HashPassword(contrasenaPlana);
                    registro.ContrasenaHash = contrasenaHash;

                    // Agregar el nuevo registro
                    _context.Registros.Add(registro);
                    _context.SaveChanges();

                    return Ok(new { message = "Usuario Registrado" });
                }

                // Manejo de validación de modelo
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { errors });
            }
            catch (Exception ex)
            {
                // Manejo de errores inesperados
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            string documento = loginRequest.Documento;
            string contrasena = loginRequest.Contrasena;


            bool isAuthenticated = await _authService.AuthenticateAsync(documento, contrasena);

            if (isAuthenticated)
            {
                return Ok("Autenticación exitosa");
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }
        }

        public class LoginRequest
        {
            public string Documento { get; set; }
            public string Contrasena { get; set; }
        }
    }
}


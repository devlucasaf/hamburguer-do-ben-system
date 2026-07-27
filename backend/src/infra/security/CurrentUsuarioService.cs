using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HamburguerDoBenSystem.Backend.src.infra.security;

public class CurrentUsuarioService : ICurrentUsuarioService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUsuarioService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? Usuario => _httpContextAccessor.HttpContext?.User;
    public bool UsuarioEstaAutenticado => Usuario?.Identity?.IsAuthenticated ?? false;

    // --- PARSE DA CLAIM "sub" PARA long ---
    public long? UsuarioId
    {
        get
        {
            string? valor = LerClaim(JwtRegisteredClaimNames.Sub);

            if (long.TryParse(valor, out long id))
            {
                return id;
            }

            return null;
        }
    }

    public string? Email => LerClaim(JwtRegisteredClaimNames.Email);
    public string? Nome => LerClaim(JwtRegisteredClaimNames.Name);
    public string? Cargo => LerClaim(ClaimTypes.Role);

    // --- SÓ PRESENTE EM TOKENS DE CLIENTE ---
    public long? SessaoId
    {
        get
        {
            string? valor = LerClaim("sessaoId");
            return long.TryParse(valor, out long id) ? id : null;
        }
    }

    // --- SÓ PRESENTE EM TOKENS DE CLIENTE ---
    public int? NumeroMesa
    {
        get
        {
            string? valor = LerClaim("numeroMesa");
            return int.TryParse(valor, out int numero) ? numero : null;
        }
    }

    // --- HELPER QUE BUSCA UMA CLAIM PELO TIPO E RETORNA NULL SE NÃO EXISTIR ---
    private string? LerClaim(string tipo)
    {
        return Usuario?.FindFirst(tipo)?.Value;
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using HamburguerDoBenSystem.Backend.src.modules.identidade.model;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HamburguerDoBenSystem.Backend.src.infra.security;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _options;
    private readonly SymmetricSecurityKey _chaveAssinatura;

    // --- RECEBE AS OPÇÕES VIA IOptions<T> ---
    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;

        if (string.IsNullOrWhiteSpace(_options.SecretKey) || _options.SecretKey.Length < 32)
        {
            throw new InvalidOperationException(
                "Jwt:SecretKey nao configurada ou muito curta (minimo 32 caracteres).");
        }

        _chaveAssinatura = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
    }

    // --- GERA UM TOKEN JWT PARA UM FUNCIONARIO ---
    public TokenGerado GerarTokenFuncionario(Usuario usuario)
    {
        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, usuario.Email),
            new(JwtRegisteredClaimNames.Name, usuario.Nome),
            new("matricula", usuario.Matricula),
            new(ClaimTypes.Role, usuario.Cargo),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        return GerarToken(claims);
    }

    // --- GERA UM TOKEN JWT PARA UM CLIENTE ANONIMO ---
    public TokenGerado GerarTokenCliente(long sessaoId, int numeroMesa)
    {
        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Sub, $"cliente-mesa-{numeroMesa}"),
            new("sessaoId", sessaoId.ToString()),
            new("numeroMesa", numeroMesa.ToString()),
            new(ClaimTypes.Role, RoleConstants.Cliente),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        return GerarToken(claims);
    }

    // --- METODO PRIVADO QUE FAZ O TRABALHO PESADO ---
    private TokenGerado GerarToken(IEnumerable<Claim> claims)
    {
        DateTime expiraEm = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes);

        SigningCredentials credenciais = new(_chaveAssinatura, SecurityAlgorithms.HmacSha256);

        // MONTA O TOKEN COM ISSUER, AUDIENCE, CLAIMS, EXPIRATION E ASSINATURA
        JwtSecurityToken token = new(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiraEm,
            signingCredentials: credenciais);

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenGerado(tokenString, expiraEm);
    }
}
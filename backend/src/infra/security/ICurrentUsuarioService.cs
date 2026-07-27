namespace HamburguerDoBenSystem.Backend.src.infra.security;

public interface ICurrentUsuarioService
{
    bool 	UsuarioEstaAutenticado 	{ get; }
    long?   UsuarioId 				{ get; }
    string? Email 					{ get; }
    string? Nome 					{ get; }
    string? Cargo 					{ get; }
    long? 	SessaoId 				{ get; }
    int? 	NumeroMesa 				{ get; }
}
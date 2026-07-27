using HamburguerDoBenSystem.Backend.src.modules.identidade.model;

namespace HamburguerDoBenSystem.Backend.src.infra.security;

public interface IJwtTokenService
{
    TokenGerado GerarTokenFuncionario(Usuario usuario);
    TokenGerado GerarTokenCliente(long sessaoId, int numeroMesa);
}
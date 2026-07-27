namespace HamburguerDoBenSystem.Backend.src.infra.security;

public static class RoleConstants
{
    public const string             Admin 				= "ADMIN";
    public const string             Garcom 				= "GARCOM";
    public const string             Cozinha 			= "COZINHA";
    public const string             Cliente             = "CLIENTE";
    public static readonly string[] RolesFuncionario    = { Admin, Garcom, Cozinha };
}

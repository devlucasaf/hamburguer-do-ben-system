using HamburguerDoBenSystem.Backend.src.entity;
using System.ComponentModel.DataAnnotations;

namespace HamburguerDoBenSystem.Backend.src.modules.identidade.model;

public class Usuario : AuditEntity
{
    [Required, MaxLength(120)]
    public string 		Nome 			{ get; set; } = string.Empty;

    [Required, MaxLength(160), EmailAddress]
    public string 		Email 			{ get; set; } = string.Empty;

    [MaxLength(14)]
    public string? 		Cpf 			{ get; set; }

    [MaxLength(20)]
    public string? 		Telefone 		{ get; set; }

    [Required, MaxLength(20)]
    public string 		Matricula 		{ get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string 		Cargo 			{ get; set; } = string.Empty;

    [Required, MaxLength(255)]
    public string 		SenhaHash 		{ get; set; } = string.Empty;

    public bool 		Ativo 			{ get; set; } = true;

    public DateTime? 	UltimoAcessoEm 	{ get; set; }
}
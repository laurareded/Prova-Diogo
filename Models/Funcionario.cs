﻿using Microsoft.Net.Http.Headers;
namespace Maiara.Models;

public class Funcionario
{
    public int FuncionarioId { get; set;}
    public string? Nome { get; set;}

    public string? Cpf { get; set;}

    public required ICollection<Folha> Folhas { get; set;}

}

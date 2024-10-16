using Microsoft.Net.Http.Headers;

namespace Maiara;

public class Funcionario
{
    public int FuncionarioId { get; set;}
    public string? Nome { get; set;}

    public double Cpf { get; set;}

    public required ICollection<Folha> Folhas { get; set;}

}

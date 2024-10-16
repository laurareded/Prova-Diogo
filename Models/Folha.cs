namespace Maiara;

public class Folha
{
    public int folhaId { get; set;}

    public double Valor { get; set;}

    public int Quantidade { get; set;}

    public int Mes { get; set;}

    public int Ano { get; set;}

    public double salarioBruto { get; set;}
    public double salarioLiquido { get; set;}
    public double impostoIrss { get; set;}

    public double impostoIrrf { get; set;}

    public double impostoInss { get; set;}

    public double impostoFgts { get; set;}

    public Funcionario? Funcionario { get; set; }

            public Folha(int quantidade, double valor, int mes, int ano, Funcionario funcionario)
        {
            Quantidade = quantidade;
            Valor = valor;
            Mes = mes;
            Ano = ano;
            Funcionario = funcionario;

            CalcularSalarioBruto();
            CalcularFgts();
            CalcularIrrf();
            CalcularInss();
            CalcularSalarioLiquido();
        }

        
        private void CalcularSalarioBruto()
        {
            
            salarioBruto = Valor * Quantidade;
        }

        
        private void CalcularFgts()
        {
            
            impostoFgts = salarioBruto * 0.08;
        }

        
        private void CalcularIrrf()
        {
            
            if (salarioBruto <= 1903.98)
            {
                impostoIrrf = 0; 
            }
            else if (salarioBruto <= 2826.65)
            {
                impostoIrrf = salarioBruto * 0.075 - 142.80;
            }
            else if (salarioBruto <= 3751.05)
            {
                impostoIrrf = salarioBruto * 0.15 - 354.80;
            }
            else
            {
                impostoIrrf = salarioBruto * 0.225 - 636.13;
            }
        }

        
        private void CalcularInss()
        {
            
            if (salarioBruto <= 1751.81)
            {
                impostoInss = salarioBruto * 0.08;
            }
            else if (salarioBruto <= 2919.72)
            {
                impostoInss = salarioBruto * 0.09;
            }
            else
            {
                impostoInss = salarioBruto * 0.11;
            }
        }

        
        private void CalcularSalarioLiquido()
        {
            
            salarioLiquido = salarioBruto - impostoIrrf - impostoInss;
        }
    }

    





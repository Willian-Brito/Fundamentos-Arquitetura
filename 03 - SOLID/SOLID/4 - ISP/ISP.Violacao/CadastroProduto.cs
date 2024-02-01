namespace SOLID.ISP.Violacao;

public class CadastroProduto : ICadastro
{
    public void ValidarDados()
    {
        // Validar valor
    }

    public void SalvarBanco()
    {
        // Insert tabela Produto
    }

    public void EnviarEmail()
    {
        // Produto n�o tem e-mail, o que eu fa�o agora???
        throw new NotImplementedException("Esse metodo n�o serve pra nada");
    }
}

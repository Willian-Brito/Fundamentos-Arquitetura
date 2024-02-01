using DesignPatterns.Structural.Facade.Domain;

namespace DesignPatterns.Behavioral.Strategy;

public class PagamentoBoletoService : IPagamento
{
    private readonly IPagamentoBoletoFacade _pagamentoBoletoFacade;

    public PagamentoBoletoService(IPagamentoBoletoFacade pagamentoBoletoFacade)
    {
        _pagamentoBoletoFacade = pagamentoBoletoFacade;
    }

    public Pagamento RealizarPagamento(Pedido pedido, Pagamento pagamento)
    {
        pagamento.Valor = pedido.Produtos.Sum(p => p.Valor);
        Console.WriteLine("Iniciando Pagamento via Boleto - Valor R$ " + pagamento.Valor);


        pagamento.LinhaDigitavelBoleto = _pagamentoBoletoFacade.GerarBoleto();
        pagamento.Status = "Aguardando Pagamento";
        return pagamento;
    }
}
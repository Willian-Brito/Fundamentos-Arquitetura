using SOLID.DIP.Solucao.Interfaces;

namespace SOLID.DIP.Solucao;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IEmailService _emailServices;

    public ClienteService(
        IEmailService emailServices, 
        IClienteRepository clienteRepository)
    {
        _emailServices = emailServices;
        _clienteRepository = clienteRepository;
    }

    public string AdicionarCliente(Cliente cliente)
    {
        if (!cliente.Validar())
            return "Dados inválidos";

        _clienteRepository.AdicionarCliente(cliente);

        _emailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

        return "Cliente cadastrado com sucesso";
    }
}

public class TesteDip
{
    public TesteDip()
    {
        var cliService = new ClienteService(new EmailService(), new ClienteRepository2());
    }
}

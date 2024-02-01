using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI;

public class VidaRealController : Controller
{
    private readonly IClienteServices _clienteServices;

    public VidaRealController(IClienteServices clienteServices)
    {
        _clienteServices = clienteServices;
    }

    public void Index()
    {
        _clienteServices.AdicionarCliente(new Cliente());
    }
}

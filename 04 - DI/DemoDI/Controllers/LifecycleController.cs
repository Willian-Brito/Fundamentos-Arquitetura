using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers;

public class LifecycleController : Controller
{
    public OperacaoService OperacaoService { get; }
    public OperacaoService OperacaoService2 { get; }

    public LifecycleController(OperacaoService operacaoService, OperacaoService operacaoService2)
    {
        OperacaoService = operacaoService;
        OperacaoService2 = operacaoService2;
    }

    public string Index()
    {
        return
            "Primeira instância: " + Environment.NewLine +
            OperacaoService.Transient.OperacaoId + " : Transient"  + Environment.NewLine +
            OperacaoService.Scoped.OperacaoId + " : Scoped" + Environment.NewLine +
            OperacaoService.Singleton.OperacaoId + " : Singleton" + Environment.NewLine +
            OperacaoService.SingletonInstance.OperacaoId + " : Singleton" + Environment.NewLine +

            Environment.NewLine +
            Environment.NewLine +

            "Segunda instância: " + Environment.NewLine +
            OperacaoService2.Transient.OperacaoId + " : Transient" + Environment.NewLine +
            OperacaoService2.Scoped.OperacaoId + " : Scoped"  + Environment.NewLine +
            OperacaoService2.Singleton.OperacaoId + " : Singleton" + Environment.NewLine +
            OperacaoService2.SingletonInstance.OperacaoId + " : Singleton" + Environment.NewLine;
    }
}

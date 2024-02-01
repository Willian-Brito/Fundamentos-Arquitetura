namespace DesignPatterns.Behavioral.Command;

internal abstract class Commander
{
    public abstract void Executar();
    public abstract void Desfazer();
}


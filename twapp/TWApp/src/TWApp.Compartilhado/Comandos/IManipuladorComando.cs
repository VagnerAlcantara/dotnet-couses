namespace TWApp.Compartilhado.Comandos
{
    public interface IManipuladorComando<T> where T : IComando
    {
        IResultadoComando Manipular(T comando);
    }
}

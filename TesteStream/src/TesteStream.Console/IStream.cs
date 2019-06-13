namespace TesteStream.Console
{
    public interface IStream
    {
        char GetNext();
        bool HasNext();
    }
}

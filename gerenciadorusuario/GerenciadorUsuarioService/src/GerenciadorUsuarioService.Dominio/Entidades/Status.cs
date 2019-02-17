namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class Status
    {
        public Status()
        {

        }
        public Status(int errorCode, string errorMessage, bool success)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Success = success;
        }

        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool Success { get; private set; }
    }
}

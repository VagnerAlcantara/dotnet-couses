
namespace GerenciadorUsuarioService.Dominio.Validacao
{
    public static class RG
    {
        static bool containNumber = false;
        public static bool IsValid(string RG)
        {
            if (string.IsNullOrEmpty(RG)
                        || (RG.Trim().Length < 4)
                        || (RG.Trim().Length > 15)
                        || (RG.StartsWith("0"))
               ) return false;

            for (int i = 0; i < RG.Length; i++)
            {
                if (char.IsNumber(RG[i]))
                    containNumber = true;

                if (!char.IsLetterOrDigit(RG[i]))
                {
                    return false;
                }
            }

            if (!containNumber)
                return false;

            return true;
        }
    }
}

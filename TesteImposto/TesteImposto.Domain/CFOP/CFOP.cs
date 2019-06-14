using System;

namespace TesteImposto.Domain.CFOP
{
    public abstract class CFOP
    {
        public abstract string GetValue(string destino);

        public static object GetInstance(string estadoOrigem)
        {
            try
            {
                Type type = Type.GetType(string.Concat(estadoOrigem, "Origem"));

                if (type != null)
                    return Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}

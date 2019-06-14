namespace TesteImposto.Domain.CFOP
{
    public class MGOrigem : CFOP
    {
        public override string GetValue(string destino)
        {
            switch (destino)
            {
                default:
                case "RJ":
                    return "6.000";
                case "PE":
                    return "6.001";
                case "MG":
                    return "6.002";
                case "PB":
                    return "6.003";
                case "PR":
                    return "6.004";
                case "PI":
                    return "6.005";
                case "RO":
                    return "6.006";
                case "SE":
                    return "6.007";
                case "TO":
                    return "6.008";
                case "PA":
                    return "6.010";
            }
        }
    }
}

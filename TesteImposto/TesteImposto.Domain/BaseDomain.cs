using System.Collections.Generic;
using System.Linq;

namespace TesteImposto.Domain
{
    public class BaseDomain
    {
        public BaseDomain()
        {
            Errors = new List<string>();
        }
        
        public bool IsValid { get { return !Errors.Any(); } }

        public IList<string> Errors { get; private set; }

        internal void AddError(string erro)
        {
            Errors.Add(erro);
        }

    }
}

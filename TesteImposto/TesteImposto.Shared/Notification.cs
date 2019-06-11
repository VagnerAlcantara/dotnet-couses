using System.Collections.Generic;
using System.Linq;

namespace TesteImposto.Shared
{
    public class Notification
    {
        public Notification()
        {
            Errors = new List<string>();
        }
        public bool IsValid { get { return !Errors.Any(); } }

        public List<string> Errors { get; private set; }

        public void AddError(string erro)
        {
            Errors.Add(erro);
        }

        public void AddError(IList<string> erros)
        {
            Errors.AddRange(erros);
        }
    }
}

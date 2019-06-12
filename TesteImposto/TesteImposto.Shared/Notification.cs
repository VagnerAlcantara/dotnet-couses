using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TesteImposto.Shared
{
    /// <summary>
    /// Classe responsável pelo armazenanto de informações de processo entre as camadas
    /// </summary>
    public class Notification
    {
        public Notification()
        {
            Errors = new List<string>();
        }
        [XmlIgnore]
        public bool IsValid { get { return !Errors.Any(); } }

        [XmlIgnore]
        public List<string> Errors { get; private set; }

        /// <summary>
        /// Adiciona um erro a lista de erros
        /// </summary>
        /// <param name="erro"></param>
        public void AddError(string erro)
        {
            Errors.Add(erro);
        }
        /// <summary>
        /// Adiciona uma lista de erros 
        /// </summary>
        /// <param name="erros"></param>
        public void AddError(IList<string> erros)
        {
            Errors.AddRange(erros);
        }
    }
}

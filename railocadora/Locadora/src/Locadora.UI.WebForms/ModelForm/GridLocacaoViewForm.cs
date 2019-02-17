using System;

namespace Locadora.UI.WebForms.ModelForm
{
    public class GridLocacaoViewForm
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
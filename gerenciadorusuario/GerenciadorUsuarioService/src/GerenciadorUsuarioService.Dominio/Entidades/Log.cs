using System;
using System.Collections.Generic;

namespace GerenciadorUsuarioService.Dominio.Entidades
{

    public class Log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Log()
        {
            cLogCampos = new List<LogCamposAlterados>();
        }
        public int Id { get; set; }
        public int IdResponsavelAlteracao { get; set; }
        public string NomeResponsavelAlteracao { get; set; }
        public DateTime DataAcao { get; set; }
        public String DtInicio { get; set; }
        public String DtFim { get; set; }
        public int? LogAcaoId { get; set; }
        public int? IdUsuarioAlterado { get; set; }
        public string NomeUsuarioAlterado { get; set; }
        public string RgUsuarioAlterado { get; set; }
        public string CpfUsuarioAlterado { get; set; }
        public virtual LogAcao cLogAcao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogCamposAlterados> cLogCampos { get; set; }

    }


}

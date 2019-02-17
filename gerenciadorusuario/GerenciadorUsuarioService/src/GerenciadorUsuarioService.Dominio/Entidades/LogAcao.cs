
using System.Collections.Generic;
namespace GerenciadorUsuarioService.Dominio.Entidades
{
    public class LogAcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LogAcao()
        {
            cLogs = new List<Log>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> cLogs { get; set; }


    }
}

using EF.Domain.Interface.Repository;
using EF.Infra.Data.Repositories;
using Ninject.Modules;

namespace EF.Infra.CrossCutting.IOC
{
    public class IocModulo : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlunoRepository, AlunoRepository>();
            Bind<ICursoRepository, CursoRepository>();
            Bind<IProfessorRepository, ProfessorRepository>();
            Bind<ITurmaRepository, TurmaRepository>();
        }
    }
}

using Ninject;

namespace EF.Infra.CrossCutting.IOC
{
    public class Container
    {
        public StandardKernel GetModule()
        {
            return new StandardKernel(new IocModulo());
        }
    }
}

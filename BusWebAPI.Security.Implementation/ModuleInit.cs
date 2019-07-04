using Aleph1.DI.Contracts;
using Aleph1.Security.Contracts;
using Aleph1.Security.Implementation._3DES;
using BusWebAPI.Security.Contracts;
using System.ComponentModel.Composition;

namespace BusWebAPI.Security.Implementation
{
    /// <summary>Used to register concrete implemtations to the DI container</summary>
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
		/// <summary>Used to register concrete implemtations to the DI container</summary>
		/// <param name="registrar">add implementation to the DI container using this registrar</param>
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterTypeAsSingelton<ICipher, TripleDES>();
            registrar.RegisterTypeAsSingelton<ISecurity, SecurityService>();
        }
    }
}

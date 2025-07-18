using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class AssemblyRegister
    {
        public static readonly Assembly assembly = typeof(Assembly).Assembly;

    }
}

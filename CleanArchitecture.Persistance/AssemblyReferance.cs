using System.Reflection;

namespace CleanArchitecture.Persistance
{
    public static class AssemblyReferance
    {
        public static readonly Assembly assembly = typeof(AssemblyReferance).Assembly;
    }
}

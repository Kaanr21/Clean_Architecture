namespace CleanArchitecture.Application.Interfaces.AutoMapper
{
    public interface ICustomMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);

        IList<TDestination> Map<TDestination, TSource>(List<TSource> source, string? ignore = null);


        TDestination Map<TDestination, TSource>(object source, string? ignore = null);

        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);
    }
}

using System.Reflection;

namespace Exchange.Domain.Database;

public static class DomainAssemblyReference
{
    public static readonly Assembly Assembly = typeof(DomainAssemblyReference).Assembly;
}

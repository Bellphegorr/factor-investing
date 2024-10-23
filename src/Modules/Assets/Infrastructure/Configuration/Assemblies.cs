using System.Reflection;

using FactorInvesting.Modules.Assets.Application.Contracts;

namespace FactorInvesting.Modules.Assets.Infrastructure.Configuration;

internal static class Assemblies
{
    public static Assembly Application => typeof(IAssetsModule).Assembly;
}
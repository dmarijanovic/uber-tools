using System;

namespace DamirM.Modules
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ModuleAttribute : Attribute
    {
    }
}

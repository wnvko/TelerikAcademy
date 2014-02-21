namespace Versions
{
    using System;
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class VersionAttribute:System.Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}

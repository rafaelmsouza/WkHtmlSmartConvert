using System;

namespace WkHtmlSmartConvert.Internal
{
    internal sealed class CommandLineAttribute : Attribute
    {
        public CommandLineAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

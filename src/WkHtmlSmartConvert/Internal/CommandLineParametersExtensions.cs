using System.Linq;
using System.Reflection;

namespace WkHtmlSmartConvert.Internal
{
    internal static class CommandLineParametersExtensions
    {
        public static string ToCommandLineParameters(this ICommandLineParameter obj)
        {
            var parameters = obj.GetType()
                .GetProperties()
                .Select(p => OptionsPropertyToCommandLineParameter(obj, p))
                .Where(p => !string.IsNullOrEmpty(p));
            return string.Join(" ", parameters);
        }

        private static string OptionsPropertyToCommandLineParameter(ICommandLineParameter obj, PropertyInfo property)
        {
            var propertyName = property.GetCustomAttribute<CommandLineAttribute>()?.Name;
            var (propertyValue, skipProperty) = OptionsPropertyValueToString(obj, property);
            return skipProperty ? string.Empty : $"{propertyName} {propertyValue ?? string.Empty}";
        }

        private static (string val, bool skip) OptionsPropertyValueToString(ICommandLineParameter source, PropertyInfo property)
        {
            switch (property.GetValue(source))
            {
                case int value:
                    return value == default ? (string.Empty, true) : (value.ToString(), false);
                case bool value:
                    return (string.Empty, !value);
                default:
                    break;
            }
            return (string.Empty, true);
        }
    }
}

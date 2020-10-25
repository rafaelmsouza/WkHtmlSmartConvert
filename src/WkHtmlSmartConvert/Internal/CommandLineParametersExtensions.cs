using System;
using System.Linq;
using System.Reflection;
using System.Text;

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
            return (property.GetValue(source)) switch
            {
                int value => value == default ? (string.Empty, true) : (value.ToString(), false),
                bool value => (string.Empty, !value),
                decimal value => value == default ? (string.Empty, true) : (value.ToString(), false),
                Enum value => (value.ToString().ToLower(), false),
                Encoding value => (value.BodyName, false),
                Margins value => (value.ToString(), false),
                _ => (string.Empty, true),
            };
        }
    }
}

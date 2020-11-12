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
                .Select(p => OptionsPropertyToCommandLineParameter(p, p.GetValue(obj)))
                .Where(p => !string.IsNullOrEmpty(p));
            return string.Join(" ", parameters).Trim();
        }

        private static string OptionsPropertyToCommandLineParameter(MemberInfo property, object memberInfoValue)
        {
            var commandLineName = property.GetCustomAttribute<CommandLineAttribute>()?.Name;
            var (propertyValue, skipProperty) = OptionsPropertyValueToString(memberInfoValue);
            return skipProperty ? string.Empty : $"{commandLineName} {propertyValue}".Trim();
        }

        private static (string val, bool skip) OptionsPropertyValueToString(object memberInfoValue)
        {
            switch (memberInfoValue)
            {
                case int value:
                    return (value.ToString(), false);
                case bool value:
                    return (string.Empty, !value);
                case Enum value:
                    return (value.ToString().ToLower(), false);
                case Encoding value:
                    return (value.BodyName, false);
                case Margins value:
                    return (value.ToString(), false);
                default:
                    return (string.Empty, true);
            }
        }
    }
}

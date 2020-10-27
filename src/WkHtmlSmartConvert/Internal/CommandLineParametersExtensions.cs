using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WkHtmlSmartConvert.Internal
{
    internal static class CommandLineParametersExtensions
    {
        public static string ToCommandLineParameters(this ICommandLineParameter obj)
        {
            var parameters = GetParameters(obj).Where(p => !string.IsNullOrEmpty(p));
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
            return memberInfoValue switch
            {
                int value => value == default ? (string.Empty, true) : (value.ToString(), false),
                bool value => (string.Empty, !value),
                Enum value => (value.ToString().ToLower(), false),
                Encoding value => (value.BodyName, false),
                Margins value => (value.ToString(), false),
                _ => (string.Empty, true),
            };
        }

        public static IEnumerable<string> GetParameters(object obj)
        {
            if (obj.GetType().IsValueType)
                return obj.GetType().GetFields().Select(p => OptionsPropertyToCommandLineParameter(p, p.GetValue(obj)));

            return obj.GetType().GetProperties().Select(p => OptionsPropertyToCommandLineParameter(p, p.GetValue(obj)));
        }
    }
}

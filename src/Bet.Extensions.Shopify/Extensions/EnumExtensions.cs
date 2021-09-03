using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Bet.Extensions.Shopify
{
    /// <summary>
    /// Enum Extension Method.
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Reads and uses the enum's <see cref="EnumMemberAttribute"/> for serialization.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string? ToSerializedString(this Enum input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var name = input.ToString();
            var info = input.GetType().GetTypeInfo().DeclaredMembers.Where(i => i.Name == name);

            if (info.Any())
            {
                var attribute = info.First().GetCustomAttribute<EnumMemberAttribute>();

                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            return name.ToLower();
       }
    }
}

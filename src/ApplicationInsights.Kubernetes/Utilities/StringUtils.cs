namespace Microsoft.ApplicationInsights.Kubernetes
{
    using System;
    using System.Globalization;
    internal static class StringUtils
    {
        public static string Invariant(FormattableString formattable)
        {
            return formattable.ToString(CultureInfo.InvariantCulture);
        }

        public static string GetReadableSize(this long numInBytes)
        {
            if (numInBytes < 0) throw new ArgumentOutOfRangeException(nameof(numInBytes));

            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            if (numInBytes == 0) return "0B";

            int order = (int)Math.Log(numInBytes, 1024);
            double doubleBytes = numInBytes / Math.Pow(1024, order);

            return String.Format(CultureInfo.InvariantCulture, "{0:0.#}{1}", doubleBytes, sizes[order]);
        }

        public static string EscapeForLoggingMessage(this string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return original;
            }
            return original.Replace("{", "{{", StringComparison.Ordinal).Replace("}", "}}", StringComparison.Ordinal);
        }
    }
}

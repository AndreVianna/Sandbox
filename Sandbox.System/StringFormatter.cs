using System.Text.RegularExpressions;

namespace System;

public static class StringFormatter {
    private static readonly Regex _pattern = new(@"\{+([^\{\}]+)\}+", RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static IEnumerable<string> ExtractParameters(string template) {
        var data = new List<string>();
        var matches = _pattern.Matches(template);
        if (matches.Count == 0) return data;

        foreach (var match in matches.Cast<Match>()) {
            if (data.Contains(match.Groups[1].Value)) continue;
            var key = match.Value.Replace("{{", "").Replace("}}", "");
            if (key.StartsWith("{") && key.EndsWith("}")) data.Add(match.Groups[1].Value);
        }
        return data;
    }

    private static string FormatImpl(string template, object?[] arguments) {
        var parameters = ExtractParameters(template).ToArray();
        if (parameters.Length == 0)
            return template;
        if (arguments.Length < parameters.Length)
            throw new ArgumentException("The number of arguments is less than the number of the template's required parameters.", nameof(arguments));
        var index = 0;
        var data = parameters.ToDictionary(k => k, _ => arguments[index++]);
        var text = data.Aggregate(template, (current, argument) => current.Replace($"{{{argument.Key}}}", Convert.ToString(argument.Value)));
        return text.Replace("{{", "{").Replace("}}", "}");
    }

    public static string Format(string template, params object?[] arguments) {
        if (arguments.Length == 1 && arguments[0] is object?[] array) return FormatImpl(template, array);
        return FormatImpl(template, arguments);
    }
}
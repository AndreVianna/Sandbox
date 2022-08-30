using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace System;

public record struct TemplatedString {
    public TemplatedString(string template, params object?[] arguments) {
        Template = template;
        (Formatted, Arguments) = ParseTemplate(template, arguments);
    }

    public string Template { get; }
    public IReadOnlyDictionary<string, object?> Arguments { get; }
    public string Formatted { get; }


    private static readonly Regex _pattern = new(@"\{+([^\{\}]+)\}+", RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static (string, IReadOnlyDictionary<string, object?>) ParseTemplate(string template, object?[] arguments) {
        var matches = _pattern.Matches(template);
        if (matches.Count == 0) return (template, new Dictionary<string, object?>());

        var index = 0;
        var data = new ConcurrentDictionary<string, object?>();
        var result = template;
        foreach (var match in matches.Cast<Match>()) {
            var token = match.Value;
            var key = token.Replace("{{", "").Replace("}}", "");
            var include = key.StartsWith("{") && key.EndsWith("}");
            var replacement = token;
            if (include) {
                var value = data.GetOrAdd(match.Groups[1].Value, _ => arguments[index++]);
                replacement = token.Replace(key, Convert.ToString(value));
            }

            result = result.Replace(token, replacement.Replace("{{", "{").Replace("}}", "}"));
        }

        return (result, data.ToDictionary(k => k.Key, v => v.Value));
    }
}

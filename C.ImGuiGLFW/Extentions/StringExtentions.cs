using System.Runtime.CompilerServices;
using System.Text;

namespace C.ImGuiGLFW.Extentions;

public static class StringExtentions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveOtherChars(this string s, string charsToKeep)
    => new([.. s.ToArray().Where(charsToKeep.Contains)]);

    public static string ReplaceFirst(this string text, string search, string replace)
    {
        var pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return string.Concat(text.AsSpan(0, pos), replace, text.AsSpan(pos + search.Length));
    }

    /// <summary>
    /// Removes whitespaces, line breaks, tabs, etc from string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string Cleanup(this string s)
    {
        StringBuilder sb = new(s.Length);
        foreach (var c in s)
        {
            if (c == ' ' || c == '\n' || c == '\r' || c == '\t') continue;
            sb.Append(c);
        }
        return sb.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> Split(this string str, int chunkSize) => Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Default(this string s, string defaultValue)
    {
        if (string.IsNullOrEmpty(s)) return defaultValue;
        return s;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Cut(this string s, int num)
    {
        if (s.Length <= num) return s;
        return s[0..num] + "...";
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Repeat(this string s, int num)
    {
        StringBuilder str = new();
        for (var i = 0; i < num; i++)
        {
            str.Append(s);
        }
        return str.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithAny(this string source, params string[] values)
        => source.StartsWithAny(values, StringComparison.Ordinal);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithAny(this string source, StringComparison stringComparison = StringComparison.Ordinal, params string[] values)
        => source.StartsWithAny(values, stringComparison);

    public static bool StartsWithAny(this string source, IEnumerable<string> compareTo, StringComparison stringComparison = StringComparison.Ordinal)
    {
        foreach (var x in compareTo)
        {
            if (source.StartsWith(x, stringComparison)) return true;
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this string obj, IEnumerable<string> values)
    {
        foreach (var x in values)
        {
            if (obj.Contains(x))
            {
                return true;
            }
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this string obj, params string[] values)
    {
        foreach (var x in values)
        {
            if (obj.Contains(x))
            {
                return true;
            }
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this string obj, StringComparison comp, params string[] values)
    {
        foreach (var x in values)
        {
            if (obj.Contains(x, comp))
            {
                return true;
            }
        }
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this string s, string other) => s.Equals(other, StringComparison.OrdinalIgnoreCase);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCaseAny(this string obj, params string[] values) => values.Any(x => x.Equals(obj, StringComparison.OrdinalIgnoreCase));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCaseAny(this string obj, IEnumerable<string> values) => values.Any(x => x.Equals(obj, StringComparison.OrdinalIgnoreCase));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? NullWhenEmpty(this string s) => s == string.Empty ? null : s;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
}
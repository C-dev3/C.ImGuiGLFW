using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace C.ImGuiGLFW.Extentions;

/// <summary>
/// Provides extension methods for <see cref="string"/> to facilitate common string operations.
/// </summary>
public static class StringExtentions
{
    /// <summary>
    /// Removes all characters from the string except those specified in <paramref name="charsToKeep"/>.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <param name="charsToKeep">The characters to keep in the resulting string.</param>
    /// <returns>A new string containing only characters from <paramref name="charsToKeep"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveOtherChars(this string s, string charsToKeep)
    => new([.. s.ToArray().Where(charsToKeep.Contains)]);

    /// <summary>
    /// Replaces the first occurrence of <paramref name="search"/> in the string with <paramref name="replace"/>.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="search">The substring to find.</param>
    /// <param name="replace">The substring to replace with.</param>
    /// <returns>A string with the first occurrence of <paramref name="search"/> replaced.</returns>
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
    /// Removes whitespace characters such as spaces, line breaks, tabs, etc. from the string.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>A new string with all whitespace characters removed.</returns>
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

    /// <summary>
    /// Splits the string into chunks of the specified size.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>An enumerable of string chunks.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> Split(this string str, int chunkSize) => Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));

    /// <summary>
    /// Returns the string itself or a default value if the string is null or empty.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <param name="defaultValue">The default value to return if <paramref name="s"/> is null or empty.</param>
    /// <returns><paramref name="s"/> if not null or empty; otherwise, <paramref name="defaultValue"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Default(this string s, string defaultValue)
    {
        if (string.IsNullOrEmpty(s)) return defaultValue;
        return s;
    }

    /// <summary>
    /// Truncates the string to the specified length and appends "..." if truncated.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <param name="num">The maximum length.</param>
    /// <returns>The truncated string with "..." appended if it was longer than <paramref name="num"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Cut(this string s, int num)
    {
        if (s.Length <= num) return s;
        return s[0..num] + "...";
    }

    /// <summary>
    /// Repeats the string <paramref name="num"/> times.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <param name="num">The number of times to repeat.</param>
    /// <returns>The concatenated string repeated <paramref name="num"/> times.</returns>
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

    /// <summary>
    /// Checks if the string starts with any of the specified <paramref name="values"/> using ordinal comparison.
    /// </summary>
    /// <param name="source">The input string.</param>
    /// <param name="values">Strings to check for the start of <paramref name="source"/>.</param>
    /// <returns>True if <paramref name="source"/> starts with any of the <paramref name="values"/>; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithAny(this string source, params string[] values)
        => source.StartsWithAny(values, StringComparison.Ordinal);

    /// <summary>
    /// Checks if the string starts with any of the specified <paramref name="values"/> using the specified <paramref name="stringComparison"/>.
    /// </summary>
    /// <param name="source">The input string.</param>
    /// <param name="stringComparison">The string comparison method.</param>
    /// <param name="values">Strings to check for the start of <paramref name="source"/>.</param>
    /// <returns>True if <paramref name="source"/> starts with any of the <paramref name="values"/>; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithAny(this string source, StringComparison stringComparison = StringComparison.Ordinal, params string[] values)
        => source.StartsWithAny(values, stringComparison);

    /// <summary>
    /// Checks if the string starts with any string in the enumerable <paramref name="compareTo"/> using the specified <paramref name="stringComparison"/>.
    /// </summary>
    /// <param name="source">The input string.</param>
    /// <param name="compareTo">Strings to check for the start of <paramref name="source"/>.</param>
    /// <param name="stringComparison">The string comparison method.</param>
    /// <returns>True if <paramref name="source"/> starts with any of the strings in <paramref name="compareTo"/>; otherwise false.</returns>
    public static bool StartsWithAny(this string source, IEnumerable<string> compareTo, StringComparison stringComparison = StringComparison.Ordinal)
    {
        foreach (var x in compareTo)
        {
            if (source.StartsWith(x, stringComparison)) return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if the string contains any of the specified <paramref name="values"/> using ordinal comparison.
    /// </summary>
    /// <param name="obj">The input string.</param>
    /// <param name="values">Strings to check for containment.</param>
    /// <returns>True if <paramref name="obj"/> contains any of the <paramref name="values"/>; otherwise false.</returns>
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

    /// <summary>
    /// Checks if the string contains any of the specified <paramref name="values"/> using ordinal comparison.
    /// </summary>
    /// <param name="obj">The input string.</param>
    /// <param name="values">Strings to check for containment.</param>
    /// <returns>True if <paramref name="obj"/> contains any of the <paramref name="values"/>; otherwise false.</returns>
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

    /// <summary>
    /// Checks if the string contains any of the specified <paramref name="values"/> using the specified <paramref name="comp"/> comparison.
    /// </summary>
    /// <param name="obj">The input string.</param>
    /// <param name="comp">The string comparison method.</param>
    /// <param name="values">Strings to check for containment.</param>
    /// <returns>True if <paramref name="obj"/> contains any of the <paramref name="values"/>; otherwise false.</returns>
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

    /// <summary>
    /// Compares the string to another string ignoring case.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <param name="other">The string to compare with.</param>
    /// <returns>True if the strings are equal ignoring case; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this string s, string other) => s.Equals(other, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the string equals any of the specified strings ignoring case.
    /// </summary>
    /// <param name="obj">The input string.</param>
    /// <param name="values">Strings to compare with.</param>
    /// <returns>True if the string equals any of the <paramref name="values"/> ignoring case; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCaseAny(this string obj, params string[] values) => values.Any(x => x.Equals(obj, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Checks if the string equals any string in the enumerable ignoring case.
    /// </summary>
    /// <param name="obj">The input string.</param>
    /// <param name="values">Strings to compare with.</param>
    /// <returns>True if the string equals any of the <paramref name="values"/> ignoring case; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCaseAny(this string obj, IEnumerable<string> values) => values.Any(x => x.Equals(obj, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns null if the string is empty; otherwise, returns the string itself.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>Null if <paramref name="s"/> is empty; otherwise, <paramref name="s"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? NullWhenEmpty(this string s) => s == string.Empty ? null : s;

    /// <summary>
    /// Returns whether the string is null or empty.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>True if the string is null or empty; otherwise false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
}
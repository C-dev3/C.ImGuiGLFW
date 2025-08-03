using System.Runtime.CompilerServices;

namespace C.ImGuiGLFW.Extentions;

/// <summary>
/// Provides useful extension methods for common operations.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Determines whether the current object is equal to any of the specified values.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="obj">The object to compare.</param>
    /// <param name="values">An array of values to compare against.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is equal to any of the <paramref name="values"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsAny<T>(this T obj, params T[] values) => values.Any(x => x?.Equals(obj) ?? false);

    /// <summary>
    /// Determines whether the current object is equal to any element in the specified enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="obj">The object to compare.</param>
    /// <param name="values">An enumerable of values to compare against.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is equal to any element in <paramref name="values"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsAny<T>(this T obj, IEnumerable<T> values) => values.Any(x => x?.Equals(obj) ?? false);

    /// <summary>
    /// Determines whether the current object is not equal to any of the specified values.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="obj">The object to compare.</param>
    /// <param name="values">An array of values to compare against.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is not equal to any of the <paramref name="values"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsNone<T>(this T obj, params T[] values) => !obj.EqualsAny(values);

    /// <summary>
    /// Determines whether the current object is not equal to any element in the specified enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="obj">The object to compare.</param>
    /// <param name="values">An enumerable of values to compare against.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is not equal to any element in <paramref name="values"/>; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsNone<T>(this T obj, IEnumerable<T> values) => !obj.EqualsAny(values);

    /// <summary>
    /// Determines whether the current object is within the specified range (inclusive).
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="obj">The object to check.</param>
    /// <param name="min">The minimum value of the range (inclusive).</param>
    /// <param name="max">The maximum value of the range (inclusive).</param>
    /// <returns><c>true</c> if <paramref name="obj"/> is between <paramref name="min"/> and <paramref name="max"/> (inclusive); otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween<T>(this T obj, T min, T max) where T : IComparable<T>
        => obj.CompareTo(min) >= 0 && obj.CompareTo(max) <= 0;

    /// <summary>
    /// Returns the current object if it is not null; otherwise, returns the specified default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to check for null.</param>
    /// <param name="defaultValue">The default value to return if <paramref name="obj"/> is null.</param>
    /// <returns>The <paramref name="obj"/> if it is not null; otherwise, <paramref name="defaultValue"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T IfNull<T>(this T obj, T defaultValue) => obj ?? defaultValue;

    /// <summary>
    /// Returns the current object if it is not null; otherwise, returns the result of the specified factory function.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to check for null.</param>
    /// <param name="factory">A function that provides the default value if <paramref name="obj"/> is null.</param>
    /// <returns>The <paramref name="obj"/> if it is not null; otherwise, the result of <paramref name="factory"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T IfNull<T>(this T obj, Func<T> factory) => obj ?? factory();

    /// <summary>
    /// Executes the specified action if the current object is not null.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to check for null.</param>
    /// <param name="action">The action to execute if <paramref name="obj"/> is not null.</param>
    /// <returns>The original <paramref name="obj"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T IfNotNull<T>(this T obj, Action<T> action)
    {
        if (obj != null) action(obj);
        return obj;
    }

    /// <summary>
    /// Transforms the current object using the specified function if it is not null; otherwise, returns the default value.
    /// </summary>
    /// <typeparam name="T">The type of the input object.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="obj">The object to transform.</param>
    /// <param name="func">The transformation function to apply if <paramref name="obj"/> is not null.</param>
    /// <param name="defaultValue">The default value to return if <paramref name="obj"/> is null.</param>
    /// <returns>The result of <paramref name="func"/> if <paramref name="obj"/> is not null; otherwise, <paramref name="defaultValue"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult IfNotNull<T, TResult>(this T? obj, Func<T, TResult> func, TResult defaultValue = default!)
        => obj != null ? func(obj) : defaultValue;

    /// <summary>
    /// Repeats the specified object the given number of times and returns them as an enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the object to repeat.</typeparam>
    /// <param name="obj">The object to repeat.</param>
    /// <param name="count">The number of times to repeat the object.</param>
    /// <returns>An enumerable containing <paramref name="obj"/> repeated <paramref name="count"/> times.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is negative.</exception>
    public static IEnumerable<T> Repeat<T>(this T obj, int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
        return Enumerable.Repeat(obj, count);
    }

    /// <summary>
    /// Wraps the current object in a single-element enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to wrap.</param>
    /// <returns>An enumerable containing only <paramref name="obj"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> AsEnumerable<T>(this T obj) => new[] { obj };

    /// <summary>
    /// Applies the specified function to the current object and returns the result.
    /// This method enables fluent chaining of operations.
    /// </summary>
    /// <typeparam name="T">The type of the input object.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="obj">The object to transform.</param>
    /// <param name="func">The function to apply to <paramref name="obj"/>.</param>
    /// <returns>The result of applying <paramref name="func"/> to <paramref name="obj"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="func"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult Pipe<T, TResult>(this T obj, Func<T, TResult> func)
    {
        if (func == null) throw new ArgumentNullException(nameof(func));
        return func(obj);
    }

    /// <summary>
    /// Executes the specified action on the current object and returns the object (useful for fluent chaining).
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to perform the action on.</param>
    /// <param name="action">The action to execute on <paramref name="obj"/>.</param>
    /// <returns>The original <paramref name="obj"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="action"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Tap<T>(this T obj, Action<T> action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        action(obj);
        return obj;
    }

    /// <summary>
    /// Determines whether the current object satisfies the specified predicate.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to test.</param>
    /// <param name="predicate">The predicate function to test against <paramref name="obj"/>.</param>
    /// <returns><c>true</c> if <paramref name="obj"/> satisfies the <paramref name="predicate"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Satisfies<T>(this T obj, Func<T, bool> predicate)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        return predicate(obj);
    }

    /// <summary>
    /// Returns the current object if it satisfies the specified predicate; otherwise, returns the default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to test.</param>
    /// <param name="predicate">The predicate function to test against <paramref name="obj"/>.</param>
    /// <param name="defaultValue">The default value to return if the predicate is not satisfied.</param>
    /// <returns>The <paramref name="obj"/> if it satisfies the <paramref name="predicate"/>; otherwise, <paramref name="defaultValue"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T IfSatisfies<T>(this T obj, Func<T, bool> predicate, T defaultValue = default!)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        return predicate(obj) ? obj : defaultValue;
    }

    /// <summary>
    /// Attempts to cast the current object to the specified type.
    /// </summary>
    /// <typeparam name="TResult">The type to cast to.</typeparam>
    /// <param name="obj">The object to cast.</param>
    /// <returns>The <paramref name="obj"/> cast to <typeparamref name="TResult"/> if the cast is successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult? As<TResult>(this object? obj) where TResult : class => obj as TResult;

    /// <summary>
    /// Attempts to cast the current object to the specified type and returns whether the cast was successful.
    /// </summary>
    /// <typeparam name="TResult">The type to cast to.</typeparam>
    /// <param name="obj">The object to cast.</param>
    /// <param name="result">When this method returns, contains the cast result if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if the cast was successful; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAs<TResult>(this object obj, out TResult? result) where TResult : class
    {
        result = obj as TResult;
        return result != null;
    }

    /// <summary>
    /// Swaps the values of two variables.
    /// </summary>
    /// <typeparam name="T">The type of the variables to swap.</typeparam>
    /// <param name="a">The first variable (passed by reference).</param>
    /// <param name="b">The second variable (passed by reference).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);
}
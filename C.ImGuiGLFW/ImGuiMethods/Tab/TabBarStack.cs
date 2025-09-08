namespace C.ImGuiGLFW.ImGuiMethods.Tab;

/// <summary>
/// Manages a collection of tab bars with support for multiple active tab bar instances.
/// </summary>
/// <remarks>
/// This class provides a stack-like structure for managing multiple tab bars within an application.
/// It handles tab bar creation, lookup, and maintains the currently active tab bar context.
/// This is particularly useful when dealing with nested or multiple tab bar scenarios.
/// </remarks>
public class TabBarStack
{
    /// <summary>
    /// Gets the collection of tab bars managed by this stack.
    /// </summary>
    /// <remarks>
    /// This list contains all tab bar instances that have been created and are being managed.
    /// Items should not be added or removed directly; use the appropriate methods instead.
    /// </remarks>
    public List<TabBar> TabBars { get; private set; }

    /// <summary>
    /// Gets or sets the total number of tab bars in the stack.
    /// </summary>
    /// <remarks>
    /// This count represents the number of tab bar instances currently being managed.
    /// It is automatically maintained as tab bars are added to the stack.
    /// </remarks>
    public uint TabBarCount { get; set; }

    /// <summary>
    /// Gets or sets the index of the currently active tab bar.
    /// </summary>
    /// <remarks>
    /// This index determines which tab bar is currently being operated on.
    /// It should always be less than TabBarCount to avoid exceptions.
    /// </remarks>
    public uint CurrentTabBar { get; set; }

    /// <summary>
    /// Initializes a new instance of the TabBarStack class with an empty collection.
    /// </summary>
    /// <remarks>
    /// Creates an empty tab bar stack ready for use. The stack begins with no tab bars
    /// and the current tab bar index set to 0. Tab bars can be added through the
    /// BeginTabBar method in the CTabBar class.
    /// </remarks>
    public TabBarStack()
    {
        TabBars = [];
        TabBarCount = 0;
        CurrentTabBar = 0;
    }

    /// <summary>
    /// Gets the currently active tab bar instance.
    /// </summary>
    /// <returns>The TabBar instance that is currently active.</returns>
    /// <exception cref="InvalidOperationException">Thrown when CurrentTabBar is greater than or equal to TabBarCount.</exception>
    /// <remarks>
    /// This method provides access to the tab bar that is currently being processed or rendered.
    /// The returned instance can be used to perform operations on the active tab bar.
    /// </remarks>
    public TabBar GetCurrentTabBar()
    {
        if (CurrentTabBar >= TabBarCount)
        {
            throw new InvalidOperationException("CurrentTabBar > TabBarCount");
        }
        return TabBars[(int)CurrentTabBar];
    }

    /// <summary>
    /// Resets the index counter for the currently active tab bar to zero.
    /// </summary>
    /// <remarks>
    /// This method is used internally to reset tab counting when beginning a new frame or cycle.
    /// It prepares the tab bar for a fresh round of tab additions and processing.
    /// </remarks>
    public void ClearIndexCountCurrentTabBar() => TabBars[(int)CurrentTabBar].IndexCounter = 0;

    /// <summary>
    /// Determines if a tab bar with the specified hash exists in the stack.
    /// </summary>
    /// <param name="hash">The hash identifier to search for.</param>
    /// <param name="index">When this method returns, contains the index of the found tab bar, or 0 if not found.</param>
    /// <returns>true if a tab bar with the specified hash exists; otherwise, false.</returns>
    /// <remarks>
    /// This method provides efficient lookup of tab bars using their hash identifiers.
    /// The hash-based lookup is faster than string-based searches for frequently accessed tab bars.
    /// </remarks>
    public bool DoesTabBarExist(uint hash, out uint index)
    {
        for (uint i = 0; i < TabBarCount; i++)
        {
            if (hash == TabBars[(int)i].Hash)
            {
                index = i;
                return true;
            }
        }
        index = 0;
        return false;
    }

    /// <summary>
    /// Determines if a tab bar with the specified identifier exists in the stack.
    /// </summary>
    /// <param name="id">The string identifier to search for.</param>
    /// <param name="index">When this method returns, contains the index of the found tab bar, or 0 if not found.</param>
    /// <returns>true if a tab bar with the specified identifier exists; otherwise, false.</returns>
    /// <remarks>
    /// This method converts the string identifier to a hash and then performs the lookup.
    /// It is convenient for string-based tab bar identification but slightly less efficient than hash-based lookup.
    /// </remarks>
    public bool DoesTabBarExist(string id, out uint index)
    {
        var hash = ImGuiP.ImHashStr(id);
        return DoesTabBarExist(hash, out index);
    }
}

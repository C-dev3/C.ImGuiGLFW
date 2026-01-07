namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// A helper class for managing and rendering various types of modal dialogs using ImGui.
/// </summary>
/// <remarks>
/// Supports simple informational modals, confirmation dialogs, text and numeric input modals,
/// as well as fully custom modals with user-defined content rendering.
/// Modals are queued and displayed one at a time in the order they are added.
/// Call <see cref="RenderModals"/> during the GUI render loop to process and show the modals.
/// </remarks>
public static class ModalHelper
{
    private static readonly Queue<ModalData> _modalQueue = new();
    private static ModalData? _currentModal = null;

    /// <summary>
    /// Displays a simple modal dialog with a title, message, and an OK button.
    /// </summary>
    /// <param name="title">The title of the modal window.</param>
    /// <param name="message">The message to display inside the modal.</param>
    /// <param name="onOk">An optional action to invoke when the OK button is pressed.</param>
    /// <remarks>
    /// This modal is used for informational purposes and only provides an OK button to dismiss it.
    /// </remarks>
    public static void ShowModal(string title, string message, Action? onOk = null) => _modalQueue.Enqueue(new ModalData
    {
        Title = title,
        Message = message,
        OnConfirm = onOk,
        Type = ModalType.Simple
    });

    /// <summary>
    /// Displays a confirmation modal dialog with OK and Cancel buttons.
    /// </summary>
    /// <param name="title">The title of the modal window.</param>
    /// <param name="message">The message to display inside the modal.</param>
    /// <param name="onConfirm">An optional action to invoke when the OK button is pressed.</param>
    /// <param name="onCancel">An optional action to invoke when the Cancel button is pressed.</param>
    /// <remarks>
    /// This modal is useful for confirming user decisions with explicit confirmation or cancellation.
    /// </remarks>
    public static void ShowConfirmation(string title, string message, Action? onConfirm = null, Action? onCancel = null) => _modalQueue.Enqueue(new ModalData
    {
        Title = title,
        Message = message,
        OnConfirm = onConfirm,
        OnCancel = onCancel,
        Type = ModalType.Confirmation
    });

    /// <summary>
    /// Displays an input modal dialog that allows the user to enter text.
    /// </summary>
    /// <param name="title">The title of the modal window.</param>
    /// <param name="message">The message to display inside the modal.</param>
    /// <param name="defaultValue">The initial text shown in the input field.</param>
    /// <param name="onInput">An optional action to invoke with the entered text when the user confirms.</param>
    /// <param name="maxLength">The maximum allowed length of the input string.</param>
    /// <remarks>
    /// This modal allows for text input and returns the entered value when confirmed.
    /// </remarks>
    public static void ShowInputModal(string title, string message, string defaultValue = "", Action<string>? onInput = null, int maxLength = 100) => _modalQueue.Enqueue(new ModalData
    {
        Title = title,
        Message = message,
        InputValue = defaultValue,
        OnInput = onInput,
        MaxLength = maxLength,
        Type = ModalType.Input
    });

    /// <summary>
    /// Displays an input modal dialog that allows the user to enter an integer number.
    /// </summary>
    /// <param name="title">The title of the modal window.</param>
    /// <param name="message">The message to display inside the modal.</param>
    /// <param name="defaultValue">The initial integer value shown in the input field.</param>
    /// <param name="onInputNum">An optional action to invoke with the entered integer when the user confirms.</param>
    /// <remarks>
    /// This modal is intended for numerical input and returns the entered number when confirmed.
    /// </remarks>
    public static void ShowInputNumberModal(string title, string message, int defaultValue = 0, Action<int>? onInputNum = null) => _modalQueue.Enqueue(new ModalData
    {
        Title = title,
        Message = message,
        InputNumber = defaultValue,
        OnInputNum = onInputNum,
        Type = ModalType.InputNum
    });

    /// <summary>
    /// Displays a custom modal dialog with user-defined content rendering.
    /// </summary>
    /// <param name="title">The title of the modal window.</param>
    /// <param name="renderContent">A delegate to render the modal's custom content. The boolean parameter indicates if the modal is open.</param>
    /// <param name="width">Optional width of the modal window. If zero or less, auto-resize is enabled.</param>
    /// <param name="height">Optional height of the modal window. If zero or less, auto-resize is enabled.</param>
    /// <remarks>
    /// This modal allows for fully custom content rendering using ImGui calls.
    /// </remarks>
    public static void ShowCustomModal(string title, Action<bool> renderContent, float width = 0, float height = 0) => _modalQueue.Enqueue(new ModalData
    {
        Title = title,
        RenderContent = renderContent,
        Width = width,
        Height = height,
        Type = ModalType.Custom
    });

    /// <summary>
    /// Renders the queued modals in sequence. Only one modal is displayed at a time.
    /// </summary>
    /// <remarks>
    /// This method should be called during the GUI rendering loop to display modals.
    /// </remarks>
    public static void RenderModals()
    {
        if (_currentModal == null && _modalQueue.Count > 0)
        {
            _currentModal = _modalQueue.Dequeue();
            var viewport = ImGui.GetMainViewport();
            var windowSize = viewport.Size;
            var windowPos = viewport.Pos;
            var center = new Vector2(
                windowPos.X + windowSize.X * 0.5f,
                windowPos.Y + windowSize.Y * 0.5f
            );

            ImGui.SetNextWindowPos(center, ImGuiCond.Appearing, new Vector2(0.5f, 0.5f));
            ImGui.OpenPopup(_currentModal.Title);
        }

        if (_currentModal != null)
        {
            ImGuiWindowFlags flags = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoMove;

            if (_currentModal.Width > 0 && _currentModal.Height > 0)
            {
                flags &= ~ImGuiWindowFlags.AlwaysAutoResize;
                ImGui.SetNextWindowSize(new Vector2(_currentModal.Width, _currentModal.Height));
            }

            if (ImGui.BeginPopupModal(_currentModal.Title, flags))
            {
                switch (_currentModal.Type)
                {
                    case ModalType.Simple:
                        RenderSimpleModal(_currentModal);
                        break;
                    case ModalType.Confirmation:
                        RenderConfirmationModal(_currentModal);
                        break;
                    case ModalType.Input:
                        RenderInputModal(_currentModal);
                        break;
                    case ModalType.InputNum:
                        RenderInputNumberModal(_currentModal);
                        break;
                    case ModalType.Custom:
                        _currentModal.RenderContent?.Invoke(true);
                        break;
                }

                ImGui.EndPopup();
            }
        }
    }


    private const float ButtonWidth = 120;
    private static void RenderSimpleModal(ModalData modal)
    {
        ImGui.Text(modal.Message);
        ImGui.Separator();

        float windowWidth = ImGui.GetWindowSize().X;
        float leftIndent = (windowWidth - ButtonWidth) * 0.5f;

        if (leftIndent > 0)
            ImGui.SetCursorPosX(leftIndent);

        if (ImGui.Button("OK", new Vector2(ButtonWidth, 0)))
        {
            modal.OnConfirm?.Invoke();
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
        ImGui.SetItemDefaultFocus();
    }

    private static void RenderConfirmationModal(ModalData modal)
    {
        ImGui.Text(modal.Message);
        ImGui.Separator();

        float windowWidth = ImGui.GetWindowWidth();
        float totalButtonWidth = ButtonWidth * 2 + ImGui.GetStyle().ItemSpacing.X;
        float cursorPosX = (windowWidth - totalButtonWidth) * 0.5f;

        if (cursorPosX > 0)
            ImGui.SetCursorPosX(cursorPosX);
        if (ImGui.Button("OK", new Vector2(ButtonWidth, 0)))
        {
            modal.OnConfirm?.Invoke();
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
        ImGui.SetItemDefaultFocus();
        ImGui.SameLine();
        if (ImGui.Button("Cancel", new Vector2(ButtonWidth, 0)))
        {
            modal.OnCancel?.Invoke();
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
    }

    private static void RenderInputModal(ModalData modal)
    {
        ImGui.Text(modal.Message);
        ImGui.Separator();

        var text = modal.InputValue;
        if (ImGui.InputText("##input", ref text, (uint)modal.MaxLength, ImGuiInputTextFlags.EnterReturnsTrue))
        {
            modal.InputValue = text;
        }
        ImGui.Separator();

        float windowWidth = ImGui.GetWindowWidth();
        float totalButtonWidth = ButtonWidth * 2 + ImGui.GetStyle().ItemSpacing.X;
        float cursorPosX = (windowWidth - totalButtonWidth) * 0.5f;

        if (cursorPosX > 0)
            ImGui.SetCursorPosX(cursorPosX);
        if (ImGui.Button("OK", new Vector2(ButtonWidth, 0)))
        {
            modal.OnInput?.Invoke(modal.InputValue);
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
        ImGui.SameLine();
        if (ImGui.Button("Cancel", new Vector2(ButtonWidth, 0)))
        {
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
    }

    private static void RenderInputNumberModal(ModalData modal)
    {
        ImGui.Text(modal.Message);
        ImGui.Separator();

        var num = modal.InputNumber;
        if (ImGui.InputInt("##input", ref num))
        {
            modal.InputNumber = num;
        }
        ImGui.Separator();

        float windowWidth = ImGui.GetWindowWidth();
        float totalButtonWidth = ButtonWidth * 2 + ImGui.GetStyle().ItemSpacing.X;
        float cursorPosX = (windowWidth - totalButtonWidth) * 0.5f;

        if (cursorPosX > 0)
            ImGui.SetCursorPosX(cursorPosX);
        if (ImGui.Button("OK", new Vector2(ButtonWidth, 0)))
        {
            modal.OnInputNum?.Invoke(modal.InputNumber);
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
        ImGui.SameLine();
        if (ImGui.Button("Cancel", new Vector2(ButtonWidth, 0)))
        {
            ImGui.CloseCurrentPopup();
            _currentModal = null;
        }
    }

    private class ModalData
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string InputValue { get; set; } = string.Empty;
        public int InputNumber { get; set; } = 0;
        public Action? OnConfirm { get; set; } = null;
        public Action? OnCancel { get; set; } = null;
        public Action<string>? OnInput { get; set; } = null;
        public Action<int>? OnInputNum { get; set; } = null;
        public Action<bool>? RenderContent { get; set; } = null;
        public int MaxLength { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public ModalType Type { get; set; }
    }

    private enum ModalType
    {
        Simple,
        Confirmation,
        Input,
        InputNum,
        Custom
    }
}

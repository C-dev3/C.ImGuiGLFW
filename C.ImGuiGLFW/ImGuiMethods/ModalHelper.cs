namespace C.ImGuiGLFW.ImGuiMethods;

public static class ModalHelper
{
    private static readonly Queue<ModalData> _modalQueue = new();
    private static ModalData? _currentModal = null;

    public static void ShowModal(string title, string message, Action? onOk = null)
    {
        _modalQueue.Enqueue(new ModalData
        {
            Title = title,
            Message = message,
            OnConfirm = onOk,
            Type = ModalType.Simple
        });
    }

    public static void ShowConfirmation(string title, string message, Action? onConfirm = null, Action? onCancel = null)
    {
        _modalQueue.Enqueue(new ModalData
        {
            Title = title,
            Message = message,
            OnConfirm = onConfirm,
            OnCancel = onCancel,
            Type = ModalType.Confirmation
        });
    }

    public static void ShowInputModal(string title, string message, string defaultValue = "", Action<string>? onInput = null, int maxLength = 100)
    {
        _modalQueue.Enqueue(new ModalData
        {
            Title = title,
            Message = message,
            InputValue = defaultValue,
            OnInput = onInput,
            MaxLength = maxLength,
            Type = ModalType.Input
        });
    }

    public static void ShowInputNumberModal(string title, string message, int defaultValue = 0, Action<int>? onInputNum = null)
    {
        _modalQueue.Enqueue(new ModalData
        {
            Title = title,
            Message = message,
            InputNumber = defaultValue,
            OnInputNum = onInputNum,
            Type = ModalType.InputNum
        });
    }

    public static void ShowCustomModal(string title, Action<bool> renderContent, float width = 0, float height = 0)
    {
        _modalQueue.Enqueue(new ModalData
        {
            Title = title,
            RenderContent = renderContent,
            Width = width,
            Height = height,
            Type = ModalType.Custom
        });
    }

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

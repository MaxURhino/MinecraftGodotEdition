using Godot;

namespace MinecraftGodotEdition.net.minecraft.client.gui.screens;

public partial class Screen : Control
{
    public virtual void _OnClose()
    {
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            _OnClose();
        }
    }
}
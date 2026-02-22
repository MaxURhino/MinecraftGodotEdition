namespace MinecraftGodotEdition.net.minecraft.client.gui.components;

public record WidgetSprites(string Enabled, string Disabled, string EnabledFocused, string DisabledFocused)
{
    public WidgetSprites(string sprite) : this(sprite, sprite, sprite, sprite) { }
    
    public WidgetSprites(string normal, string focused) : this(normal, normal, focused, focused) { }
    
    public WidgetSprites(string enabled, string disabled, string focused): this(enabled, disabled, focused, disabled) { }

    public string Get(bool enabled, bool focused)
    {
        if (enabled)
        {
            return focused ? this.EnabledFocused : this.Enabled;
        }
        else
        {
            return focused ? this.DisabledFocused : this.Disabled;
        }
    }
}
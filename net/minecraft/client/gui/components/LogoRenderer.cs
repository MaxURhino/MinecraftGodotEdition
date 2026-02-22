using Godot;

namespace MinecraftGodotEdition.net.minecraft.client.gui.components;

public partial class LogoRenderer : TextureRect
{
	private const string MinecraftLogo = "res://assets/minecraft/textures/gui/title/minecraft.png";
	private const string EasterEggLogo = "res://assets/minecraft/textures/gui/title/minceraft.png";
	private bool _showEasterEgg = GD.RandRange(1, 10000) == 1;
	
	public override void _Ready()
	{
		Texture = GD.Load<Texture2D>(_showEasterEgg ? EasterEggLogo : MinecraftLogo);
	}
}

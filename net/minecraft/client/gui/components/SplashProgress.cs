using Godot;
using System;

namespace MinecraftGodotEdition.net.minecraft.client.gui.components;

public partial class SplashProgress : Control
{
	[Export] public float Progress;

	public override void _Process(double delta)
	{
		var slider = GetNode<ColorRect>("Slider");
		slider.Size = new Vector2(Progress * 1.28f, slider.Size.Y);
	}
}

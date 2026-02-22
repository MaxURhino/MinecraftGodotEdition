using Godot;
using MinecraftGodotEdition.net.minecraft.client.gui.components;

namespace MinecraftGodotEdition.net.minecraft.client.gui.screens;

public partial class TitleScreen : Screen
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var splashRenderer = GetNode<SplashRenderer>("SplashRenderer");
		if (splashRenderer.HasCompletedAnimation)
		{
			GD.Print("Donenenenenenenne!!!");
		}
	}

	public override void _OnClose()
	{
		
	}
}

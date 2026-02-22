using Godot;
using MinecraftGodotEdition.net.minecraft.client.gui.components;

namespace MinecraftGodotEdition.net.minecraft.client.gui.screens;

public partial class TitleScreen : Screen
{
	private bool _hasCompletedAnimation;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Minecraft.HasSeenSplashScreen)
		{
			var splashRenderer = GetNode<SplashRenderer>("SplashRenderer");
			splashRenderer.QueueFree();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SplashRenderer splashRenderer = null;
		if (HasNode("SplashRenderer"))
		{
			splashRenderer = GetNode<SplashRenderer>("SplashRenderer");
		}
		if (splashRenderer != null)
		{
			if (splashRenderer.HasCompletedAnimation)
			{
				_hasCompletedAnimation = true;
				splashRenderer.QueueFree();
				Minecraft.HasSeenSplashScreen = true;
			}
		}
	}

	public override void _OnClose()
	{
		
	}
}

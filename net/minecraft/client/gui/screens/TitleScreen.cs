using Godot;
using System;
using MinecraftGodotEdition.net.minecraft.client.gui.components;
using MinecraftGodotEdition.net.minecraft.client.gui.components.text;

namespace MinecraftGodotEdition.net.minecraft.client.gui.screens;

public partial class TitleScreen : Screen
{
	private bool _hasCompletedStartupAnimation;
	private bool _hasCompletedEntireAnimation;

	private int _frame;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var menu = GetNode<Control>("Menu");
		var logoRenderer = GetNode<LogoRenderer>("LogoRenderer");
		if (Minecraft.HasSeenSplashScreen)
		{
			var splashRenderer = GetNode<SplashRenderer>("SplashRenderer");
			splashRenderer.QueueFree();
			_hasCompletedStartupAnimation = true;
			_hasCompletedEntireAnimation = true;
		}

		if (!_hasCompletedStartupAnimation)
		{
			menu.Modulate = new Color(1, 1, 1, 0);
			logoRenderer.Modulate = new Color(1, 1, 1, 0);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SplashRenderer splashRenderer = null;
		var menu = GetNode<Control>("Menu");
		var logoRenderer = GetNode<LogoRenderer>("LogoRenderer");
		if (HasNode("SplashRenderer"))
		{
			splashRenderer = GetNode<SplashRenderer>("SplashRenderer");
		}
		if (splashRenderer != null)
		{
			if (splashRenderer.HasCompletedAnimation)
			{
				_hasCompletedStartupAnimation = true;
				splashRenderer.QueueFree();
				Minecraft.HasSeenSplashScreen = true;
			}
		}

		if (_hasCompletedStartupAnimation && !_hasCompletedEntireAnimation)
		{
			if (menu.Modulate.A >= 1f)
			{
				_hasCompletedEntireAnimation = true;
			}
			else
			{
				if (logoRenderer.Modulate.A < 1)
				{
					logoRenderer.Modulate = new Color(1, 1, 1, logoRenderer.Modulate.A + 0.1f);
				}

				if (logoRenderer.Modulate.A >= 0.25f)
				{
					menu.Modulate = new Color(1, 1, 1, menu.Modulate.A + 0.01f);
				}
			}
		}

		if (_hasCompletedEntireAnimation)
		{
			_frame++;
			var splashText = logoRenderer.GetNode<TextComponent>("SplashText");
			splashText.Scale = Vector2FromOneInput(5 + Mathf.Sin(_frame / 15f) / 2f);
		}
	}

	private static Vector2 Vector2FromOneInput(float value)
	{
		return new Vector2(value, value);
	}

	public override void _OnClose()
	{
		
	}
}

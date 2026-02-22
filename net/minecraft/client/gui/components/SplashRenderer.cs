using Godot;
using System;

namespace MinecraftGodotEdition.net.minecraft.client.gui.components;

public partial class SplashRenderer : ColorRect
{
	public static SplashRenderer Instance = new SplashRenderer();
	
	private int _randomFrame;
	private int _frame;
	private bool _processEnded;

	public bool HasCompletedAnimation;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_randomFrame += new Random().Next() % 10;
		var splashProgress = GetNode<SplashProgress>("SplashProgress");
		var splash = GetNode<Control>("Splash");
		if (splashProgress.Progress < 100.0f)
		{
			if ((int)(_randomFrame / 2f) % 5 == 1)
			{
				splashProgress.Progress++;
			}
		}
		else
		{
			_processEnded = true;
			if (_processEnded)
			{
				if (splash.Modulate.A < 0.01f)
				{
					HasCompletedAnimation = true;
					MouseFilter = MouseFilterEnum.Ignore;
				}
				if (SelfModulate.A < 0.5f)
				{
					splash.Modulate = new Color(1, 1, 1, splash.Modulate.A - 0.01f);
				}
				if (splashProgress.Modulate.A < 0.01f)
				{
					SelfModulate = new Color(1, 1, 1, SelfModulate.A - 0.01f);
				}
				splashProgress.Modulate = new Color(1, 1, 1, splashProgress.Modulate.A - 0.01f);
			}
		}
	}
}

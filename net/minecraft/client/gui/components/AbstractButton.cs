using Godot;
using MinecraftGodotEdition.net.minecraft.client.gui.components.text;
using System;
using MinecraftGodotEdition.net.minecraft.sounds;

namespace MinecraftGodotEdition.net.minecraft.client.gui.components;

[GlobalClass]
public partial class AbstractButton : Button
{
	private readonly WidgetSprites _sprites = new WidgetSprites(
		"res://assets/minecraft/textures/gui/sprites/widget/button.png",
		"res://assets/minecraft/textures/gui/sprites/widget/button_disabled.png",
		"res://assets/minecraft/textures/gui/sprites/widget/button_highlighted.png"
	);

	[Export] public string LabelText = "";
	[Export] public string OnPress = "pass";
	[Export] public Texture2D IconTexture;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var texture = GetNode<NinePatchRect>("Texture");
		texture.Size = Size;
		
		var label = GetNode<TextComponent>("Label");
		label.Text = LabelText;

		var width = Size.X/2 - (label._GetWidth() / 2);

		label.Position = new Vector2();
		
		label._CreateLabel(width, Size.Y / 2 - 4);

		Pressed += () =>
		{
			SoundEvent.PlaySound("random/click");
			var expression = new Expression();
			var error = expression.Parse(OnPress);
			if (error != Error.Ok)
			{
				GD.PrintErr(expression.GetErrorText());
				return;
			}
			expression.Execute([], this);
		};

		if (IconTexture != null)
		{
			var icon = new Sprite2D();
			icon.Texture = IconTexture;
			icon.Position = new Vector2((Size.X / 2) + 0.5f, (Size.Y / 2) + 0.5f);
			AddChild(icon);
		}
	}

	public static void DoNothing()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var texture = GetNode<NinePatchRect>("Texture");
		texture.Texture = GD.Load<Texture2D>(_sprites.Get(!Disabled, IsHovered()));
	}
}

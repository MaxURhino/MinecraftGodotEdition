using Godot;
using System.Collections.Generic;

namespace MinecraftGodotEdition.net.minecraft.client.gui.components.text;

public partial class TextComponent : Control
{
	[Export] public string Text = "Hello";
	[Export] public bool DrawByDefault;
	[Export] public bool Underlined;
	[Export] public bool IsButton;
	private bool _isBeingUnderlined;

	private static readonly Dictionary<char, int> KerningAmounts = new() {
			{'i', 4},
			{'.', 4},
			{'!', 4},
			{'l', 3},
			{'t', 2},
			{' ', 2},
			{'f', 1}
	};

	private static int GetKerningAmount(char character)
	{
		return KerningAmounts.GetValueOrDefault(character, 0);
	}

	public override void _Ready()
	{
		_isBeingUnderlined = Underlined;
		if (DrawByDefault)
		{
			_CreateLabel(0, 0);
		}

		MouseEntered += () =>
		{
			if (!_isBeingUnderlined && IsButton)
			{
				var underline = GetNode<ColorRect>("Underline");
				var underlineShadow = GetNode<ColorRect>("UnderlineShadow");
				_isBeingUnderlined = true;
				underline.SetVisible(true);
				underlineShadow.SetVisible(true);
			}
		};

		MouseExited += () =>
		{
			if (_isBeingUnderlined && !Underlined && IsButton)
			{
				var underline = GetNode<ColorRect>("Underline");
				var underlineShadow = GetNode<ColorRect>("UnderlineShadow");
				_isBeingUnderlined = false;
				underline.SetVisible(false);
				underlineShadow.SetVisible(false);
			}
		};
	}

	public void _CreateLabel(float x, float y, bool shadow = true)
	{
		var underline = GetNode<ColorRect>("Underline");
		var underlineShadow = GetNode<ColorRect>("UnderlineShadow");
		int minus;
		Control characterShadows;
		Control characters;
		if (HasNode("Shadows"))
		{
			characterShadows = GetNode<Control>("Shadows");
		}
		else
		{
			characterShadows = new Control();
			characterShadows.Name = "Shadows";
			AddChild(characterShadows);
		}
		if (HasNode("Characters"))
		{
			characters = GetNode<Control>("Characters");
		}
		else
		{
			characters = new Control();
			characters.Name = "Characters";
			AddChild(characters);
		}
		
		if (shadow)
		{
			minus = 0;
			for (var i = 0; i < Text.Length; i++)
			{
				var textCharacter = Text[i];
				var shadowCharacter = new AnimatedSprite2D();
				shadowCharacter.SpriteFrames = GD.Load<SpriteFrames>("res://net/minecraft/client/gui/components/text/ASCIIText.tres");
				shadowCharacter.Frame = textCharacter;
				shadowCharacter.Position = new Vector2(5 + i * 6 - minus + x, y + 5);
				shadowCharacter.Modulate = new Color("#3f3f3f");
				minus += GetKerningAmount(textCharacter);
				characterShadows.AddChild(shadowCharacter);
			}
		}

		minus = 0;
		for (var i = 0; i < Text.Length; i++)
		{
			var textCharacter = Text[i];
			var character = new AnimatedSprite2D();
			character.SpriteFrames = GD.Load<SpriteFrames>("res://net/minecraft/client/gui/components/text/ASCIIText.tres");
			character.Frame = textCharacter;
			character.Position = new Vector2(4 + i * 6 - minus + x, y + 4);
			minus += GetKerningAmount(textCharacter);
			characters.AddChild(character);
			if (i == 0)
			{
				underline.Position = new Vector2(character.Position.X - 4, character.Position.Y + 4);
				underlineShadow.Position = new Vector2(character.Position.X - 3, character.Position.Y + 5);
			}
		}
		Size = new Vector2(_GetWidth(), Size.Y);
		underline.Size = new Vector2(Size.X, 1);
		underlineShadow.Size = new Vector2(Size.X, 1);
		underline.SetVisible(_isBeingUnderlined);
		underlineShadow.SetVisible(shadow && _isBeingUnderlined);
	}

	public float _GetWidth()
	{
		var returning = 0.0f;
		var minus = 0;
		var lastPosition = new Vector2();
		
		for (var i = 0; i < Text.Length; i++)
		{
			var textCharacter = Text[i];
			lastPosition = new Vector2(4 + i * 6 - minus, + 4);
			minus += GetKerningAmount(textCharacter);
			if (i == Text.Length - 1)
			{
				returning = lastPosition.X + 1;
				if (GetKerningAmount(textCharacter) > 0)
				{
					returning -= GetKerningAmount(textCharacter);
				}
			}
		}

		return returning;
	}
}

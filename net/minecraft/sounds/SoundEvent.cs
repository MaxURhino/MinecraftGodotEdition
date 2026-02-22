using Godot;
using System;

namespace MinecraftGodotEdition.net.minecraft.sounds;

public partial class SoundEvent : Node
{
	private static AudioStreamPlayer _audio;

	public override void _Ready()
	{
		_audio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}
	
	public static void PlaySound(string name)
	{
		_audio.Stream = GD.Load<AudioStream>("res://assets/minecraft/sounds/" + name + ".ogg");
		_audio.Play();
	}
}

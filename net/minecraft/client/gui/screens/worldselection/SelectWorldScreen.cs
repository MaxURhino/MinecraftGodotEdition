using Godot;
using System;
using MinecraftGodotEdition.net.minecraft.client.gui.screens;

namespace MinecraftGodotEdition.net.minecraft.client.gui.screens.worldselection;

public partial class SelectWorldScreen : Screen
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _OnClose()
	{
		Minecraft.ExecuteOn("get_tree().change_scene_to_file(\"res://net/minecraft/client/gui/screens/TitleScreen.tscn\")", this);
	}
}

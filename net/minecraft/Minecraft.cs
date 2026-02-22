using Godot;
using System;

namespace MinecraftGodotEdition.net.minecraft;

public partial class Minecraft : Node
{
    public static bool HasSeenSplashScreen = true;

    public static void ExecuteOn(string action, GodotObject instance)
    {
        var expression = new Expression();
        var error = expression.Parse(action);
        if (error != Error.Ok)
        {
            GD.PrintErr(expression.GetErrorText());
            return;
        }
        expression.Execute([], instance);
    }

    public void Execute(string action)
    {
        ExecuteOn(action, this);
    }

    public static Minecraft GetInstance()
    {
        return new Minecraft();
    }
}
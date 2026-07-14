using Godot;
using System;

public partial class StartButton : Button
{

    public enum ButtonBehavior
    {
        StartGame,
        ExitGame
    }

    [Export] public ButtonBehavior Behavior = ButtonBehavior.StartGame;
    [Export(PropertyHint.File, "*.tscn")] public string TargetScenePath;

    public override void _Ready()
	{
        Pressed += OnStartButtonPressed;
	}
   
    private void OnStartButtonPressed()
    {
        switch (Behavior)
        {
            case ButtonBehavior.StartGame:
                if (!string.IsNullOrEmpty(TargetScenePath))
                {
                    GetTree().ChangeSceneToFile(TargetScenePath);
                }
                else
                {
                    GD.PrintErr("TargetScenePath is empty on: ", Name);
                }
                break;

            case ButtonBehavior.ExitGame:
                GD.Print("Exiting game...");
                GetTree().Quit();
                break;
        }
    }


}

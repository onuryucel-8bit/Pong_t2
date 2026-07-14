using Godot;
using System;
using System.Threading.Tasks;
public partial class StartButton : Button
{

    AudioStreamPlayer sfx;

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

        sfx = GetNode<AudioStreamPlayer>("sfx");
    }
   
    private void OnStartButtonPressed()
    {
        switch (Behavior)
        {
            case ButtonBehavior.StartGame:
                
                sfx.Play();
                GetTree().ChangeSceneToFile(TargetScenePath);    
                
                break;

            case ButtonBehavior.ExitGame:
                GD.Print("Exiting game...");
                     
                GetTree().Quit();
                break;
        }        
    }
}

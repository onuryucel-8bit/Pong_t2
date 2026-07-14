using Godot;
using System;

public partial class GameState : Node2D
{
    [Export] public Label PauseLabel;
    [Export(PropertyHint.File, "*.tscn")] public string TargetScenePath;

    AudioStreamPlayer sfx;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        ProcessMode = Node.ProcessModeEnum.Always;

        sfx = GetNode<AudioStreamPlayer>("sfx");

        PauseLabel.Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{       
        if (Input.IsActionJustPressed("key_pause"))
        {                       
            GetTree().Paused = !GetTree().Paused;

            PauseLabel.Visible = GetTree().Paused;

            sfx.Play();

            GD.Print(GetTree().Paused ? "Game Paused" : "Game Resumed");
        }
        if(Input.IsActionJustPressed("key_m"))
        {
            sfx.Play();
            GetTree().ChangeSceneToFile(TargetScenePath);
        }
    }
}

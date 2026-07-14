using Godot;
using System;

public partial class Wall : Area2D
{
  
    [Export] public Label ScoreLabel;   
    [Export] public Ball GameBall;

    private int _score = 0;

    AudioStreamPlayer sfx;

    public override void _Ready()
    {       
        BodyEntered += OnBodyEntered;
        sfx = GetNode<AudioStreamPlayer>("sfx");
    }

    private void OnBodyEntered(Node2D body)
    {

        if (body.Name == "ball")
        {            
            _score++;
            
            ScoreLabel.Text = _score.ToString();
  
            GameBall.reset();
            
            sfx.Play();
        }
    }
}
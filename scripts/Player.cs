using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 500.0f;
    
    [Export] public StringName ActionUp = "p1_up";
    [Export] public StringName ActionDown = "p1_down";
   
    [Export] public Ball GameBall;

    public override void _Ready()
    {
       
    }

    
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;
        
        if (Input.IsActionPressed(ActionUp))
        {
            velocity.Y = -1;                       
        }
        if (Input.IsActionPressed(ActionDown))
        {
            velocity.Y = 1;
        }

        if (Input.IsKeyPressed(Key.R))
        {
            GameBall.reset();
        }
        
        Velocity = velocity * Speed;
        MoveAndSlide();
        
    }
}

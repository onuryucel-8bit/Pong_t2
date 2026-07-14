using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export] public float Speed = 400.0f;

    private Vector2 _direction = new Vector2(1, 1).Normalized(); 
    private Vector2 _initialPos;

    AudioStreamPlayer sfx;

    public override void _Ready()
    {
        _initialPos = Position;
        
        sfx = GetNode<AudioStreamPlayer>("sfx");
    
    }

    public override void _PhysicsProcess(double delta)
    {
        
        Velocity = _direction * Speed;
        
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
       
        if (collision != null)
        {
            GD.Print("Ball collided with: ", ((Node)collision.GetCollider()).Name);
           
            _direction = _direction.Bounce(collision.GetNormal());

            sfx.Play();
        }
    }

    public void reset()
    {
        Position = _initialPos;
    }
}

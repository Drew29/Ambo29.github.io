using Godot;
using System;

public class Player : KinematicBody2D
{
	float speed = 200;
	float gravity = 10;
	float jumpSpeed = -500;
	Vector2 direction = new Vector2();
	Sprite sprites;
		
		
	public override void _Ready()
	{
		sprites = GetNode<Sprite>("Idel");
	}
	
	public override void _PhysicsProcess(float delta)
	{	
		direction.y += gravity;
		
		if (IsOnFloor())
		{
			direction.y = 0;
		}
		
		direction.x = (Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"));
		
		if (direction.x == -1)
		{
			sprites.FlipH = true;
		} 
		else if (direction.x == 1)
		{
			sprites.FlipH = false;
		}
		
		direction.x *= speed;
		
		if (Input.IsActionJustPressed("move_up"))
		{
			direction.y = jumpSpeed;
		}
		
		direction = MoveAndSlide(direction, Vector2.Up);
	}
}

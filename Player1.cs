using Godot;
using System;
// You don't have to add any of these lines that are grayed out
// Also don't worry about the name of this file not matching yours
public class Player : KinematicBody2D
{
	float speed = 200;
	Vector2 direction = new Vector2();
	
	public override void _PhysicsProcess(float delta)
	{
		// The 2 if statements below are a pretty bad way to move left and right, I'll add a better way of doing it below that I could explain later
		
		if (Input.IsActionPressed("move_left")) // remember to add the inputs in settings for this (explanation below)
		{ // Project -> Project Settings -> Input Map -> add the text in IsActionPressed("") -> Add the key (or button) you want
			direction.x = -1;
		}
		if (Input.IsActionPressed("move_right"))
		{
			direction.x = 1;
		}
		
		
		// The better way - make sure to only include one of the ways (either comment or delete it)
		direction.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left")
		
		/* GetActionStrength returns 1
		If you hold down right, direction.x equals 1 since the first one is 1 and the second one is 0
		If you hold down left, direction.x equals -1 since the first one is 0 and the second one is -1
		If you hold down both or neither, direction.x equals 0 since 1 - 1 = 0 and 0 - 0 = 0
		
		This is better than before because if you hold down both (or neither) it doesn't move - in the first one it would still move left or right
		*/
		
		// How to comment your code (it would help you understand it later, but you don't have to make it as detailed as this because this is also teaching you) 
		/* <- Use this to (arrows are not neccessary)
		comment out multiple
		lines so that
		Godot ignores them
		Use this to end it -> */
		
		//This comments one line and Godot ignores only that line
		
		MoveAndSlide(direction * speed);
	}
}

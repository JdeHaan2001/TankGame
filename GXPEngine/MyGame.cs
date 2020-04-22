using System;
using GXPEngine;

public class MyGame : Game
{
	private Tank _tank;
	public MyGame() : base(1280, 720, false)
	{
		_tank = new Tank(width/2, height/2);
		AddChild(_tank);
	}

	void Update()
	{
	}

	static void Main()
	{
		new MyGame().Start();
	}
}
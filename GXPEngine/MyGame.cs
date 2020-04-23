using System;
using GXPEngine;

public class MyGame : Game
{
	private Tank _tank;
	private Turret _turret;
	public MyGame() : base(1280, 720, false)
	{
		_tank = new Tank(width/2, height/2);
		AddChild(_tank);
		_turret = new Turret(30, new Vec2(Utils.Random(20, game.width - 20), Utils.Random(20, game.height - 20)));
		AddChild(_turret);
	}
	public Turret getTurret()
	{
		return _turret;
	}
	public Tank getTank()
	{
		return _tank;
	}

	void Update()
	{
	}

	static void Main()
	{
		new MyGame().Start();
	}
}
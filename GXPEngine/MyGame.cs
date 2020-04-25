using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	public NLineSegment LineTop;
	public NLineSegment LineBottom;
	public NLineSegment LineRight;
	public NLineSegment LineLeft;
	public NLineSegment LineAngleLeft;
	public NLineSegment LineAngleRight;

	private Tank _tank;
	private List<Turret> _turretList;
	private EasyDraw _scoreHud;
	private EasyDraw _deathScreen;
	private UnitTests _tests;
	private const int _maxWait = 3000;
	private const int _maxTurretAmount = 5;
	private int _timer = _maxWait - 1;
	private int _turretAmount = 0;
	
	public MyGame() : base(1280, 720, false)
	{
		createLines();
		_turretList = new List<Turret>();
		_tank = new Tank(width/2, height/2);
		AddChild(_tank);
		_scoreHud = new EasyDraw(150, 50);
		_scoreHud.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(_scoreHud);
		_deathScreen = new EasyDraw(1280, 720);
		_deathScreen.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(_deathScreen);
		_tests = new UnitTests();
		AddChild(_tests);
	}
	public List<Turret> getTurretList()
	{
		return _turretList;
	}
	public Tank getTank()
	{
		return _tank;
	}
	private void createLines()
	{
		LineTop = new NLineSegment(new Vec2(300,0), new Vec2(width, 0), 0xff00ff00, 3);
		LineBottom = new NLineSegment(new Vec2(width - 300, height), new Vec2(0, game.height), 0xff00ff00, 3);
		LineRight = new NLineSegment(new Vec2(width, 0), new Vec2(width, height - 150), 0xff00ff00, 3);
		LineLeft = new NLineSegment(new Vec2(0, height), new Vec2(0, 150), 0xff00ff00, 3);
		LineAngleRight = new NLineSegment(new Vec2(width, height - 150), new Vec2(width - 300, height), 0xff00ff00, 3);
		LineAngleLeft = new NLineSegment(new Vec2(0, 150), new Vec2(300, 0), 0xff00ff00, 3);
		AddChild(LineTop);
		AddChild(LineBottom);
		AddChild(LineRight);
		AddChild(LineLeft);
		AddChild(LineAngleLeft);
		AddChild(LineAngleRight);
	}
	private void handleTurretList()
	{
		if (!_tank.GetIsDead())
		{
			_timer++;
			int waitAmount = _timer % _maxWait;
			if (waitAmount == 0)
			{
				if (_turretAmount < _maxTurretAmount)
				{
					_turretList.Add(new Turret(30, new Vec2(Utils.Random(20, game.width - 20), Utils.Random(20, game.height - 20))));
					_turretAmount++;
				}
			}
			foreach (Turret other in _turretList)
			{
				AddChild(other);
			}
		}
	}
	private void drawText()
	{
		_scoreHud.Clear(Color.Empty);
		_scoreHud.Text("Score: " + _tank.GetScore(), 0, 0);
		if (_tank.GetIsDead())
		{
			_deathScreen.Clear(Color.Empty);
			_deathScreen.Text("Game Over :(", 570, 200);
		}
	}
	void Update()
	{
		handleTurretList();
		drawText();
	}

	static void Main()
	{
		new MyGame().Start();
	}
}
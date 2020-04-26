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
	private EasyDraw _livesHud;
	private UnitTests _tests;

	private const int _maxWait = 3000; // Decrease this number for harder difficulty
	private const int _maxTurretAmount = 5; // Increas this number for harder difficulty

	private int _timer = _maxWait - 1;
	private int _turretAmount = 0;
	
	public MyGame() : base(1280, 720, false)
	{
		createLines();
		createTank();
		createText();
		createTests();
		_turretList = new List<Turret>();
	}
	/// <summary>
	/// This returns the list where all the turrets are stored in
	/// </summary>
	/// <returns></returns>
	public List<Turret> GetTurretList()
	{
		return _turretList;
	}
	/// <summary>
	/// This returns the tank. Use this to get acces to the public functions of the Tank class
	/// </summary>
	/// <returns></returns>
	public Tank GetTank()
	{
		return _tank;
	}
	/*-----------------------------------------
     *              createTests()
     * ----------------------------------------*/
	private void createTests()
	{
		_tests = new UnitTests();
		AddChild(_tests);
	}
	/*-----------------------------------------
     *              createText()
     * ----------------------------------------*/
	private void createText()
	{
		_scoreHud = new EasyDraw(150, 50);
		_scoreHud.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(_scoreHud);
		_deathScreen = new EasyDraw(1280, 720);
		_deathScreen.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(_deathScreen);
		_livesHud = new EasyDraw(150, 330);
		_livesHud.TextAlign(CenterMode.Min, CenterMode.Min);
		AddChild(_livesHud);
	}
	/*-----------------------------------------
     *              createTank()
     * ----------------------------------------*/
	private void createTank()
	{
		_tank = new Tank(width / 2, height / 2);
		AddChild(_tank);
	}
	/*-----------------------------------------
     *              createLines()
     * ----------------------------------------*/
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
	/*-----------------------------------------
     *              createTurrets()
     * ----------------------------------------*/
	private void createTurrets()
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
	/*-----------------------------------------
     *              drawText()
     * ----------------------------------------*/
	private void drawText()
	{
		_scoreHud.Clear(Color.Empty);
		_scoreHud.Text("Score: " + _tank.GetScore(), 0, 0);
		_livesHud.Clear(Color.Empty);
		_scoreHud.Text("Lives: " + _tank.GetLives(), 0, 20);

		if (_tank.GetIsDead())
		{
			_deathScreen.Clear(Color.Empty);
			_deathScreen.Text("Game Over :(", 570, 200);
		}
	}
	/*-----------------------------------------
     *              Update()
     * ----------------------------------------*/
	void Update()
	{
		createTurrets();
		drawText();
	}

	static void Main()
	{
		new MyGame().Start();
	}
}
using System;
using GXPEngine;

public class Turret : EasyDraw
{
    public int _radius;

    private const int _bulletSpeed = 5;
    private const int _maxShootWait = 120;
    private int _timer = _maxShootWait - 1;
    private int _lives = 3;

    private const float _barrelLength = 52f;
    
    private const float barrelRotSpeed = 2.0f;

    private Vec2 _position;

    private TurretBarrel _turret;
    private Tank _tank;

    
    public Turret(int pRadius, Vec2 pPosition) : base(pRadius * 2 +1, pRadius * 2 + 1)
    {
        MyGame myGame = (MyGame)game;
        SetOrigin(width / 2, height / 2);
        _radius = pRadius;
        _position = pPosition;
        _tank = myGame.GetTank();
        drawTurretBody(255, 255, 255);
        _turret = new TurretBarrel(x, y);
        AddChild(_turret);

    }
    public Vec2 position
    {
        get
        {
            return _position;
        }
    }
    /// <summary>
    /// This removes a live from the turret
    /// </summary>
    public void deductLive()
    {
        _lives--;
    }
    /*-----------------------------------------
     *              handleDeath()
     * ----------------------------------------*/
    private void handleDeath()
    {
        if (_lives == 0)
        {
            _position = new Vec2(Utils.Random(20, game.width - 20), Utils.Random(20, game.height - 20));
            _lives = 3;
            if (!_tank.GetIsDead())
            {
                _tank.AddScore(50);
            }
        }
    }
    /*-----------------------------------------
     *              updateScreenPos()
     * ----------------------------------------*/
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }
    /*-----------------------------------------
     *              drawTurretBody()
     * ----------------------------------------*/
    private void drawTurretBody(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }
    /*-----------------------------------------
     *              slowlyToMouse()
     * ----------------------------------------*/
    private void slowlyToMouse()
    {
        Vec2 mouseV = _tank.position;
        Vec2 midTank = new Vec2(x, y);
        float angleTowards = midTank.GetAngleDeg2Points(mouseV, midTank);
        angleTowards = rotation + _turret.rotation - angleTowards;
        angleTowards %= 360;
        if (Mathf.Abs(angleTowards) > 2)
        {
            bool over180degrees = angleTowards / 180 < 0;
            bool positive = Mathf.Abs(angleTowards) > 180;
            float addToRot = positive ? -barrelRotSpeed : barrelRotSpeed;
            _turret.rotation += over180degrees ? -addToRot : addToRot;
        }
    }
    /*-----------------------------------------
     *              shoot()
     * ----------------------------------------*/
    private void shoot()
    {
        bool isTankDead = _tank.GetIsDead();
        if (!isTankDead)
        {
            _timer++;
            int waitAmount = _timer % _maxShootWait;
            if (waitAmount == 0)
            {
                Vec2 barrelEnd = Vec2.GetUnitVecDeg(_turret.rotation + this.rotation) * _barrelLength;
                game.AddChild(new TurretBullet(barrelEnd + _position, Vec2.GetUnitVecDeg(_turret.rotation + rotation) * _bulletSpeed, this));
            }
        }
    }
    /*-----------------------------------------
     *              Update()
     * ----------------------------------------*/
    private void Update()
    {
        updateScreenPos();
        slowlyToMouse();
        shoot();
        handleDeath();
    }
}

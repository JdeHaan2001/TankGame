using System;
using GXPEngine;

public class Tank : Sprite
{
    private Barrel _barrel;

    private float _speed = 0.15f;

    private const float barrelRotSpeed = 2.0f;
    private const float barrelLength = 25f;

    private int _lives = 3;
    private int _score = 0;
    private int _timerCounter = 0;

    private const int _timerWait = 120; // Don't know why 120 works for this since it runs on 60fps, if 120 is too fast change to 60
    private const int _bulletSpeed = 5;

    private bool _isDead = false;

    private Vec2 _velocity;
    private Vec2 _acceleration;
    private Vec2 _position;
    public Tank(float px, float py) : base("assets/tankBody_red.png")
    {
        SetOrigin(width / 2, height / 2);
        _position.x = px;
        _position.y = py;
        _barrel = new Barrel(x, y);
        AddChild(_barrel);
    }
    /// <summary>
    /// This returns the position of the tank
    /// </summary>
    public Vec2 position
    {
        get
        {
            return _position;
        }
    }
    /// <summary>
    /// This returns bool _isDead
    /// </summary>
    /// <returns></returns>
    public bool GetIsDead()
    {
        return _isDead;
    }
    /// <summary>
    /// This removes 1 live of the tank
    /// </summary>
    public void RemoveLive()
    {
        _lives--;
    }
    /// <summary>
    /// This returns the current score
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return _score;
    }
    /// <summary>
    /// This adds a given amount to the current score
    /// </summary>
    /// <param name="addScore"></param>
    public void AddScore(int addScore)
    {
        _score += addScore;
    }
    /*-----------------------------------------
     *              handleScore()
     * ----------------------------------------*/
    private void handleScore()
    {
        if (!_isDead)
        {
            _timerCounter++;
            int timer = _timerCounter % _timerWait;
            if (timer == 0)
                _score++;
        }
    }
    /*-----------------------------------------
     *              controls()
     * ----------------------------------------*/
    private void controls()
    {
        if (Input.GetKey(Key.A))
        {
            rotation -= _velocity.Length * 0.5f;
        }
        else if (Input.GetKey(Key.D))
        {
            rotation += _velocity.Length * 0.5f;
        }

        if (Input.GetKey(Key.W))
        {
            _acceleration = Vec2.GetUnitVecDeg(rotation, _speed);
        }
        else if (Input.GetKey(Key.S))
        {
            _acceleration = Vec2.GetUnitVecDeg(rotation, -_speed);
        }
        else
        {
            _acceleration.x = 0;
            _acceleration.y = 0;
        }

        _acceleration += _velocity * -0.05f;
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
     *              slowlyToMouse()
     * ----------------------------------------*/
    private void slowlyToMouse()
    {
        Vec2 mouseV = new Vec2(Input.mouseX, Input.mouseY);
        Vec2 midTank = new Vec2(x, y);

        float angleTowards = midTank.GetAngleDeg2Points(mouseV, midTank);

        angleTowards = rotation + _barrel.rotation - angleTowards;
        angleTowards %= 360;

        if (Mathf.Abs(angleTowards) > 2)
        {
            bool over180degrees = angleTowards / 180 < 0;
            bool positive = Mathf.Abs(angleTowards) > 180;
            float addToRot = positive ? -barrelRotSpeed : barrelRotSpeed;
            _barrel.rotation += over180degrees ? -addToRot : addToRot;
        }
    }
    /*-----------------------------------------
     *              shoot()
     * ----------------------------------------*/
    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vec2 barrelEnd = Vec2.GetUnitVecDeg(_barrel.rotation + this.rotation) * barrelLength;
            game.AddChild(new Bullet(barrelEnd + _position, Vec2.GetUnitVecDeg(_barrel.rotation + rotation) * _bulletSpeed, this));
        }
    }
    /*-----------------------------------------
     *              handleDeath()
     * ----------------------------------------*/
    private void handleDeath()
    {
        if (_lives == 0)
        {
            _isDead = true;
        }
    }
    /*-----------------------------------------
     *              Update()
     * ----------------------------------------*/
    private void Update()
    {
        controls();
        updateScreenPos();
        _velocity += _acceleration;
        _position += _velocity;
        slowlyToMouse();
        shoot();
        handleDeath();
        handleScore();
    }
}

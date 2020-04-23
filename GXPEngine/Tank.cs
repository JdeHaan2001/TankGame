using System;
using GXPEngine;

public class Tank : Sprite
{
    
    public Vec2 position
    {
        get
        {
            return _position;
        }
    }
    private Barrel _barrel;

    private float _speed = 0.2f;
    private const float barrelRotSpeed = 2.0f;
    private const float barrelLength = 10f;

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
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }
    private void SlowlyToMouse()
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
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vec2 barrelEnd = Vec2.GetUnitVecDeg(_barrel.rotation + this.rotation) * barrelLength;
            game.AddChild(new Bullet(barrelEnd + _position, Vec2.GetUnitVecDeg(_barrel.rotation + rotation) * 5, this));
        }
    }
    private void Update()
    {
        controls();
        updateScreenPos();
        _velocity += _acceleration;
        _position += _velocity;
        SlowlyToMouse();
        Shoot();
    }
}

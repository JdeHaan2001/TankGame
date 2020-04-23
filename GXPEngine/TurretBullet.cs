using System;
using GXPEngine;

public class TurretBullet : Sprite
{
    private Vec2 _velocity;
    private Vec2 _position;

    private Turret _turret;
    private int _lives = 3;
    private const int _radius = 5;
    public TurretBullet(Vec2 pPosition, Vec2 pVelocity, Turret pTurret) : base("assets/bulletGreen.png")
    {
        SetOrigin(width / 2, height / 2);
        _position = pPosition;
        _velocity = pVelocity;
        _turret = pTurret;
    }
    private void handleBulletDestroy()
    {
        if (_lives == 0)
            LateDestroy();
    }
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }
    private void resolveCollision(Vec2 lineStart, Vec2 lineEnd, float dist)
    {
        Vec2 line = lineEnd - lineStart;
        Vec2 newPos = _position + ((-dist + _radius) * line.Normal());
        x = newPos.x;
        y = newPos.y;
    }
    private void handleVecReflect(Vec2 lineStart, Vec2 lineEnd)
    {
        Vec2 line = lineEnd - lineStart;
        _velocity.Reflect(line);
    }
    private void colCheck(Vec2 start, Vec2 end)
    {
        float ballDistance = Physics.CalculateBallDist(_position, start, end);

        if (ballDistance <= _radius)
        {
            resolveCollision(start, end, ballDistance);
            handleVecReflect(start, end);
            _lives--;
        }
    }
    private void handleBoundaryCol()
    {
        MyGame myGame = (MyGame)game;
        Vec2 lineTopStart = new Vec2(0, 0);
        Vec2 lineTopEnd = new Vec2(game.width, 0);
        Vec2 lineBottomStart = new Vec2(game.width, game.height);
        Vec2 lineBottomEnd = new Vec2(0, game.height);
        Vec2 lineRightStart = new Vec2(game.width, 0);
        Vec2 lineRightEnd = new Vec2(game.width, game.height);
        Vec2 lineLeftStart = new Vec2(0, game.height);
        Vec2 lineLeftEnd = new Vec2(0, 0);

        colCheck(lineTopStart, lineTopEnd);
        colCheck(lineBottomStart, lineBottomEnd);
        colCheck(lineRightStart, lineRightEnd);
        colCheck(lineLeftStart, lineLeftEnd);
    }
    private void Update()
    {
        _position += _velocity;
        updateScreenPos();
        handleBoundaryCol();
        handleBulletDestroy();
    }
}

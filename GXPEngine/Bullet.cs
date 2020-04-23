using System;
using GXPEngine;

public class Bullet : Sprite
{
    private Vec2 _velocity;
    private Vec2 _position;

    private Tank _tank;
    private Turret _turret;
    private int _lives = 3;
    private const int _radius = 5;
    public Bullet(Vec2 pPosition, Vec2 pVelocity, Tank pTank) : base("assets/bulletRed.png")
    {
        MyGame myGame = (MyGame)game;
        SetOrigin(width / 2, height / 2);
        _position = pPosition;
        _velocity = pVelocity;
        _tank = pTank;
        _turret = myGame.getTurret();
    }
    private void collisionCheckTurret()
    {
        Vec2 distance = _turret.position - this._position;
        if (distance.Length < _radius + _turret._radius)
        {
            LateDestroy();
            _turret.deductLive();
        }
    }
    private void handleDestroy()
    {
        if (_lives <= 0)
        {
            LateDestroy();
        }
    }
    private void resolveCollision(Vec2 lineStart, Vec2 lineEnd, float dist)
    {
        Vec2 line = lineEnd - lineStart;
        Vec2 newPos = _position + ((-dist + _radius) * line.Normal());
        x = newPos.x;
        y = newPos.y;
    }
    private void collisionCheckTank()
    {
        Vec2 distance = _tank.position - this._position;
        if (distance.Length < _radius + _tank.width/2)
        {
            LateDestroy();
            _tank.removeLive();
        }
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
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }
    private void Update()
    {
        _position += _velocity;
        updateScreenPos();
        handleDestroy();
        handleBoundaryCol();
        collisionCheckTank();
        collisionCheckTurret();
    }
}

﻿using System;
using GXPEngine;

public class TurretBullet : Sprite
{
    private Vec2 _velocity;
    private Vec2 _position;

    private Tank _tank;

    private int _lives = 3;

    private const int _radius = 5;
    public TurretBullet(Vec2 pPosition, Vec2 pVelocity, Turret pTurret) : base("assets/bulletGreen.png")
    {
        MyGame myGame = (MyGame)game;
        SetOrigin(width / 2, height / 2);
        _position = pPosition;
        _velocity = pVelocity;
        _tank = myGame.GetTank();

    }
    /*-----------------------------------------
     *              handleBulletDestroy()
     * ----------------------------------------*/
    private void handleBulletDestroy()
    {
        if (_lives == 0)
            LateDestroy();
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
     *              resolveCollision()
     * ----------------------------------------*/
    private void resolveCollision(Vec2 lineStart, Vec2 lineEnd, float dist)
    {
        Vec2 line = lineEnd - lineStart;
        Vec2 newPos = _position + ((-dist + _radius) * line.Normal());
        x = newPos.x;
        y = newPos.y;
    }
    /*-----------------------------------------
     *              handleReflect()
     * ----------------------------------------*/
    private void handleVecReflect(Vec2 lineStart, Vec2 lineEnd)
    {
        Vec2 line = lineEnd - lineStart;
        _velocity.Reflect(line);
    }
    /*-----------------------------------------
     *              colCheck()
     * ----------------------------------------*/
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
    /*-----------------------------------------
     *              handleBoundaryCol()
     * ----------------------------------------*/
    private void handleBoundaryCol()
    {
        // I wanted to use a list to store the lines, but I couldn't get that to work in time
        MyGame myGame = (MyGame)game;
        colCheck(myGame.LineAngleLeft.start, myGame.LineAngleLeft.end);
        colCheck(myGame.LineAngleRight.start, myGame.LineAngleRight.end);
        colCheck(myGame.LineBottom.start, myGame.LineBottom.end);
        colCheck(myGame.LineTop.start, myGame.LineTop.end);
        colCheck(myGame.LineRight.start, myGame.LineRight.end);
        colCheck(myGame.LineLeft.start, myGame.LineLeft.end);
    }
    /*-----------------------------------------
     *              handleTankCol()
     * ----------------------------------------*/
    private void handleTankCol()
    {
        Vec2 distance = _tank.position - this._position;
        if (distance.Length < _radius + _tank.width / 2 - 5)
        {
            this.LateDestroy();
            _tank.RemoveLive();
        }
    }
    /*-----------------------------------------
     *              Update()
     * ----------------------------------------*/
    private void Update()
    {
        _position += _velocity;
        updateScreenPos();
        handleBoundaryCol();
        handleBulletDestroy();
        handleTankCol();
    }
}

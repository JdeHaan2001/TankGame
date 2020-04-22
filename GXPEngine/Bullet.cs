using System;
using GXPEngine;

public class Bullet : Sprite
{
    private Vec2 _velocity;
    private Vec2 _position;
    private Vec2 _oldPosition;
    public Bullet(Vec2 pPosition, Vec2 pVelocity) : base("assets/bulletRed1.png")
    {
        SetOrigin(width / 2, height / 2);
        _position = pPosition;
        _velocity = pVelocity;
        _oldPosition = new Vec2(0, 0);
    }
    private void checkBoundaryColHorizontal()
    {
        MyGame myGame = (MyGame)game;
        if (_position.x - width < 0)
        {
            _position = Physics.PoIBorderHorizontal(_oldPosition, _velocity, _position, 0f, width);
            _velocity.x = -1 * _velocity.x;
        }
        else if (_position.x + width > game.width) 
        {
            _position = Physics.PoIBorderHorizontal(_oldPosition, _velocity, _position, game.width, width);
            _velocity.x = -1 * _velocity.x;
        }
    }
    private void checkBoundaryColVertical()
    {
        MyGame myGame = (MyGame)game;
        if (_position.y - height < 0)
        {
            _position = Physics.PoIBorderVertical(_oldPosition, _velocity, _position, 0f, height);
            _velocity.y = -1 * _velocity.y;
        }
        else if (_position.y + height > game.height)
        {
            _position = Physics.PoIBorderVertical(_oldPosition, _velocity, _position, game.height, height);
            _velocity.y = -1 * _velocity.y;
        }
    }
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }
    private void Update()
    {
        _oldPosition = _position;
        _position += _velocity;
        updateScreenPos();
        checkBoundaryColHorizontal();
        checkBoundaryColVertical();
    }
}

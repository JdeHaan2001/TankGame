using System;
using GXPEngine;

public class Barrel : Sprite
{
    private Vec2 _position;
    public Barrel(float px, float py) : base("assets/specialBarrel1.png")
    {
        _position.x = px;
        _position.y = py;
        SetOrigin(0, height/2);
    }
    private void updateScreenPos()
    {
        x = _position.x;
        y = _position.y;
    }

    private void Update()
    {
        updateScreenPos();
    }
}

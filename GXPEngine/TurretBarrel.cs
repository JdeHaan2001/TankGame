using System;
using GXPEngine;

public class TurretBarrel : Sprite
{
    private Vec2 _position;
    public TurretBarrel(float px, float py) : base("assets/tankDark_barrel2.png")
    {
        _position.x = px;
        _position.y = py;
        SetOrigin(8, height/2);
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
     *              Update()
     * ----------------------------------------*/
    private void Update()
    {
        updateScreenPos();
    }
}

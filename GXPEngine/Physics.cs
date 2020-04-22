using System;

namespace GXPEngine
{
    /// <summary>
    /// Physics class.
    /// Made by Jeroen de Haan 478343
    /// DO NOT USE WITHOUT APPROVAL FROM JEROEN DE HAAN
    /// </summary>
    public static class Physics
    {
        /// <summary>
        /// Calculates the point of impact (PoI) of an object when it collides with a border. This doesn't work between
        /// collisions between 2 different objects.
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="velocity"></param>
        /// <param name="currentPos"></param>
        /// <param name="boundary"></param>
        /// <param name="radius"></param>
        /// <returns>This returns the point of impact</returns>
        public static Vec2 PoIBorderHorizontal(Vec2 oldPos, Vec2 velocity, Vec2 currentPos, float boundary, float radius)
        {
            bool isGoingRight;
            if (currentPos.x < boundary)
                isGoingRight = true;
            else
                isGoingRight = false;
            float radiusOffSet = isGoingRight ? radius : -radius;
            float a = oldPos.x - (boundary - radiusOffSet);
            float b = oldPos.x - currentPos.x;
            float t = a / b;
            Vec2 PoI = oldPos + t * velocity;
            return PoI;
        }

        /// <summary>
        /// Calculates the point of impact (PoI) of an object when it collides with a border. This doesn't work between
        /// collisions between 2 different objects. 
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="velocity"></param>
        /// <param name="currentPos"></param>
        /// <param name="boundary"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static Vec2 PoIBorderVertical(Vec2 oldPos, Vec2 velocity, Vec2 currentPos, float boundary, float radius)
        {
            bool isGoingDown;
            if (currentPos.y < boundary)
                isGoingDown = true;
            else
                isGoingDown = false;
            float radiusOffSet = isGoingDown ? radius : -radius;
            float a = oldPos.y - (boundary - radiusOffSet);
            float b = oldPos.y - currentPos.y;
            float t = a / b;
            Vec2 PoI = oldPos + t * velocity;

            return PoI;
        }

        /// <summary>
        /// This returns the Time of Impact (TOI) for blocks colliding horizontally
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="velocity"></param>
        /// <param name="currentPos"></param>
        /// <param name="otherPos"></param>
        /// <param name="otherVelocity"></param>
        /// <param name="radius"></param>
        /// <param name="otherRadius"></param>
        /// <returns></returns>
        public static float TimeOfImpactHorizontal(Vec2 oldPos, Vec2 currentPos,
                                                   Vec2 otherPos, float radius, float otherRadius)
        {
            bool isGoingRight;
            if (currentPos.x < otherPos.x)
                isGoingRight = true;
            else
                isGoingRight = false;
            float radiusOffset = isGoingRight ? radius : -radius;
            float otherRadiusOffset = isGoingRight ? -otherRadius : otherRadius;
            float a = oldPos.x - (otherPos.x + otherRadiusOffset + radiusOffset);
            float b = oldPos.x - currentPos.x;
            float t = a / b;
            return t;
        }

        /// <summary>
        /// This return the Time of Impact (TOI) for blocks colliding vertically
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="velocity"></param>
        /// <param name="currentPos"></param>
        /// <param name="otherPos"></param>
        /// <param name="otherVelocity"></param>
        /// <param name="radius"></param>
        /// <param name="otherRadius"></param>
        /// <returns></returns>
        public static float TimeOfImpactVertical(Vec2 oldPos, Vec2 currentPos,
                                                 Vec2 otherPos, float radius, float otherRadius)
        {
            bool isGoingDown;
            if (currentPos.y < otherPos.y)
                isGoingDown = true;
            else
                isGoingDown = false;
            float radiusOffset = isGoingDown ? radius : -radius;
            float otherRadiusOffset = isGoingDown ? -otherRadius : otherRadius;
            float a = oldPos.y - (otherPos.y + otherRadiusOffset + radiusOffset);
            float b = oldPos.y - currentPos.y;
            float t = a / b;
            return t;
        }
        /// <summary>
        /// Calculates teh distance between a ball and a line
        /// </summary>
        /// <param name="ballPos"></param>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <returns></returns>
        public static float CalculateBallDist(Vec2 ballPos, Vec2 lineStart, Vec2 lineEnd)
        {
            Vec2 a = ballPos - lineStart;
            Vec2 b = lineEnd - lineStart;
            Vec2 bNorm = b.Normalized();
            float pLength = a.Dot(bNorm);
            Vec2 pVec = pLength * bNorm;
            Vec2 distVec = a - pVec;
            return distVec.Length;

        }
    }
}
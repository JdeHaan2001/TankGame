using System;
using GXPEngine;

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}
	/// <summary>
	/// Sets the x & y of the current vector
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void SetXY(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 left, float multiplier)
	{
		return new Vec2(left.x * multiplier, left.y * multiplier);
	}

	public static Vec2 operator *(float multiplier, Vec2 left)
	{
		return new Vec2(left.x * multiplier, left.y * multiplier);
	}

	public static Vec2 operator /(Vec2 v, float scalar)
	{
		return new Vec2(v.x / scalar, v.y / scalar);
	}

	/// <summary>
	/// Gets the length of the current vector
	/// </summary>
	public float Length
	{
		get { return (float)Math.Pow((x * x) + (y * y), 0.5); }
	}

	/// <summary>
	/// Returns a normalized version of the current vector without modifying it
	/// </summary>
	/// <returns></returns>
	public Vec2 Normalized()
	{
		float length = Length;
		if (length == 0)
		{
			return this;
		}
		return new Vec2(x / length, y / length);
	}

	/// <summary>
	/// Normalizes the current vector
	/// </summary>
	/// <returns></returns>
	public Vec2 Normalize()
	{
		if (Length == 0)
		{
			return this;
		}
		SetXY(x / Length, y / Length);
		return this;
	}

	/// <summary>
	/// Returns a string representation of the current vector
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}

	/// <summary>
	/// Converts given degrees to radians
	/// </summary>
	/// <param name="deg"></param>
	/// <returns></returns>
	public static float Deg2Rad(float deg)
	{
		return deg * (Mathf.PI / 180);
	}

	/// <summary>
	/// Converts given radians to degrees
	/// </summary>
	/// <param name="rad"></param>
	/// <returns></returns>
	public static float Rad2Deg(float rad)
	{
		float degrees;
		degrees = (float)(rad * 180 / Mathf.PI);
		return degrees;
	}

	/// <summary>
	/// Returns a new vector with given angle in radians
	/// </summary>
	/// <param name="rad"></param>
	/// <param name="length"></param>
	/// <returns></returns>
	public static Vec2 GetUnitVecRad(float rad, float length = 1)
	{
		float nx = Mathf.Cos(rad) * length;
		float ny = Mathf.Sin(rad) * length;
		return new Vec2(nx, ny);
	}

	/// <summary>
	/// Returns a new vector with given angle in degrees
	/// </summary>
	/// <param name="degrees"></param>
	/// <param name="length"></param>
	/// <returns></returns>
	public static Vec2 GetUnitVecDeg(float degrees, float length = 1)
	{
		float nx = Mathf.Cos(Deg2Rad(degrees)) * length;
		float ny = Mathf.Sin(Deg2Rad(degrees)) * length;
		return new Vec2(nx, ny);
	}

	/// <summary>
	/// returns a vector with a random angle
	/// </summary>
	/// <param name="length"></param>
	/// <returns></returns>
	public static Vec2 RandomUnitVector()
	{
		float nx = Mathf.Cos(Deg2Rad(Utils.Random(0, 360)));
		float ny = Mathf.Sin(Deg2Rad(Utils.Random(0, 360)));
		return new Vec2(nx, ny);
	}

	/// <summary>
	/// Sets the angle of the vector to a given angle in radians
	/// </summary>
	/// <param name="rad"></param>
	/// <returns></returns>
	public Vec2 SetAngleRad(float rad)
	{
		this = Vec2.GetUnitVecRad(rad) * Length;

		return this;
	}

	/// <summary>
	/// Sets the angle of the vector to a given angle in degrees
	/// </summary>
	/// <param name="deg"></param>
	/// <returns></returns>
	public Vec2 SetAngleDegrees(float deg)
	{
		return SetAngleRad(Deg2Rad(deg));
	}


	/// <summary>
	/// returns the angle of the vector in radians
	/// </summary>
	/// <returns></returns>
	public float getAngleRad()
	{
		return Mathf.Atan2(y, x);
	}

	/// <summary>
	/// returns the angle of the delta vector between 2 points
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public float GetAngleDeg2Points(Vec2 a, Vec2 b)
	{
		return Rad2Deg(Mathf.Atan2(b.y - a.y, b.x - a.x));
	}
	/// <summary>
	/// Returns the angle of the vector in degrees
	/// </summary>
	/// <returns></returns>
	public float getAngleDeg()
	{
		return Vec2.Rad2Deg(Mathf.Atan2(y, x));
	}

	/// <summary>
	/// Rotates the vector by adding given radians to the current angle of the vector
	/// </summary>
	/// <param name="addedRotationRad"></param>
	public void RotateRadians(float addedRotationRad)
	{
		float sinAngle = Mathf.Sin(addedRotationRad);
		float cosAngle = Mathf.Cos(addedRotationRad);
		this = new Vec2(x * cosAngle - y * sinAngle, x * sinAngle + y * cosAngle);
	}

	/// <summary>
	/// Rotates the vector by adding given degrees to the current angle of the vector
	/// </summary>
	/// <param name="addedRotationDeg"></param>
	public void RotateDegrees(float addedRotationDeg)
	{
		addedRotationDeg = Deg2Rad(addedRotationDeg);
		RotateRadians(addedRotationDeg);
	}

	/// <summary>
	/// Rotates an object around a target by adding the given angle in radians to the current angle of the delta vector between the objects
	/// </summary>
	/// <param name="targetPoint"></param>
	/// <param name="rad"></param>
	public void RotateAroundRad(Vec2 targetPoint, float rad)
	{
		this = this - targetPoint;
		RotateRadians(rad);
		this = this + targetPoint;
	}

	/// <summary>
	/// Rotates an object around a target by adding the given angle in degrees to the current angle of the delta vector between the objects
	/// </summary>
	/// <param name="targetPoint"></param>
	/// <param name="deg"></param>
	public void RotateAroundDeg(Vec2 targetPoint, float deg)
	{
		this = this - targetPoint;
		RotateDegrees(deg);
		this = this + targetPoint;
	}

	/// <summary>
	/// This calculates the dot product and returns the product in a float. This function does not normalize a vector.
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public float Dot(Vec2 other)
	{
		float dotProduct = this.x * other.x + this.y * other.y;
		return dotProduct;
	}
	/// <summary>
	/// Normalizes the vector and rotates it perpendicular to a line
	/// </summary>
	/// <returns></returns>
	public Vec2 Normal()
	{
		Normalize();
		return new Vec2(-this.y, this.x);
	}
	/// <summary>
	/// Reflects the vector when it bouncess on a line. The angle of the VECin will be the same as the angle of VECout
	/// </summary>
	/// <param name="pNormal"></param>
	/// <param name="bounciness"></param>
	public void Reflect(Vec2 pNormal, float bounciness = 1f)
	{
		Vec2 normalNormal = pNormal.Normal();
		Vec2 outVec = this - (1 + bounciness) * (this.Dot(normalNormal)) * normalNormal;
		this = outVec;
	}
}


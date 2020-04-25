using System;
using GXPEngine;

public class UnitTests : GameObject
{
	/// <summary>
	/// This is a class for all the unit tests
	/// </summary>
	public UnitTests()
	{
		testVecAddition();
		testVecSubtraction();
		testVecMultiplication();
		testVecDevide();
		testGetVecLength();
		testVecNormalize();
		testVecNormalized();
		testRadToDeg();
		testDegToRad();
		testGetUnitVecDeg();
		testGetUnitVecRad();
		testSetAngleDeg();
		testSetAngleRad();
		testGetAngleDeg();
		testGetAngleRad();
		testRotateDeg();
		testRotateRad();
		testRotateAroundDeg();
		testRotateAroundRad();
		testRandomUnitVec();
		testGetAngle2Points();
		testDot();
		testNormal();
		testReflect();
		testToString();
	}
	/// <summary>
	/// Unit Test for Vector addition
	/// </summary>
	private void testVecAddition() 
	{
		Vec2 myVecAddition = new Vec2(2, 3);
		Vec2 myVecAddition2 = new Vec2(-2, -3);
		Vec2 resultAddition = myVecAddition + myVecAddition2;
		Console.WriteLine("+ Operator works?: " + (resultAddition.x == 0 && resultAddition.y == 0));
	}
	/// <summary>
	/// Unit Test for Vector subtraction
	/// </summary>
	private void testVecSubtraction() 
	{
		Vec2 myVecSubtraction = new Vec2(2, 3);
		Vec2 myVec2Subtraction = new Vec2(-2, -3);
		Vec2 resultSubtraction = myVec2Subtraction - myVecSubtraction;
		Console.WriteLine("- Operator works?: " + (resultSubtraction.x == -4 && resultSubtraction.y == -6));
	}
	/// <summary>
	/// Unit Test for Vector multiplication
	/// </summary>
	private void testVecMultiplication() 
	{
		Vec2 myVecMultiply = new Vec2(2, 3);
		Vec2 resultMultiply = myVecMultiply * 3f;
		Console.WriteLine("* Operator works?: " + (resultMultiply.x == 6 && resultMultiply.y == 9));
	}
	/// <summary>
	/// Unit Test for deviding vectors
	/// </summary>
	private void testVecDevide()
	{
		Vec2 myVec = new Vec2(2, 2);
		Vec2 result = myVec / 2;
		Console.WriteLine("/ Operator works?: " + (result.x == 1 && result.y == 1));
	}
	/// <summary>
	/// Unit Test for Vector length
	/// </summary>
	private void testGetVecLength() 
	{
		Vec2 myVecLength = new Vec2(3, 4);
		Console.WriteLine("Length works?: " + (myVecLength.Length == 5));
	}
	/// <summary>
	/// Unit Test for vector Normalize
	/// </summary>
	private void testVecNormalize() 
	{
		Vec2 myVecNormalize = new Vec2(3, 4);
		myVecNormalize.Normalize();
		Console.WriteLine("Normalize works?: " + (myVecNormalize.x == 0.6f && myVecNormalize.y == 0.8f));
	}
	/// <summary>
	/// Unit Test for vector Normalized
	/// </summary>
	private void testVecNormalized()
	{
		Vec2 myVecNormalized = new Vec2(3, 4);
		Vec2 resultNormalized = myVecNormalized.Normalized();
		Console.WriteLine("Normalized works?: " + (resultNormalized.x == 0.6f && resultNormalized.y == 0.8f));
	}
	/// <summary>
	/// Unit Test for radians to degrees conversion
	/// </summary>
	private void testRadToDeg()
	{
		float rad = Mathf.PI;
		Console.WriteLine("RadToDeg works?: " + (Vec2.Rad2Deg(rad) == 180f));
	}
	/// <summary>
	/// unit test for degrees to radians conversion
	/// </summary>
	private void testDegToRad()
	{
		float deg = 180f;
		Console.WriteLine("DegToRad works?: " + (Vec2.Deg2Rad(deg) == Mathf.PI));
	}
	/// <summary>
	/// Test GetUnitVectorDegrees
	/// </summary>
	private void testGetUnitVecDeg() 
	{
		Vec2 TestGetUnitVecDeg = Vec2.GetUnitVecDeg(180f);
		Console.WriteLine("TestGetUnitVedDeg works?: " + (TestGetUnitVecDeg.x == -1 && TestGetUnitVecDeg.y <= 1 / 1000000));
	}
	/// <summary>
	/// Test GetUnitVectorRadius
	/// </summary>
	private void testGetUnitVecRad() 
	{
		Vec2 TestGetUnitVecRad = Vec2.GetUnitVecRad(Mathf.PI);
		Console.WriteLine("TestGetUnitVedRad works?: " + (TestGetUnitVecRad.x == -1 && TestGetUnitVecRad.y <= 1 / 1000000));
	}
	/// <summary>
	/// Unit Test RandomUnitVector
	/// </summary>
	private void testRandomUnitVec() 
	{
		Console.WriteLine("RandomVector 1: " + Vec2.RandomUnitVector());
		Console.WriteLine("RandomVector 2: " + Vec2.RandomUnitVector());
		Console.WriteLine("RandomVector 3: " + Vec2.RandomUnitVector());
	}
	/// <summary>
	/// Unit Test for Get an angle between 2 points
	/// </summary>
	private void testGetAngle2Points()
	{
		Vec2 myVec1 = new Vec2(3, 0);
		Vec2 myVec2 = new Vec2(0, -3);
		Console.WriteLine("GetAngle2Points works?: " + (myVec1.GetAngleDeg2Points(myVec2, myVec1) == 45f));
	}
	/// <summary>
	/// Unit Test SetAngleDegrees
	/// </summary>
	private void testSetAngleDeg() 
	{
		Vec2 testSetAngleDeg = new Vec2(1, 0);
		testSetAngleDeg.SetAngleDegrees(180);
		Console.WriteLine("Set angle with degrees works?: " + (testSetAngleDeg.x == -1 && testSetAngleDeg.y <= 1 / 1000000));
	}
	/// <summary>
	/// Unit Test SetAngleRadiands
	/// </summary>
	private void testSetAngleRad() 
	{
		Vec2 testSetAngleRad = new Vec2(1, 0);
		testSetAngleRad.SetAngleRad(Mathf.PI);
		Console.WriteLine("Set angle with degrees works?: " + (testSetAngleRad.x == -1 && testSetAngleRad.y <= 1 / 1000000));
	}
	/// <summary>
	/// Unit Test to get an angle in degrees
	/// </summary>
	private void testGetAngleDeg() 
	{
		Vec2 testGetAngleDeg = new Vec2(7.07f, 7.07f);
		Console.WriteLine("getAngleDeg works?: " + (testGetAngleDeg.getAngleDeg() == 45));
	}
	/// <summary>
	/// Unit Test to get an angle in radians
	/// </summary>
	private void testGetAngleRad() 
	{
		Vec2 testGetAngleRad = new Vec2(7.07f, 7.07f);
		Console.WriteLine("getAngleRad works?: " + (testGetAngleRad.getAngleRad() == 0.25 * Mathf.PI));
	}
	/// <summary>
	/// Unit Test to rotate a vector with amount in Radians
	/// </summary>
	private void testRotateRad() {
		Vec2 testRotateRad = new Vec2(1, 0);
		testRotateRad.RotateRadians((float)(0.5f * Mathf.PI));
		Console.WriteLine("TestRotateRad works?: " + (testRotateRad.x <= 1 / 10000 && testRotateRad.y == 1));
	}
	/// <summary>
	/// Unit Test to rotate a vector with amount in degrees
	/// </summary>
	private void testRotateDeg() 
	{
		Vec2 testRotateDeg = new Vec2(1, 0);
		testRotateDeg.RotateDegrees(90);
		Console.WriteLine("TestRotateDeg works?: " + (testRotateDeg.x <= 1 / 10000 && testRotateDeg.y == 1));
	}
	/// <summary>
	/// Unit Test to Rotate a vector around a point in degrees
	/// </summary>
	private void testRotateAroundDeg()
	{
		Vec2 testRotateAroundDeg = new Vec2(4, 6);
		Vec2 targetDeg = new Vec2(2, 1);
		testRotateAroundDeg.RotateAroundDeg(targetDeg, 90);
		Console.WriteLine("RotateAroundDeg works?: " + (testRotateAroundDeg.x == -3 && isApprox(testRotateAroundDeg.y, 3)));
	}
	/// <summary>
	/// Unit Test to Rotate a vector around a point in radians
	/// </summary>
	private void testRotateAroundRad() {
		// Test RotateAroundRad
		Vec2 testRotateAroundRad = new Vec2(4, 6);
		Vec2 targetRad = new Vec2(2, 1);
		testRotateAroundRad.RotateAroundRad(targetRad, (float)(0.5f * Mathf.PI));
		Console.WriteLine("RotateAroundRad works?: " + (isApprox(testRotateAroundRad.x, -3) && isApprox(testRotateAroundRad.y, 3)));
	}
	/// <summary>
	/// Unit Test to get the dot product
	/// </summary>
	private void testDot()
	{
		Vec2 myVec1 = new Vec2(2, 2);
		Vec2 myVec2 = new Vec2(3, 3);
		float dotProduct = myVec1.Dot(myVec2);
		Console.WriteLine("Dot works?: " + (dotProduct == 12));
	}
	/// <summary>
	/// Unit Test to get a Normal vector
	/// </summary>
	private void testNormal()
	{
		Vec2 myVec = new Vec2(0, 1);
		myVec.Normal();
		Console.WriteLine("Normal works?: " + (myVec.x == 0 && myVec.y == 1));
	}
	/// <summary>
	/// Unit Test to reflect a vector
	/// </summary>
	private void testReflect()
	{
		Vec2 myVecNormalize = new Vec2(0, 1);
		Vec2 myVelocity = new Vec2(1, 1);
		myVelocity.Reflect(myVecNormalize);
		Console.WriteLine("Reflect works?: " + (myVelocity.x == -1 && myVelocity.y == 1));
	}
	/// <summary>
	/// Unit Test to convert a vector to a string
	/// </summary>
	private void testToString()
	{
		Vec2 myVec = new Vec2(1, 1);
		String myString = myVec.ToString();
		Console.WriteLine("ToString works?: " + (myString == "(1,1)"));
	}
	/// <summary>
	/// This is a function to check if 2 values are really close to each other (check to see if the values are basically the same). 
	/// </summary>
	/// <param name="myValue"></param>
	/// <param name="expectedValue"></param>
	/// <returns></returns>
	private bool isApprox(float myValue, float expectedValue)
	{
		return Mathf.Abs(myValue - expectedValue) < 1 / 100000f;
	}
}

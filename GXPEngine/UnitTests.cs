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
	private void testVecAddition() {
		// Unit Test for Vector addition
		Vec2 myVecAddition = new Vec2(2, 3);
		Vec2 myVecAddition2 = new Vec2(-2, -3);
		Vec2 resultAddition = myVecAddition + myVecAddition2;
		Console.WriteLine("+ Operator works?: " + (resultAddition.x == 0 && resultAddition.y == 0));
	}
	private void testVecSubtraction() {
		// Unit Test for Vector subtraction
		Vec2 myVecSubtraction = new Vec2(2, 3);
		Vec2 myVec2Subtraction = new Vec2(-2, -3);
		Vec2 resultSubtraction = myVec2Subtraction - myVecSubtraction;
		Console.WriteLine("- Operator works?: " + (resultSubtraction.x == -4 && resultSubtraction.y == -6));
	}
	private void testVecMultiplication() {
		// Unit Test for Vector multiplication
		Vec2 myVecMultiply = new Vec2(2, 3);
		Vec2 resultMultiply = myVecMultiply * 3f;
		Console.WriteLine("* Operator works?: " + (resultMultiply.x == 6 && resultMultiply.y == 9));
	}
	private void testVecDevide()
	{
		Vec2 myVec = new Vec2(2, 2);
		Vec2 result = myVec / 2;
		Console.WriteLine("/ Operator works?: " + (result.x == 1 && result.y == 1));
	}
	private void testGetVecLength() {
		// Unit Test for Vector length
		Vec2 myVecLength = new Vec2(3, 4);
		Console.WriteLine("Length works?: " + (myVecLength.Length == 5));
	}
	private void testVecNormalize() {
		// Unit Test for vector Normalize
		Vec2 myVecNormalize = new Vec2(3, 4);
		myVecNormalize.Normalize();
		Console.WriteLine("Normalize works?: " + (myVecNormalize.x == 0.6f && myVecNormalize.y == 0.8f));
	}
	private void testVecNormalized()
	{
		// Unit Test for vector Normalized
		Vec2 myVecNormalized = new Vec2(3, 4);
		Vec2 resultNormalized = myVecNormalized.Normalized();
		Console.WriteLine("Normalized works?: " + (resultNormalized.x == 0.6f && resultNormalized.y == 0.8f));
	}

	private void testRadToDeg()
	{
		float rad = Mathf.PI;
		Console.WriteLine("RadToDeg works?: " + (Vec2.Rad2Deg(rad) == 180f));
	}
	private void testDegToRad()
	{
		float deg = 180f;
		Console.WriteLine("DegToRad works?: " + (Vec2.Deg2Rad(deg) == Mathf.PI));
	}
	private void testGetUnitVecDeg() {
		// Test GetUnitVectorDegrees
		Vec2 TestGetUnitVecDeg = Vec2.GetUnitVecDeg(180f);
		Console.WriteLine("TestGetUnitVedDeg works?: " + (TestGetUnitVecDeg.x == -1 && TestGetUnitVecDeg.y <= 1 / 1000000));
	}
	private void testGetUnitVecRad() {
		// Test GetUnitVectorRadius
		Vec2 TestGetUnitVecRad = Vec2.GetUnitVecRad(Mathf.PI);
		Console.WriteLine("TestGetUnitVedRad works?: " + (TestGetUnitVecRad.x == -1 && TestGetUnitVecRad.y <= 1 / 1000000));
	}
	private void testRandomUnitVec() {
		// Test RandomUnitVector
		Console.WriteLine("RandomVector 1: " + Vec2.RandomUnitVector());
		Console.WriteLine("RandomVector 2: " + Vec2.RandomUnitVector());
		Console.WriteLine("RandomVector 3: " + Vec2.RandomUnitVector());
	}
	private void testGetAngle2Points()
	{
		Vec2 myVec1 = new Vec2(3, 0);
		Vec2 myVec2 = new Vec2(0, -3);
		Console.WriteLine("GetAngle2Points works?: " + (myVec1.GetAngleDeg2Points(myVec2, myVec1) == 45f));
	}
	private void testSetAngleDeg() {
		//Test SetAngleDegrees
		Vec2 testSetAngleDeg = new Vec2(1, 0);
		testSetAngleDeg.SetAngleDegrees(180);
		Console.WriteLine("Set angle with degrees works?: " + (testSetAngleDeg.x == -1 && testSetAngleDeg.y <= 1 / 1000000));
	}
	private void testSetAngleRad() {
		//Test SetAngleRadiands
		Vec2 testSetAngleRad = new Vec2(1, 0);
		testSetAngleRad.SetAngleRad(Mathf.PI);
		Console.WriteLine("Set angle with degrees works?: " + (testSetAngleRad.x == -1 && testSetAngleRad.y <= 1 / 1000000));
	}
	private void testGetAngleDeg() {
		//Test getAngleDeg
		Vec2 testGetAngleDeg = new Vec2(7.07f, 7.07f);
		Console.WriteLine("getAngleDeg works?: " + (testGetAngleDeg.getAngleDeg() == 45));
	}
	private void testGetAngleRad() {
		// Test getAngleRad
		Vec2 testGetAngleRad = new Vec2(7.07f, 7.07f);
		Console.WriteLine("getAngleRad works?: " + (testGetAngleRad.getAngleRad() == 0.25 * Mathf.PI));
	}
	private void testRotateRad() {
		// Test RotateRadians
		Vec2 testRotateRad = new Vec2(1, 0);
		testRotateRad.RotateRadians((float)(0.5f * Mathf.PI));
		Console.WriteLine("TestRotateRad works?: " + (testRotateRad.x <= 1 / 10000 && testRotateRad.y == 1));
	}
	private void testRotateDeg() {
		// Test RotateDegrees
		Vec2 testRotateDeg = new Vec2(1, 0);
		testRotateDeg.RotateDegrees(90);
		Console.WriteLine("TestRotateDeg works?: " + (testRotateDeg.x <= 1 / 10000 && testRotateDeg.y == 1));
	}
	private void testRotateAroundDeg()
	{
		// Test RotateAroundDeg
		Vec2 testRotateAroundDeg = new Vec2(4, 6);
		Vec2 targetDeg = new Vec2(2, 1);
		testRotateAroundDeg.RotateAroundDeg(targetDeg, 90);
		Console.WriteLine("RotateAroundDeg works?: " + (testRotateAroundDeg.x == -3 && isApprox(testRotateAroundDeg.y, 3)));
	}
	private void testRotateAroundRad() {
		// Test RotateAroundRad
		Vec2 testRotateAroundRad = new Vec2(4, 6);
		Vec2 targetRad = new Vec2(2, 1);
		testRotateAroundRad.RotateAroundRad(targetRad, (float)(0.5f * Mathf.PI));
		Console.WriteLine("RotateAroundRad works?: " + (isApprox(testRotateAroundRad.x, -3) && isApprox(testRotateAroundRad.y, 3)));
	}
	private void testDot()
	{
		Vec2 myVec1 = new Vec2(2, 2);
		Vec2 myVec2 = new Vec2(3, 3);
		float dotProduct = myVec1.Dot(myVec2);
		Console.WriteLine("Dot works?: " + (dotProduct == 12));
	}
	private void testNormal()
	{
		Vec2 myVec = new Vec2(0, 1);
		myVec.Normal();
		Console.WriteLine("Normal works?: " + (myVec.x == 0 && myVec.y == 1));
	}
	private void testReflect()
	{
		Vec2 myVecNormalize = new Vec2(0, 1);
		Vec2 myVelocity = new Vec2(1, 1);
		myVelocity.Reflect(myVecNormalize);
		Console.WriteLine("Reflect works?: " + (myVelocity.x == -1 && myVelocity.y == 1));
	}
	private void testToString()
	{
		Vec2 myVec = new Vec2(1, 1);
		String myString = myVec.ToString();
		Console.WriteLine("ToString works?: " + (myString == "(1,1)"));
	}
	private bool isApprox(float myValue, float expectedValue)
	{
		return Mathf.Abs(myValue - expectedValue) < 1 / 100000f;
	}
}

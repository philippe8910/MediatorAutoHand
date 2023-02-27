using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditorModeTests
{
    private GameObject testObject;
    private EmissionRockAction emissionRockAction;

    [SetUp]
    public void Setup()
    {
        testObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        emissionRockAction = testObject.AddComponent<EmissionRockAction>();
        emissionRockAction.maxValue = 1;
        emissionRockAction.minValue = 0;
    }

    [Test]
    public void FadeIn_Test()
    {
        emissionRockAction.FadeIn();

        Assert.AreEqual(emissionRockAction.material.GetFloat(emissionRockAction.targetValueName), emissionRockAction.maxValue);
    }

    [Test]
    public void FadeOut_Test()
    {
        emissionRockAction.FadeOut();

        Assert.AreEqual(emissionRockAction.material.GetFloat(emissionRockAction.targetValueName), emissionRockAction.minValue);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(testObject);
    }
}

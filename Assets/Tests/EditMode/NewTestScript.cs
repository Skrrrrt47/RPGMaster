using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{

  [UnityTest]
public IEnumerator TestMove()
{
    int sum = 4 + 5;
    Assert.AreEqual(9,sum);
    yield return null;
}
[UnityTest]
public IEnumerator TestTilemap()
{
    bool temp = true;
    Assert.True(temp);
    yield return null;
}
public IEnumerator TestSpell()
{
    bool temp = true;
    Assert.True(temp);
    yield return null;
}
public IEnumerator TestGame()
{
    bool temp = true;
    Assert.True(temp);
    yield return null;
}
}

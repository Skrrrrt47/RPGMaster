using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{

  [UnityTest]
public IEnumerator TestName()
{
    var temp = new GameObject("player");
    Assert.AreEqual("player",temp.name);
    yield return null;
}
[UnityTest]
public IEnumerator TestStats()
{
    var stat = new GameObject("textValue");
    Assert.AreEqual("100/100",stat.name);
    yield return null;
}
}

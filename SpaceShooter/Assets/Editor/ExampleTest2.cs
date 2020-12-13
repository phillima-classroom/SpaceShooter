using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class ExampleTest2
{

    [UnityTest]
    public IEnumerator testeNaveExists() {
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");

        yield return null;
        Assert.IsTrue(GameObject.FindObjectOfType<Nave>());
    }

}

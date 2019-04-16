using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorUtil : MonoBehaviour {

    [MenuItem("MyEditor/Global Position")]
    public static void CheckGlobalPos()
    {
        var obj = Selection.gameObjects[0];
        Debug.Log(obj.transform.position);
    }
}

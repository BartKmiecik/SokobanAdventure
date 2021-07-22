using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncingText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float bouncines;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        bouncines = 3;
    }

    // Update is called once per frame
    void Update()
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;

        for (int j = 0; j < textInfo.characterCount; j++)
        {
            var charInfo = textInfo.characterInfo[j];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int i = 0; i < 4; ++i)
            {
                var orig = verts[charInfo.vertexIndex + i];
                verts[charInfo.vertexIndex + i] = orig + new Vector3(0, Mathf.Sin(Time.time * 7f + orig.x * 0.01f) * bouncines, 0);
            }

        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++) 
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, 0);
        }

        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransform : MonoBehaviour
{
    public List<GameObject> thicknesPieces = new List<GameObject>();
    public GameObject upBody;
    public GameObject torso;
    public GameObject root;

    public void Height(float value)
    {
        torso.transform.localScale += new Vector3(0, value, 0);
        upBody.transform.position += new Vector3(0, value*2, 0);
    }

    public void Thicknes(float value)
    {
        foreach (GameObject item in thicknesPieces)
        {
            item.transform.localScale += new Vector3(value, 0, value);
        }

        root.transform.localScale += new Vector3(value, value * 0.5f, value);
    }
}

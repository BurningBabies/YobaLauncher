using UnityEngine;
using System.Collections;

public class FixPosition : MonoBehaviour {

    private Vector3 pos;

    void LateUpdate()
    {
        if (pos == Vector3.zero) pos = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = pos;
	}
}

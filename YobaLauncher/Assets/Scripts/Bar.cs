using UnityEngine;
using System.Collections;

using DG.Tweening;

public class Bar : MonoBehaviour {

    public RectTransform mask;

    float startWidth;

    public float speed = 1100f;

    public float power
    {
        get
        {
            return mask.sizeDelta.x;
        }
    }

    void Start()
    {
        //DOTween.Init(false, false, LogBehaviour.ErrorsOnly);

        startWidth = mask.sizeDelta.x;

        StartCoroutine(PingPong());
    }

    IEnumerator PingPong()
    {
        bool left = true;
        while (true)
        {
            if (left)
            {
                Vector2 sizeDelta = mask.sizeDelta;
                sizeDelta.x = Mathf.MoveTowards(sizeDelta.x, 0f, Time.deltaTime * speed);
                mask.sizeDelta = sizeDelta;
                if (sizeDelta.x <= 0f)
                {
                    left = false;
                }
            }
            if (!left)
            {
                Vector2 sizeDelta = mask.sizeDelta;
                sizeDelta.x = Mathf.MoveTowards(sizeDelta.x, startWidth, Time.deltaTime * speed);
                mask.sizeDelta = sizeDelta;
                if (sizeDelta.x >= startWidth)
                {
                    left = true;
                }
            }
            yield return null;
        }
    }
	
	void Update () {
	}

    public void FadeOut() {
        StopAllCoroutines();
        foreach (Animator item in GetComponentsInChildren<Animator>())
        {
            item.SetTrigger("Fade");
        }
    }
}

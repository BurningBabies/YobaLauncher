using UnityEngine;
using System.Collections;

public class Yoba : MonoBehaviour {

    public Bar bar;

    public GameObject fire;

    public float impulsePower;

	void Start () {
        bar = GameObject.FindWithTag("Bar").GetComponent<Bar>();

    }

    void FixedUpdate()
    {
        if (!rigidbody2D.isKinematic)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, transform.position.y + (1.75f * 1f), -10f), Time.fixedDeltaTime * 5f);
        }
    }

	void Update () {
        if (Input.anyKeyDown && rigidbody2D.isKinematic)
        {
            Launch();
        }
	}

    void Launch()
    {
        rigidbody2D.isKinematic = false;

        foreach (ParticleSystem smoke in GetComponentsInChildren<ParticleSystem>())
        {
            //smoke.gameObject.SetActive(false);
            smoke.loop = false;
            smoke.transform.parent = null;
        }

        fire.SetActive(true);

        rigidbody2D.AddForce(new Vector2(0f, impulsePower * bar.power), ForceMode2D.Impulse);

        bar.FadeOut();
    }
}

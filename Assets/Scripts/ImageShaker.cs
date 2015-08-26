using UnityEngine;
using System.Collections;

public class ImageShaker : MonoBehaviour {

    private float rotationSpeed;
	// Use this for initialization
	void Start () {
        rotationSpeed = 1;
        StartCoroutine("Shake");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Shake()
    {
        bool clockwise = false;
        float shakingTime = 0;
        while(true)
        {
            Quaternion rotationAngle = transform.rotation;
            if (Mathf.Rad2Deg * rotationAngle.z > 10)
            {
                clockwise = true;
            }
            else if (Mathf.Rad2Deg * rotationAngle.z < -10)
            {
                clockwise = false;
            }
            if (!clockwise)
            {
                rotationAngle.z += rotationSpeed * (0.5f - Mathf.Abs(rotationAngle.z)) * Time.deltaTime;
            }
            else
            {
                rotationAngle.z -= rotationSpeed * (0.5f - Mathf.Abs(rotationAngle.z)) * Time.deltaTime;
            }
            shakingTime += Time.deltaTime;
            if (Mathf.Abs(rotationAngle.z) < 0.01f && shakingTime > 5)
            {
                rotationAngle.z = 0;
                transform.rotation = rotationAngle;
                break;
            }
            transform.rotation = rotationAngle;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}

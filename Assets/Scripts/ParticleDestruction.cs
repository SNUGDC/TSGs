using UnityEngine;
using System.Collections;

public class ParticleDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("SelfDestroy");
	}
	
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}

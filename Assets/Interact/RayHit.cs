using UnityEngine;
using System.Collections;

public class RayHit : MonoBehaviour {
	bool changed = false;
    public Texture altPic;
	Texture original;

	// Use this for initialization
	void Start () {
		original = GetComponent<Renderer> ().material.mainTexture;
	}
	
	// Update is called once per frame
	void Update () {
		if (changed) {
			StartCoroutine ("wait");
			changed = false;
		}
	}
    public void OnLook()
    {
		changed = true;
        GetComponent<Renderer>().material.mainTexture = altPic;
    }

	IEnumerator wait(){
		yield return new WaitForSeconds(2f);
		GetComponent<Renderer> ().material.mainTexture = original;
	}
}

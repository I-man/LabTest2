using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
   
    Vector3 size;
	bool changed = false;
	public Color altClr;
	Color original;

	// Use this for initialization
	void Start () {

        size = transform.localScale;
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);

        original = GetComponent<Renderer> ().material.color;
		altClr = new Color (Random.value, Random.value, Random.value);
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
		//GetComponent<Renderer>().material.color = altClr;
        SetSize(2f);
       

    }

    public void SetSize(float size)
    {
       
        this.transform.localScale = new Vector3(this.transform.localScale.x * size, this.transform.localScale.x * size, this.transform.localScale.z * size);
    }

    IEnumerator wait(){
		yield return new WaitForSeconds(2f);
		GetComponent<Renderer> ().material.color = original;
        this.transform.localScale = size;


    }

}

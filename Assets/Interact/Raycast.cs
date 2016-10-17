using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {
    public GameObject prefab;
    GameObject we;
    public float distanceToObject = 3f;
	public float downDistance = 0.2f;
    //Vector3 me = new Vector3(Screen.width / 2, Screen.height, 0);
    RaycastHit whatIHit;
	RaycastHit colorchangeHit;
    // Use this for initialization
    void Start () {
        
        we = (GameObject) Instantiate(prefab, Vector3.zero, Quaternion.identity);
        Debug.Log("have Use");
	}
	
	// Update is called once per frame
	void Update () {
		//Ray playerRayF = new Ray (transform.position + new Vector3 (0f, 0.7f, 0f), transform.forward);
		Ray playerRayD = new Ray (transform.position, Vector3.down);//Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height, 0));
		//Debug.DrawRay (playerRayF.origin, playerRayF.direction * distanceToObject, Color.black);
		Debug.DrawRay (playerRayD.origin, playerRayD.direction * downDistance, Color.black);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        //    if (Physics.Raycast(playerRayF, out whatIHit, distanceToObject))
        //{
            //if (whatIHit.collider.tag == "Balls")
            //{
            //    {
            //        whatIHit.collider.gameObject.GetComponent<SphereScript>().OnLook();
            //    }
            //}
           
                    
                
                    if (Physics.Raycast(ray, out hit))
                    {
                    if (hit.collider.tag == "Number")
                    {
                        Debug.Log("I touched " + hit.collider.gameObject.name);

                        hit.collider.gameObject.GetComponent<RayHit>().OnLook();

                        }
                        else if (hit.collider.tag == "Balls")
                        {
                        Debug.Log("I touched " + hit.collider.gameObject.name);
                        hit.collider.gameObject.GetComponent<SphereScript>().OnLook();
                    we.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text  = "X= " + hit.collider.gameObject.transform.position.x + " Y= " + hit.collider.gameObject.transform.position.y + " Z= " + hit.collider.gameObject.transform.position.z;
                    we.GetComponentInChildren<RectTransform>().GetComponentInChildren<Text>().text = hit.collider.gameObject.name;






                }
                    }

                //} for the PhysicsRaycast F
            }

            if (Physics.Raycast(playerRayD, out colorchangeHit, downDistance))
            {




                if (colorchangeHit.collider.tag == "Number")
                {
                    //Destroy (colorchangeHit.collider.gameObject);
                    colorchangeHit.collider.gameObject.GetComponent<Renderer>().material.color = Color.cyan;

                }




            }
        }
            
	
	
	}
    


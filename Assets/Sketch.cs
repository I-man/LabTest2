using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour
{
    public GameObject myPrefab;
    private string _WebsiteURL = "http://productsetup.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";

    void Start()
    {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		TreeSurvey[] tree = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

        //----------------------
		int totalSpheres = tree.Length;
        Debug.Log("totalSpheres:" + totalSpheres );

        for (int i = 0; i < totalSpheres; i++)
            {
               
			float x = float.Parse(tree [i].X);
			float y = float.Parse(tree [i].Y);
			float z = float.Parse(tree [i].Z);
            Debug.Log("This has been activated at:" + x + " " + y + " " + z);

                var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.name = "Tree " + tree[i].TreeID;
            newCube.GetComponentInChildren<TextMesh>().text = newCube.name;






        }
        //}

    }


// Update is called once per frame
void Update () {
	
	}
}

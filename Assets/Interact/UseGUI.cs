using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseGUI : MonoBehaviour {
	bool showGUI = true;
    
    void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
			showGUI = false;

        
       
	}

	void OnGUI()
	{
		if(showGUI)
		{
			if(GUI.Button(new Rect(0, 0, 400, 50), "Click object to view coordinates"))
			{
				showGUI = false;
			}
		}
 
	}


}

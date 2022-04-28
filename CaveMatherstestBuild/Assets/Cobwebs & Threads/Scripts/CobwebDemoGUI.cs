using UnityEngine;
using System.Collections;

public class CobwebDemoGUI : MonoBehaviour {
	
	public GameObject[] showcaseObjects;
	
	CobwebDemoCamera cam;
	
	int maxSelection;
	int currentSelection = 0;
	
	bool autoRotate = true;
	
	void Start ()
	{		
		foreach(GameObject obj in showcaseObjects)
		{
			obj.GetComponent<Renderer>().enabled = false;
		}
		
		currentSelection = 0;
		maxSelection = showcaseObjects.Length;
		showcaseObjects[currentSelection].GetComponent<Renderer>().enabled = true;
		
		cam = Camera.main.GetComponent<CobwebDemoCamera>();
		//cam.target = showcaseObjects[currentSelection].transform;
		cam.distance = showcaseObjects[currentSelection].GetComponent<Renderer>().bounds.extents.sqrMagnitude * 1.5f;
	}
	
	// Update is called once per frame
	void Update()
	{
		autoRotate = cam.autoRotate;
	}
	
	
	void DisplayPrevious()
	{
		int newSelect = currentSelection - 1;
		
		if(newSelect >= 0)
		{
			//Debug.Log("OK!");
			showcaseObjects[currentSelection].GetComponent<Renderer>().enabled = false;
			showcaseObjects[newSelect].GetComponent<Renderer>().enabled = true;
			currentSelection = newSelect;
			
			//cam.target = showcaseObjects[currentSelection].transform;
			cam.distance = showcaseObjects[currentSelection].GetComponent<Renderer>().bounds.extents.sqrMagnitude * 1.5f;
		}
	}
	
	
	void DisplayNext()
	{
		int newSelect = currentSelection + 1;
		
		if(newSelect < maxSelection)
		{
			//Debug.Log("OK!");
			showcaseObjects[currentSelection].GetComponent<Renderer>().enabled = false;
			showcaseObjects[newSelect].GetComponent<Renderer>().enabled = true;
			currentSelection = newSelect;
			
			//cam.target = showcaseObjects[currentSelection].transform;
			cam.distance = showcaseObjects[currentSelection].GetComponent<Renderer>().bounds.extents.sqrMagnitude * 1.5f;
		}
	}
	
	
	void OnGUI()
	{
		GUI.Label(new Rect( (Screen.width / 2) - 150, Screen.height - 40, 300, 20), "Use Arrow Keys to Rotate, Scrollwheel to Zoom");
				
		if(GUI.Button(new Rect(20, 20, 100, 20), "<< Prev"))
			DisplayPrevious();
		
		if(GUI.Button(new Rect(140, 20, 100, 20), "Next >>"))
			DisplayNext();
		
		if(GUI.Toggle(new Rect(260, 20, 100, 20), autoRotate, new GUIContent("Auto-Rotate?")))
			cam.autoRotate = !cam.autoRotate;
		
		GUI.Label(new Rect(20, 60, 300, 20), showcaseObjects[currentSelection].name.ToString().ToUpper() );
		
		//GUI.Label(new Rect(20, 100, 600, 20), "Bounds: " + showcaseObjects[currentSelection].renderer.bounds.ToString() );
	}
}

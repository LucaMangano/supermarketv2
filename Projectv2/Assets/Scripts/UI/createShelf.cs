using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class createShelf : MonoBehaviour {

	public int width;
	public int height;

	List<GameObject> shelves;
	List<string> shelvesNames;
	RectTransform r;

	GameObject hover;

	public float mousex;
	public float mousey;

	void Start () {
		width = 5;
		height = 5;
		shelves = new List<GameObject>();
		shelves.Add (GameObject.Find("shelf00"));
		shelves.Add (GameObject.Find("shelf10"));
		shelves.Add (GameObject.Find("shelf20"));
		shelves.Add (GameObject.Find("shelf30"));
		shelves.Add (GameObject.Find("shelf40"));

		shelves.Add (GameObject.Find("shelf01"));
		shelves.Add (GameObject.Find("shelf11"));
		shelves.Add (GameObject.Find("shelf21"));
		shelves.Add (GameObject.Find("shelf31"));
		shelves.Add (GameObject.Find("shelf41"));

		shelves.Add (GameObject.Find("shelf02"));
		shelves.Add (GameObject.Find("shelf12"));
		shelves.Add (GameObject.Find("shelf22"));
		shelves.Add (GameObject.Find("shelf32"));
		shelves.Add (GameObject.Find("shelf42"));

		shelves.Add (GameObject.Find("shelf03"));
		shelves.Add (GameObject.Find("shelf13"));
		shelves.Add (GameObject.Find("shelf23"));
		shelves.Add (GameObject.Find("shelf33"));
		shelves.Add (GameObject.Find("shelf43"));

		shelves.Add (GameObject.Find("shelf04"));
		shelves.Add (GameObject.Find("shelf14"));
		shelves.Add (GameObject.Find("shelf24"));
		shelves.Add (GameObject.Find("shelf34"));
		shelves.Add (GameObject.Find("shelf44"));

		shelvesNames = new List<string>();
		shelvesNames.Add ("00");
		shelvesNames.Add ("10");
		shelvesNames.Add ("20");
		shelvesNames.Add ("30");
		shelvesNames.Add ("40");

		shelvesNames.Add ("01");
		shelvesNames.Add ("11");
		shelvesNames.Add ("21");
		shelvesNames.Add ("31");
		shelvesNames.Add ("41");

		shelvesNames.Add ("02");
		shelvesNames.Add ("12");
		shelvesNames.Add ("22");
		shelvesNames.Add ("32");
		shelvesNames.Add ("42");

		shelvesNames.Add ("03");
		shelvesNames.Add ("13");
		shelvesNames.Add ("23");
		shelvesNames.Add ("33");
		shelvesNames.Add ("43");

		shelvesNames.Add ("04");
		shelvesNames.Add ("14");
		shelvesNames.Add ("24");
		shelvesNames.Add ("34");
		shelvesNames.Add ("44");

		hover = GameObject.Find ("hover");
	}

	void Update () {
		mousex = (Input.mousePosition.x);
		mousey = (Input.mousePosition.y);
		foreach (GameObject s in shelves) {
			r = (RectTransform)s.transform;
			if (mousex > s.transform.position.x - (r.rect.width/2) && mousex < s.transform.position.x + (r.rect.width/2)) {
				if(mousey > s.transform.position.y - (r.rect.height/2) && mousey < s.transform.position.y + (r.rect.height/2)) {
					hover.transform.position = s.transform.position;
				}
			}
		}
	}

	public void placeObject(int shelfNumber){
		GameObject scripts = GameObject.Find ("scripts");
		GameObject obj = scripts.GetComponent<moveObject>().getObj();
		int objNumber = scripts.GetComponent<moveObject>().getObjNumber();

		GameObject onShelfObject = GameObject.Find ("obj"+shelvesNames [shelfNumber]);

		foreach (Transform child in GameObject.Find("placed").transform) {
			for (int i = 0; i <= 12; i++) { 																	//number of items
				if (child.gameObject.name == "placed" + shelfNumber + "/" + i) {
					Destroy (child.gameObject);
					break;
				}
			}
		}

		GameObject newObj = Instantiate (obj, onShelfObject.transform.position, Quaternion.identity) as GameObject;
		newObj.transform.SetParent (GameObject.Find ("placed").transform, true);
		newObj.name = "placed" + shelfNumber + "/" + objNumber;
	}

	public void loadShelf(List<string> layout){
		foreach (Transform child in GameObject.Find("placed").transform) {
			for (int l = 0; l <= 24; l++) {
				for (int i = 0; i <= 12; i++) { 																	//number of items
					if (child.gameObject.name == "placed" + l + "/" + i) {
						Destroy (child.gameObject);
					}
				}
			}
		}

		foreach (string l in layout) {
			List<string> myList = l.Split('/').ToList();
			print (myList [0] + " " + myList [1]);
			int shelfNumber = int.Parse (myList [0]);
			int objNumber = int.Parse(myList [1]);

			GameObject onShelfObject = GameObject.Find ("obj"+shelvesNames [shelfNumber]);

			GameObject newObj = Instantiate (GameObject.Find ("obj"+objNumber+"Image"), onShelfObject.transform.position, Quaternion.identity) as GameObject;
			newObj.transform.SetParent (GameObject.Find ("placed").transform, true);
			newObj.name = "placed" + shelfNumber + "/" + objNumber;
		}
	}
}

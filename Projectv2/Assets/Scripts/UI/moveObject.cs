using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {

	int objNumber;
	GameObject obj;

	float mousex;
	float mousey;
	Vector3 mouseposition;

	bool objMoving;

	void Start () {
		obj = new GameObject();
		objMoving = false;
	}
	
	void Update () {
		if (objMoving) {
			mousex = (Input.mousePosition.x);
			mousey = (Input.mousePosition.y);
			mouseposition = new Vector3 (mousex, mousey, 0);
			obj = GameObject.Find ("obj"+objNumber+"Image");
			obj.transform.position = mouseposition;
		}
	}

	public void showObject(int number){
		if (objMoving) {
			if (objNumber == number) {
				objMoving = false;
				objReset (objNumber);
				objNumber = new int ();
			} else {
				objReset (objNumber);
				objNumber = number;
			}
		} else {
			objMoving = true;
			objNumber = number;
		}

	}

	void objReset(int number){
		obj = GameObject.Find ("obj"+objNumber+"Image");
		obj.transform.position = new Vector3 (-200, -200, 0);
	}

	public GameObject getObj(){
		return obj;
	}

	public int getObjNumber(){
		return objNumber;
	}
}

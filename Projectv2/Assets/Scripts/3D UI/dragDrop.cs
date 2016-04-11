using UnityEngine;
using System.Collections;

public class dragDrop : MonoBehaviour {

	private bool dragging = false;
	private float distance;
	GameObject shadow;
	GameObject drag;
	float shelf0x;
	float shelf1x;
	float shelf2x;
	float shelf3x;
	float shelf4x;
	float shelf5x;
	float shelf0y;
	float shelf1y;
	float shelf2y;
	float shelf3y;
	float shelf4y;
	float shelf5y;

	void OnMouseDown()
	{
		if (gameObject.name.Contains("drag")) {
			Destroy (gameObject);
		} else {
			distance = Vector3.Distance (transform.position, Camera.main.transform.position);
			dragging = true;
			shadow = Instantiate (gameObject);
			shadow.name = "shadow" + gameObject.name;
			drag = Instantiate (gameObject);
			drag.name = "drag"+gameObject.name;
		}
	}

	void OnMouseUp()
	{
		dragging = false;
		drag.transform.position = new Vector3 (shadow.transform.position.x, shadow.transform.position.y, 553);
		DontDestroyOnLoad (drag);
		Destroy (shadow);
	}

	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(554.0f);
			drag.transform.position = rayPoint;
			manageShadowPos (rayPoint);
		}
	}

	void manageShadowPos(Vector3 rayPoint){
		float y = rayPoint.y;
		float x = rayPoint.x;
		float shelfWidth = GameObject.Find ("shelf0").transform.localScale.x;
		float shelfPosition = GameObject.Find ("shelf0").transform.position.x;

		if (rayPoint.y > 240) {
			y = 240;
		} else if (rayPoint.y <= 240 && rayPoint.y > 160) {
			y = 160;
		} else if (rayPoint.y <= 160 && rayPoint.y > 80) {
			y = 80;
		} else if (rayPoint.y <= 80 && rayPoint.y > 0) {
			y = 0;
		} else if (rayPoint.y <= 0 && rayPoint.y > -80) {
			y = -80;
		} else if (rayPoint.y <= -80 && rayPoint.y > -160) {
			y = -160;
		} else if (rayPoint.y <= -160 && rayPoint.y > -240) {
			y = -240;
		} else if (rayPoint.y <= -240) {
			y = -240;
		}

		if (rayPoint.x <= -shelfWidth/2+shelfPosition+shadow.GetComponent<Renderer>().bounds.size.x/2) {
			x = -shelfWidth/2+shelfPosition+shadow.GetComponent<Renderer>().bounds.size.x/2;
		} else if (rayPoint.x >= shelfWidth/2+shelfPosition-shadow.GetComponent<Renderer>().bounds.size.x/2) {
			x = shelfWidth/2+shelfPosition-shadow.GetComponent<Renderer>().bounds.size.x/2;
		} 
		shadow.transform.position = new Vector3 (x, y+shadow.GetComponent<Renderer>().bounds.size.y/2 + 5, 555);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shelfSize : MonoBehaviour {

	public void changeShelfWidth(){
		float value = GameObject.Find ("SliderWidth").GetComponent<Slider>().value;
		for (int i = 0; i <= 6; i++) {
			GameObject obj = GameObject.Find ("shelf" + i);
			obj.transform.localScale = new Vector3(value, obj.transform.localScale.y, obj.transform.localScale.z);
		}
	}

	public void changeShelfHieght(){
		float value = GameObject.Find ("SliderHeight").GetComponent<Slider>().value;
		for (int i = 0; i < 6; i++) {
			GameObject obj = GameObject.Find ("shelf" + i);
			obj.GetComponent<Renderer> ().enabled = false;
		}
		for (int i = 0; i < 6; i++) {
			if (i <= value) {
				GameObject obj = GameObject.Find ("shelf" + i);
				obj.GetComponent<Renderer> ().enabled = true;
			}
		}
	}
}

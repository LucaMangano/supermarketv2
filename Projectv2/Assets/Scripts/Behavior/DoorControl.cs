using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	public Animator animator; 
	public string onTriggerEnterParameterName;
	public string onTriggerExitParameterName;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player"){
		animator.SetTrigger(onTriggerEnterParameterName);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player"){
			animator.SetTrigger(onTriggerExitParameterName);
		}
	}

}

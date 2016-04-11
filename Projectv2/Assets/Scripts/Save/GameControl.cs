using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public float health;
	public float experience;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadExplorer(){
		Application.LoadLevel ("explorer");
	}
}

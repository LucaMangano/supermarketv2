using UnityEngine;
using System.Collections;

public class PowerCollect : MonoBehaviour {

	public int _collideDistance = 4;
	GameObject player;
	GameObject powerUp;
	GameObject powerDown;

	public static bool playSound = false; 
	public float powerEffect = 5;

	// Use this for initialization
	void Start () {

		powerUp = GameObject.FindWithTag("Power_Up");
		powerDown = GameObject.FindWithTag("Power_Down");
		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

        destroyThis();
	
	}

    void destroyThis()
    {
		float powerChange;
        
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) < _collideDistance)
        {
			if(powerUp){
				CartController.SpeedChange(powerEffect);
				print("This was a POSITIVE power-up! speed is now: " + CartController._movementSpeed + ", and max speed is: " + CartController.MaxSpeed ); 
				//playSound = true;
				Destroy(this.gameObject);
			} else if (powerDown) {
				CartController.SpeedChange(-powerEffect);
				print("This was a NEGATIVE power-up! speed is now: " + CartController._movementSpeed + ", and max speed is: " + CartController.MaxSpeed ); 
				Destroy(this.gameObject);
			}
        }

    }
}


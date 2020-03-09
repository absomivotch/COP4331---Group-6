using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandanaSpawn : MonoBehaviour
{
	public GameObject bandana;
    private Vector3 monkeyPosition;
    private Quaternion monkeyRotation;

	
    void Start()
    {

        monkeyPosition = new Vector3(this.transform.position.x,
                        this.transform.position.y+5,
                        this.transform.position.z);

        monkeyRotation = Quaternion.Euler(-90,0,180);



		Instantiate(
                    bandana,
                    monkeyPosition,
                    monkeyRotation,
                    this.transform);      

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float movementspeed;
    void Start()
    {
        
    }
    void Update()
    {
    	    //movement
	    Vector3 move = new Vector3(Input.GetAxis("Horizontal")*movementspeed,0,Input.GetAxis("Vertical")*movementspeed).normalized;	    
	    transform.Translate(move*movementspeed*Time.deltaTime,Space.World);
	    //rotation
	    if (move != Vector3.zero)
	    {
		    transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(move),movementspeed*Time.deltaTime);
	    }
	    //animation
	    if (Mathf.Abs(Input.GetAxis("Horizontal"))!= 0 || Mathf.Abs(Input.GetAxis("Vertical"))!=0)
	    {
	    	GetComponent<Animator>().SetBool("running",true);
	    }
	    else
	    {
	    	GetComponent<Animator>().SetBool("running",false);
	    }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpScript : MonoBehaviour
{
	private GameObject unitychan;
    public GameObject pair_warp;

	private float distance;

   
    //public GameObject Xkey_sentence;

    // Start is called before the first frame update
    void Start()
    {
		unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
		distance = Vector3.Distance(this.transform.position, unitychan.transform.position);
        

        if (this.distance <= 1.4f)
		{
            pair_warp.GetComponent<warpScript>().enabled = false;
            

            //Debug.Log("in");
            if (Input.GetKeyDown(KeyCode.X))
			{
                //Debug.Log("X");
                Debug.Log(pair_warp);
                unitychan.transform.position = pair_warp.transform.position;   
            }
            
        }
        else{
            pair_warp.GetComponent<warpScript>().enabled = true;
            
        }

		//Debug.Log(distance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    //爆発エフェクト
	public GameObject explosion;
    private Transform handPos;

    //魔法系
    private Rigidbody torch_rg;
    private float elapseTime;
    [SerializeField]
    private float destroyTime = 2.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        torch_rg = GetComponent<Rigidbody>();
        handPos = GameObject.FindGameObjectWithTag("handPos").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (torch_rg.velocity.magnitude != 0f)
        {
            
            elapseTime += Time.deltaTime;
            if (elapseTime >= destroyTime)
            {
                Destroy(this.gameObject);
            }
            
        }

    }


    private void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.tag == "field")
		{
            MakeExplosion();
		}

        if (collision.gameObject.tag == "stone")
        {
            MakeExplosion();
            Destroy(collision.gameObject);   
        }

    }

    private void MakeExplosion()
    {
        GameObject exploded = Instantiate(explosion, this.transform.position - this.transform.forward * 1f, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
        Destroy(exploded, 3f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagicScript : MonoBehaviour
{
	private Animator _animator;
	//private PointerScript _pointerContoller;


	//魔法系
	[SerializeField]
	private GameObject fireBall;
	private GameObject new_fireBall;
	private Rigidbody fm_rg; // 
	private Transform handPos;　//ユニティちゃんの手の位置(火球生成位置)
	private float coolTime = 0.8f;
    private bool cancastFlag = true; //魔法を放てるかのフラグ

    private PointerScript pointerScript;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		//_pointerContoller = FindObjectOfType<PointerController>();
		handPos = GameObject.FindGameObjectWithTag("handPos").GetComponent<Transform>();
        pointerScript = FindObjectOfType<PointerScript>();
	}

	private void Update()
	{

		//魔法の際のアニメーション 
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
			//クールタイムを満たしていれば
			if (cancastFlag)
			{
                //構える
                _animator.SetBool("magic_setup", true);

                //火球生成
                new_fireBall = Instantiate(fireBall, handPos.position, Quaternion.identity) as GameObject;
				fm_rg = new_fireBall.GetComponent<Rigidbody>();
			}

		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{

			//火球があれば発射
			if (new_fireBall)
			{
                //攻撃放つアニメーション 
                _animator.SetBool("magic_setup", false);
                _animator.SetTrigger("magic_attack");


                var magic_direction = pointerScript.MagicDirection();
                fm_rg.AddForce(magic_direction * 700f);
                cancastFlag = false;
                StartCoroutine(setCanCastFlag(coolTime));
			}
		}
	}

    IEnumerator setCanCastFlag(float cooltime)
    {
        yield return new WaitForSeconds(cooltime);

        cancastFlag = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject unitychan;
    private Animator _animator;

    //カメラ系
    private Vector3 offset;
    private Vector3 startPos;
    public Transform defaultPos;
    public Transform zoomPos;

    private float moveSpeed_camera = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //座標計算用
        unitychan = GameObject.Find("unitychan");
        
        //カメラとユニティちゃんの距離
        this.transform.position = defaultPos.position;
        offset = transform.position - unitychan.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //今の位置を保持
        startPos = transform.position;

        //移動で使う
        float step = moveSpeed_camera * Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
        {

            //カメラを頭の横に接近
            this.transform.position = Vector3.MoveTowards(startPos, zoomPos.position, step);
            transform.forward = unitychan.transform.forward;
            offset = defaultPos.position - unitychan.transform.position;

        }
        else
        {

            //カメラをunityちゃん背後に
            this.transform.position = Vector3.MoveTowards(startPos, unitychan.transform.position + offset, step);

        }


        //向きをunitychanと同じほうへ、カメラをユニティチャンの背後へ、オフセット更新
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.forward = unitychan.transform.forward;
            this.transform.position = defaultPos.position;
            offset = transform.position - unitychan.transform.position;
        }


    }
}




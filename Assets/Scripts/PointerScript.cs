using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
	//ユニティちゃん
	[SerializeField]
	private GameObject unitychan;
    [SerializeField]
    private GameObject maincamera;

	//ポインター
	[SerializeField]
	private GameObject pointer;
    private Vector3 magic_direction;
    private Vector3 pointer_pos;

    //魔法を飛ばす方向の場合わけ
    private enum DirectionType
	{
		toFront,
		toPointer
	}
	private DirectionType directionType;


	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
            //魔法の射出方向
            //MagicDirection(pointer_pos);

			//スペースキーを離すとポインタ非表示
			pointer.SetActive(false);

		}
		else if (Input.GetKey(KeyCode.Space))
		{
			//ポインター表示処理
			Vector2 touchScreenPosition = Input.mousePosition;
			touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width);
			touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height);

			Camera mainCamera = Camera.main;
			Ray touchPointToRay = mainCamera.ScreenPointToRay(touchScreenPosition);
			RaycastHit hitInfo = new RaycastHit();

			if (Physics.Raycast(touchPointToRay, out hitInfo))
			{
				//ポインター表示
				pointer.SetActive(true);

				//ポインターの位置調整
				if (Physics.Linecast(maincamera.transform.position, hitInfo.point, out hitInfo))
				{
					pointer.transform.position = hitInfo.point + hitInfo.normal * 0.5f;
				}

				////魔法の方向を決める
				if (hitInfo.collider != null)
				{

					if (hitInfo.collider.tag == "stone")
					{
						//石に標準がある時
						directionType = DirectionType.toPointer;
						pointer_pos = hitInfo.collider.transform.position;
						//magic_direction = (hitInfo.collider.transform.position - unitychan.transform.position).normalized;

					}
					else
					{
						//石以外の時
						directionType = DirectionType.toPointer;
						pointer_pos = hitInfo.point;
						//magic_direction = (hitInfo.point - unitychan.transform.position).normalized;
					}
				}

			}
			else
			{
				//ポインターオフ
				pointer.SetActive(false);

				//ポインターが空中の時
				directionType = DirectionType.toFront;
                
				//magic_direction = unitychan.transform.forward;
			}
		}
	}




    public Vector3 MagicDirection()
    {
        switch (directionType)
        {
            case DirectionType.toPointer:
                magic_direction = (pointer_pos - unitychan.transform.position).normalized;
                break;

            case DirectionType.toFront:
                magic_direction = unitychan.transform.forward;
                break;
        }

        return magic_direction;
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 플레이어의 이동을 담당하는 클래스입니다.
/// </summary>
public class PlayerMove : MonoBehaviour
{

    public float Speed;
    public float RotateSpeed;
    public int MaxRotate;
    public float Score;

    // Use this for initialization
    void Start()
    {

    }

    #region 터치 로직

    bool _LeftMoveCheck()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return true;
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x < Camera.main.pixelWidth / 2)
            {
                return true;
            }
        }
        // 터치 이벤트 추가
        return false;
    }
    bool _RightMoveCheck()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Camera.main.pixelWidth / 2)
            {
                return true;
            }
        }
        // 터치 이벤트 추가
        return false;
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Score += 1;
        }

        if (_LeftMoveCheck())
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                var Cubes = GameObject.FindGameObjectsWithTag("Cube");
                foreach (var item in Cubes)
                {
                    item.transform.Translate(Vector3.left * Speed * Time.deltaTime);
                }
                if (Camera.main.transform.rotation.eulerAngles.z <= MaxRotate || Camera.main.transform.rotation.eulerAngles.z >= 360 - MaxRotate)
                {
                    Camera.main.transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (Camera.main.transform.rotation.eulerAngles.z < MaxRotate + 1 && Camera.main.transform.rotation.eulerAngles.z > 0)
            {
                Camera.main.transform.Rotate(0, 0, -RotateSpeed * 2 * Time.deltaTime);
            }
        }

        if (_RightMoveCheck())
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                var Cubes = GameObject.FindGameObjectsWithTag("Cube");
                foreach (var item in Cubes)
                {
                    item.transform.Translate(Vector3.right * Speed * Time.deltaTime);
                }
                if (Camera.main.transform.rotation.eulerAngles.z >= 360 - MaxRotate || Camera.main.transform.rotation.eulerAngles.z <= MaxRotate)
                {
                    Camera.main.transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (Camera.main.transform.rotation.eulerAngles.z < 360 && Camera.main.transform.rotation.eulerAngles.z > 360 - (MaxRotate + 1))
            {
                Camera.main.transform.Rotate(0, 0, RotateSpeed * 2 * Time.deltaTime);
            }
        }

    }
}

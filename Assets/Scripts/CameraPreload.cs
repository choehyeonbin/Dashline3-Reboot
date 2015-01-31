using UnityEngine;
using System.Collections;

/// <summary>
/// 게임에 사용되는 카메라를 초기 위치로 재조정합니다.
/// </summary>
public class CameraPreload : MonoBehaviour {

    public int Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > -10) transform.Translate(Vector3.back * Speed * Time.deltaTime);
        if (transform.rotation.eulerAngles.x < 10)
        {
            transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        }
        if (transform.position.y < 1.3)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            if (transform.position.y > 1.3)
            {
                transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
            }
        }
	}
}

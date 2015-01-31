using UnityEngine;
using System.Collections;

/// <summary>
/// 배경 오브젝트의 이동을 담당하는 클래스입니다.
/// </summary>
public class NightSkyMove : MonoBehaviour {

    public float Speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        if (transform.position.x > 45f)
        {
            this.transform.position = new Vector3(-45f, 2.7f, 15.3f);
        }
	}
}

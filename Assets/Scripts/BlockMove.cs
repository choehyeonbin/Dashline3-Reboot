using UnityEngine;
using System.Collections;

/// <summary>
/// 충돌체 오브젝트의 이동을 담당하는 클래스입니다.
/// </summary>
public class BlockMove : MonoBehaviour {

    public int Speed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update()
    {
        //if(GameObject.FindGameObjectWithTag("Player") != null)
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

    /// <summary>
    /// 충돌체가 다른 오브젝트와 닿았을 때 호출되는 메서드입니다.
    /// </summary>
    /// <param name="target"></param>
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
        else if (target.tag == "Remover")
        {
            Destroy(this.gameObject);
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score += 0.5f;
            }
        }
    }
}

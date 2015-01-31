using UnityEngine;
using System.Collections;

/// <summary>
/// 스코어를 관리하는 클래스입니다.
/// </summary>
public class ScoreManager : MonoBehaviour {

    public int HighScore;
    FileManagment fm;

	// Use this for initialization
	void Start () {
        // 스코어 읽어들임
        fm = new FileManagment();
        var ReadedScore = fm.ReadStringFromFile("Score");
        if (ReadedScore != null)
            HighScore = int.Parse(ReadedScore);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

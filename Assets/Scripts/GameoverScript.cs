using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 현재 게임 상태에 따라 게임오버인지 아닌지 판별하고 그에 따라 인터페이스에 변화를 주는 클래스입니다.
/// </summary>
public class GameoverScript : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Panel;
    public GameObject ScoreText;
    public GameObject BsetScoreText;
    public GameObject GameGUICanvas;

    FileManagment fm;

    public float PanelSpeed;
    int Score;
    int ScoreIncreaseSpeed;

    // Use this for initialization
    void Start()
    {
        fm = new FileManagment();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            if (Canvas.activeSelf == false)
            {
                Canvas.SetActive(true);
                GameGUICanvas.SetActive(false);
                ScoreIncreaseSpeed = (int)GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score / 100;
                if (
                    GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score > 
                    (int)GameObject.FindGameObjectWithTag("System").GetComponent<ScoreManager>().HighScore)
                {
                    GameObject.FindGameObjectWithTag("System").GetComponent<ScoreManager>().HighScore = 
                        (int)(GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score);

                    fm.WriteStringToFile(((int)GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score).ToString() , "Score");
                }
                BsetScoreText.GetComponent<Text>().text += GameObject.FindGameObjectWithTag("System").GetComponent<ScoreManager>().HighScore.ToString();
            }
            //if (Panel.transform.position.x < camera.pixelWidth / 2)
            //{
            //    Panel.transform.Translate(Vector3.right * PanelSpeed);
            //}else 
            if (GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score > Score)
            {
                Score+= ScoreIncreaseSpeed;
                if (GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score < Score)
                {
                    Score = (int)GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score;
                }
                ScoreText.GetComponent<Text>().text = Score.ToString();
            }
        }

    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Pattern클래스를 상속받은 클래스의 목록을 나타낸 열거형입니다.
/// </summary>
public enum Patterns
{
    StartDoubleline, RandomGenerate
}

#region Patterns

/// <summary>
/// ※ 미구현
/// 10초간 평행한 두 직선의 형태로 블록이 내려옵니다.
/// </summary>
public class StartDoubleline : Pattern
{
    float GenerateDelay = 0.3f;

    public StartDoubleline() : base ()
    {
        this.DurationTime = 10;
    }

}

/// <summary>
/// 10초간 랜덤하게 블록이 생성됩니다.
/// </summary>
public class RandomGenerate : Pattern
{
    public RandomGenerate() : base ()
    {
        this.DurationTime = 10;
    }

    public override float[] Update()
    {
        base.Update();
        var LocationList = new List<float>();
        if(Random.Range(0, 10) == 0)
        {
            LocationList.Add(Random.Range(-100, 100)/10);

            this.LastGeneratedTime = Time.fixedTime - StartedTime;
        }

        return LocationList.ToArray();
    }
}

/// <summary>
/// 블록을 사출할 패턴의 기본이 되는 클래스 입니다.
/// 1. 자식 클래스에서 생성자를 정의하고 DurationTime에 원하는 지속 시간을 대입합니다.
/// 2. Update() 메서드를 재정의 한 후 base.Update()를 호출한 후에 원하는 구문을 써넣으십시오.
/// </summary>
public class Pattern
{
    public static GameObject Block;

    public bool DeadFlag { get { return deadFlag; } }
    private bool deadFlag;

    public float StartedTime;
    public float DurationTime;
    public float LastGeneratedTime;


    public Pattern()
    {
        LastGeneratedTime = 0;
        this.StartedTime = Time.fixedTime;
    }

    public virtual float[] Update()
    {
        if(Time.fixedTime - this.StartedTime >=DurationTime)
        {
            deadFlag = true;
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("System").GetComponent<PlayerMove>().Score += 100;
            }
        }

        return null;
    }
}


#endregion

/// <summary>
/// 충돌체를 만들어내는 컴포넌트입니다.
/// 멤버 변수 GamePattern은 현재 블록을 만들어내는 패턴을 나타냅니다.
/// Pattern 클래스를 상속받은 클래스를 할당하면 정해진 시간 동안 해당 패턴대로 충돌체를 사출합니다.
/// </summary>
public class BlockMaker : MonoBehaviour
{

    public GameObject Block;
    Pattern GamePattern;
    public GameObject NowBar;
    Random Rand;

    // Use this for initialization
    void Start()
    {
        Rand = new Random();
        Pattern.Block = this.Block;
        GamePattern = new RandomGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        if (GamePattern.DeadFlag) GenerateNextPattern();
        CreateNewBlock(GamePattern.Update());

        NowBar.transform.position = new Vector3(
            120 + ((Time.fixedTime - GamePattern.StartedTime) / GamePattern.DurationTime) * 350,
            NowBar.transform.position.y, NowBar.transform.position.z);
    }

    void GenerateNextPattern()
    {
        switch (UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Patterns)).Length))
        {
            case (int)Patterns.StartDoubleline:
                GamePattern = new StartDoubleline();
                break;
            case (int)Patterns.RandomGenerate:
                GamePattern = new RandomGenerate();
                break;
        }
    }

    void CreateNewBlock(params float[] Position)
    {
        foreach (var item in Position)
        {
            var newObj = (GameObject)Instantiate(Block, new Vector3(item, this.transform.position.y, this.transform.position.z), transform.rotation);
        }
    }
}
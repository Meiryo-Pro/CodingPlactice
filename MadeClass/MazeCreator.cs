using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/**
*このプログラムは下記書籍を参考にしています。
*
*牙竜 (2018)　No5 3D迷路
*吉谷 幹人・布留川 英一・一條 貴彰・西森 丈俊・藤岡 裕吾・室星 亮太・車谷 勇人・湊 新平
*・土屋 つかさ・黒河 優介・中村 優一・牙竜・コポコポ・かせ・hataken・monmoko 
*Unityゲーム プログラミング・バイブル 株式会社ボーンデジタル pp123-125.
**/

public class MazeCreator : MonoBehaviour
{
    [SerializeField, Tooltip("壁となるprefabを設定すること")]
    private GameObject wall;

    [SerializeField, Tooltip("床となるprefabを設定すること")]
    private GameObject floor;

    [SerializeField, Tooltip("天井となるprefabを設定すること")]
    private GameObject ceiling;

    private const int FailVal = -1; //エラーを返したり、絶対に被らない初期値を設定したい時に使う

    [SerializeField, Tooltip("5以上の奇数を入力すること。")]
    private int mazeSideSize = 5; //外壁を含めないマップの一辺の長さ
    private int EntireMazeSideSize { get; set; } //外壁を含めた全体のマップの一辺の長さ

    private int[,] Maze { get; set; }

    private int CurrentX { get; set; } = FailVal; //現在地のx座標

    private int CurrentY { get; set; } = FailVal; // 現在地のy座標

    private int CreateLimit { get; set; }  //これ以上は通路が作れなくなることを示す値

    private int CreatedPassageCount { get; set; } = 0; //通路を生成した回数

    private Stack<int> PreLocationX { get; set; } //過去に選択した位置のx座標

    private Stack<int> PreLocationY { get; set; } //過去に選択した位置のy座標

    enum Dir //掘る向き
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3,
    }

    void Start()
    {
        Init();
        CreateMaze();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Init()
    {
        Assert.IsTrue(mazeSideSize >= 5 && mazeSideSize % 2 == 1, "5以上の奇数を設定してください");
        EntireMazeSideSize = mazeSideSize + 2;
        Maze = new int[EntireMazeSideSize, EntireMazeSideSize];
        CreateLimit = ((mazeSideSize + 1) / 2) * ((mazeSideSize + 1) / 2) - 1; //メソッドの終了条件。

        PreLocationX = new Stack<int>();
        PreLocationY = new Stack<int>();
    }

    /// <summary>
    /// マップを作る。
    /// </summary>
    void CreateMaze()
    {
        //初期地決め
        CurrentX = Random.Range(0, (mazeSideSize + 1) / 2) * 2;
        CurrentY = Random.Range(0, (mazeSideSize + 1) / 2) * 2;

        Maze[CurrentX + 1, CurrentY + 1] = 1;　//壁 = 0 通路 = 1
        DigWall(CurrentX + 1, CurrentY + 1);
        CreateMazeObject();
    }


    /// <summary>
    /// 壁を掘って通路にしていく
    /// </summary>
    /// <param name="x">迷路のx座標</param>
    /// <param name="y">迷路のy座標</param>
    void DigWall(int x, int y)
    {
        if (CreateLimit == CreatedPassageCount)
        {
            return;
        }

        int DigDir = ChoiceDigDir(x, y);

        //どの方向も掘れない場合前回の場所に戻ってやり直し
        if (DigDir == FailVal)
        {
            DigWall(PreLocationX.Pop(), PreLocationY.Pop());
            return;
        }

        Dig(DigDir, x, y);
        DigWall(CurrentX, CurrentY);
    }

    /// <summary>
    /// 掘る向きを決める
    /// </summary>
    /// <param name="x">迷路のx座標</param>
    /// <param name="y">迷路のy座標</param>
    /// <returns>掘る向きまたは失敗を表す値を返す</returns>
    int ChoiceDigDir(int x, int y)
    {
        var DigCandidacy = new List<int>();

        //マップから出ておらず、現在地から2マス先が壁である場合、掘る候補とする
        if (y - 2 >= 1 && Maze[x, y - 2] == 0) //上
        {
            DigCandidacy.Add((int)Dir.Up);
        }
        if (y + 2 < mazeSideSize + 1 && Maze[x, y + 2] == 0) //下
        {
            DigCandidacy.Add((int)Dir.Down);
        }
        if (x + 2 < mazeSideSize + 1 && Maze[x + 2, y] == 0) //右
        {
            DigCandidacy.Add((int)Dir.Right);
        }
        if (x - 2 >= 1 && Maze[x - 2, y] == 0) //左
        {
            DigCandidacy.Add((int)Dir.Left);
        }

        //どの方向も掘れない場合
        if (DigCandidacy.Count == 0)
        {
            return FailVal;
        }

        //候補の中からランダムで決める
        return DigCandidacy[Random.Range(0, DigCandidacy.Count)];
    }

    /// <summary>
    /// 壁を掘る
    /// </summary>
    /// <param name="DigDir">掘る向き</param>
    /// <param name="x">迷路のx座標</param>
    /// <param name="y">迷路のy座標</param>
    void Dig(int DigDir, int x, int y)
    {
        PreLocationX.Push(x);
        PreLocationY.Push(y);

        switch (DigDir)
        {
            case (int)Dir.Up:
                Maze[x, y - 1] = 1;
                Maze[x, y - 2] = 1;
                SetCurrentLocation(x, y - 2);
                break;

            case (int)Dir.Down:
                Maze[x, y + 1] = 1;
                Maze[x, y + 2] = 1;
                SetCurrentLocation(x, y + 2);
                break;

            case (int)Dir.Right:
                Maze[x + 1, y] = 1;
                Maze[x + 2, y] = 1;
                SetCurrentLocation(x + 2, y);
                break;

            case (int)Dir.Left:
                Maze[x - 1, y] = 1;
                Maze[x - 2, y] = 1;
                SetCurrentLocation(x - 2, y);
                break;
        }

        CreatedPassageCount++;
    }

    /// <summary>
    /// 現在地を設定する
    /// </summary>
    /// <param name="x">迷路のx座標</param>
    /// <param name="y">迷路のy座標</param>
    void SetCurrentLocation(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }


    /// <summary>
    /// 迷路のオブジェクトを生成する
    /// </summary>
    void CreateMazeObject()
    {
        for (var x = 0; x < EntireMazeSideSize; x++)
        {
            for (var y = 0; y < EntireMazeSideSize; y++)
            {
                if (Maze[x, y] == 0)
                {
                    ExecInstantiate(wall, x, y);
                }
                else
                {
                    ExecInstantiate(floor, x, y);
                }
            }
        }
    }

    void ExecInstantiate(GameObject MazeObject, int x, int y)
    {
        Instantiate(MazeObject, new Vector3(x, 0, y), Quaternion.identity);
    }
}


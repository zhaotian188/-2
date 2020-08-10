using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//场景头部引入

public class GameManager : MonoBehaviour
{
    public GameObject JMC;//界面
    public float time;
    public float TMnumber;//题目数量
    public float DTMnumber;//当前题目数量
    private bool IStime = false;
    public Sprite musicT;//开起音乐图标
    public Sprite musicF;//关闭音乐图标
    public int a=22212;//上一题的编号

    private void Start()
    {//初始化
        DTMnumber = 0;
        time = 0;
    }
    private void Update()
    {
        if (IStime)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                JMC.transform.GetChild(1).gameObject.SetActive(false);//关闭选择页面
                JMC.transform.GetChild(2).gameObject.SetActive(true);//打开页面
                                                                     // JMC.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Image>().fillAmount = 0;
                JMC.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Image>().fillAmount += (float)0.3 * Time.deltaTime;
                if (JMC.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Image>().fillAmount >= 1)
                {
                    //进入答题，关闭计时
                    IStime = false;
                    JMC.transform.GetChild(2).gameObject.SetActive(false);//关掉加载页面
                    JMC.transform.GetChild(3).gameObject.SetActive(true);//开起答题检测
                    TiMu();//题目  赋值
                }
            }
        }
    }


    /// <summary>
    /// 开始游戏按钮
    /// 作用：关闭首页，打开选择页面，延时五秒后进入加载页
    /// </summary>
    public void StartGame()
    {
        JMC.transform.GetChild(0).gameObject.SetActive(false);//关闭首页
        JMC.transform.GetChild(2).gameObject.SetActive(false);//
        JMC.transform.GetChild(3).gameObject.SetActive(false);//
        JMC.transform.GetChild(4).gameObject.SetActive(false);//
        JMC.transform.GetChild(5).gameObject.SetActive(false);//
        JMC.transform.GetChild(1).gameObject.SetActive(true);//打开选择页面
        IStime = true;
        DTMnumber += 1;
        JMC.transform.GetChild(2).GetChild(1).gameObject.GetComponent<Image>().fillAmount = 0;
    }
    /// <summary>
    /// 答题赋值函数
    /// 
    /// 格式  编号@类型@答案@题目
    /// 
    /// 编号：题目编号
    /// 类型1选择题，2判断题，3简答题
    /// 选择答案ABCD对应1234
    /// 判断答案TF丢应对错
    /// 题目
    /// 
    /// </summary>
    public void TiMu()
    {

        string message = "1@1@B@全班学生排成一行，从左数和右数小明都是第15名，问全班共有学生多少人（   ）\n A、15   B、29   C、30  D、31; " +
            "2@1@D@有一组数为： 1.5   3    6   12  __    __ \n  按数据规律横线处填（  ）\nA、24   36  B、6   4  C、8   8  D、24   48;" +
            "3@1@D@如果‘CONT’被写作‘TNOC’，用这种方式写‘POPU’时从左边数第二个字母是什么？（ ）\nA、R  B、I   C、L  D、P;" +
            "4@3@ @一个人花8块钱买了一只鸡，9块钱卖掉，然后他觉得不划算，花10块钱又买回来了,11块卖给另外一个人。问他赚了多少？;" +
            "5@3@ @有一栋9层楼，每一层的电梯口都放置了一块钻石，每块钻石的大小各不相同，电梯在每一楼都会开一次门，每次只能拿一颗,请问用什么方法可以得到最大的那块钻石？;" +
            "6@3@ @哥哥有4包辣条，姐姐有3包辣条，弟弟有6包辣条，哥哥给弟弟1包辣条后，弟弟吃了3包辣条，最后谁的辣条最多？;" +
            "7@3@ @小明家距离学校有2千米，有一次去上学，已经走了1千米时，突然想起作业忘带了，他又折回去拿上作业再赶去学校，请问这次上学他一共走了多少千米？;" +
            "8@3@ @有三位同学，分别是 甲 乙 丙  ，甲要比乙高 ， 乙要比丙矮 ，丙要比甲高，请问三位同学中，谁最高，谁最矮？";
        string[] v = message.Split(';');//分割每道题   
        int i = (int)Random.Range(0, TMnumber);
       
            if (v[i] != null)//判断是否为空
            {
                string[] v1 = v[i].Split('@');//分割编号，类型，答案，题目
                JMC.transform.GetChild(3).GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = v1[3];
            //显示题号
              Debug.Log("" + v1[0]);
            //避免两道题重复
              if (a == int.Parse(v1[0])) TiMu();
              a = int.Parse(v1[0]);
                if (v1[1] == "1")//选择题
                { 
                JMC.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);  
                JMC.transform.GetChild(3).GetChild(4).gameObject.SetActive(false); 
                JMC.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);
                    JMC.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听   
                    JMC.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听   
                    JMC.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听   
                    JMC.transform.GetChild(3).GetChild(3).GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听   
                    if (v1[2] == "A")
                    {
                        JMC.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                    }
                    if (v1[2] == "B")
                    {
                        JMC.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                    }
                    if (v1[2] == "C")
                    {
                        JMC.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                    }
                    if (v1[2] == "D")
                    {
                        JMC.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                        JMC.transform.GetChild(3).GetChild(3).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                    }

                }
                if (v1[1] == "2")//判断题
                { 
                 JMC.transform.GetChild(3).GetChild(4).gameObject.SetActive(true); 
                 JMC.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                 JMC.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);
                    if (v1[2] == "F")
                    {
                        JMC.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                        JMC.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                    }
                    if (v1[2] == "T")
                    {
                        JMC.transform.GetChild(3).GetChild(4).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                        JMC.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { F(); });
                    }
                }if (v1[1] == "3")//简答题
                { 
                    JMC.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
                    JMC.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                    JMC.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                        JMC.transform.GetChild(3).GetChild(5).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { T(); });
                }
            }
        

       



    }
    public void T()//答对了
    {
        JMC.transform.GetChild(3).gameObject.SetActive(false);//关闭答题检测
        JMC.transform.GetChild(4).gameObject.SetActive(true);//开起胜利页
        JMC.transform.GetChild(3).GetChild(1).GetChild(0).gameObject.SetActive(false);//关闭提示

        if (DTMnumber == 2)
        {
            //给出评分，结束页面
            JMC.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = "恭喜！闯关成功\n 游戏结束";
            JMC.transform.GetChild(4).GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听   
            JMC.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
            JMC.transform.GetChild(4).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });//重载当前场景
        }
    }
    public void F()//答错了，开起提示
    {
        JMC.transform.GetChild(3).GetChild(1).GetChild(0).gameObject.SetActive(true);
    }
    public void G()//关闭提示
    {
        JMC.transform.GetChild(3).GetChild(1).GetChild(0).gameObject.SetActive(false);
    }
    public void Gameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//重载当前场景
    }
   public void  GameOver() {
        Application.Quit();
    }


    public void openmusic() {
        GetComponent<AudioSource>().enabled = true;
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = musicT;
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Image>().sprite = musicT;      
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听  
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { overmusic(); });
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听  
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Button>().onClick.AddListener(delegate () { overmusic(); });
    }//开起音乐
    public void overmusic() {
        GetComponent<AudioSource>().enabled = false;
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = musicF;
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Image>().sprite = musicF;
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听  
        JMC.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { openmusic(); });
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Button>().onClick.RemoveAllListeners();//移除所有监听  
        JMC.transform.GetChild(3).GetChild(6).GetComponent<Button>().onClick.AddListener(delegate () { openmusic(); });
    }//关闭音乐
}                                         

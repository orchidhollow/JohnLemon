using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //todo:
    //1.判断用户角色是否进入结束区域，如果进入，触发游戏结束的相关操作
    //2.书写游戏结束逻辑
    //  2.1 调用结束UI，展示胜利画面（通过更改UI的透明度实现）
    //  2.2 设置计时器，到指定时间，退出游戏
    // Start is called before the first frame update
    bool m_IsPlayerAtExit;
    public GameObject player;

    //更改透明度的时间
    public float fadeDuration = 1;
    //计时器
    float m_Timer;
    //完全显示结束UI的时间
    public float displayImageDuration = 1;
    //声明一个CanvasGroup,用来获取UI中的实例，来更改UI图片的透明度
    public CanvasGroup ExitGameImage;
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }
    //触发器事件
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            m_IsPlayerAtExit= true;
        }
    }
    //结束关卡
    void EndLevel()
    {
        //触发结束时开始计时
        m_Timer += Time.deltaTime;
        //透明度随时间增大而增大，与fadeDuration相等时完全显示
        ExitGameImage.alpha=m_Timer/fadeDuration;
        //当完全显示UI后等待displayImageDuration时长后结束游戏
        if(m_Timer>fadeDuration+displayImageDuration) 
        {
            //退出当前应用程序，打包成发布时才嗯那个生效
            //Application.Quit();
            //在Unity编译器中，停止游戏的运行
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }
}

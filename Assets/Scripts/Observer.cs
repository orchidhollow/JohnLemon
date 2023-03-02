using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //当玩家进入监视范围内时触发游戏失败

    public Transform player;
    //代表玩家是否被视线扫到
    bool m_IsPlayerInRange;
    //引用gameEnding中的公用方法函数
    public GameEnding gameEnding;

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            //设置投射射线用到的方向矢量
            Vector3 direction = player.position - transform.position + Vector3.up;//(0,1,0)看到角色质心
            //创建射线
            Ray ray = new Ray(transform.position, direction);
            //射线击中对象，包含射线碰撞信息
            RaycastHit raycastHit;
            //使用物理系统发射射线
            //out代表第二个参数时输出参数，可以带出数据到参数中
            if(Physics.Raycast(ray, out raycastHit) )
            {
                if(raycastHit.collider.transform==player)
                {
                    gameEnding.CaughtPlayer();
                }
            }

        }
    }

    //进入触发器事件
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange= true;
        }
    }
    //离开触发器事件
    private void OnTriggerExit(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange= false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //设置NavMeshAgent 组件对象，来获取当前游戏的导航网格代理组件
    private NavMeshAgent navMeshAgent;
    //路径点数组
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
        //设置导航组件的导航起始点位
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // 每次刷新，都获取下一个路径点
    //如果满足要求，指定下一个路径点
    //并通过算法让路径点位循环
    void Update()
    {
        //当前游戏对象到指定的路径点的距离小于停止距离 
        if(navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex=(m_CurrentWaypointIndex+1)%waypoints.Length;
            //navMeshAgent.SetDestination方法，可以设置移动的目标位置，参数是一个Vector3
            //设置新的导航位置
            //在游戏场景中，通过空的游戏对象，来表示每个导航点
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}

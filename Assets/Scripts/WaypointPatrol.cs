using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //����NavMeshAgent �����������ȡ��ǰ��Ϸ�ĵ�������������
    private NavMeshAgent navMeshAgent;
    //·��������
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
        //���õ�������ĵ�����ʼ��λ
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // ÿ��ˢ�£�����ȡ��һ��·����
    //�������Ҫ��ָ����һ��·����
    //��ͨ���㷨��·����λѭ��
    void Update()
    {
        //��ǰ��Ϸ����ָ����·����ľ���С��ֹͣ���� 
        if(navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex=(m_CurrentWaypointIndex+1)%waypoints.Length;
            //navMeshAgent.SetDestination���������������ƶ���Ŀ��λ�ã�������һ��Vector3
            //�����µĵ���λ��
            //����Ϸ�����У�ͨ���յ���Ϸ��������ʾÿ��������
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}

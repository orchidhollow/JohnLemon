using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //����ҽ�����ӷ�Χ��ʱ������Ϸʧ��

    public Transform player;
    //��������Ƿ�����ɨ��
    bool m_IsPlayerInRange;
    //����gameEnding�еĹ��÷�������
    public GameEnding gameEnding;

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            //����Ͷ�������õ��ķ���ʸ��
            Vector3 direction = player.position - transform.position + Vector3.up;//(0,1,0)������ɫ����
            //��������
            Ray ray = new Ray(transform.position, direction);
            //���߻��ж��󣬰���������ײ��Ϣ
            RaycastHit raycastHit;
            //ʹ������ϵͳ��������
            //out����ڶ�������ʱ������������Դ������ݵ�������
            if(Physics.Raycast(ray, out raycastHit) )
            {
                if(raycastHit.collider.transform==player)
                {
                    gameEnding.CaughtPlayer();
                }
            }

        }
    }

    //���봥�����¼�
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange= true;
        }
    }
    //�뿪�������¼�
    private void OnTriggerExit(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange= false;
        }
    }

}

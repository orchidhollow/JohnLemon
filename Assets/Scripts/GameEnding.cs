using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //todo:
    //1.�ж��û���ɫ�Ƿ�����������������룬������Ϸ��������ز���
    //2.��д��Ϸ�����߼�
    //  2.1 ���ý���UI��չʾʤ�����棨ͨ������UI��͸����ʵ�֣�
    //  2.2 ���ü�ʱ������ָ��ʱ�䣬�˳���Ϸ
    // Start is called before the first frame update
    bool m_IsPlayerAtExit;
    public GameObject player;

    //����͸���ȵ�ʱ��
    public float fadeDuration = 1;
    //��ʱ��
    float m_Timer;
    //��ȫ��ʾ����UI��ʱ��
    public float displayImageDuration = 1;
    //����һ��CanvasGroup,������ȡUI�е�ʵ����������UIͼƬ��͸����
    public CanvasGroup ExitGameImage;
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }
    //�������¼�
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            m_IsPlayerAtExit= true;
        }
    }
    //�����ؿ�
    void EndLevel()
    {
        //��������ʱ��ʼ��ʱ
        m_Timer += Time.deltaTime;
        //͸������ʱ�������������fadeDuration���ʱ��ȫ��ʾ
        ExitGameImage.alpha=m_Timer/fadeDuration;
        //����ȫ��ʾUI��ȴ�displayImageDurationʱ���������Ϸ
        if(m_Timer>fadeDuration+displayImageDuration) 
        {
            //�˳���ǰӦ�ó��򣬴���ɷ���ʱ�����Ǹ���Ч
            //Application.Quit();
            //��Unity�������У�ֹͣ��Ϸ������
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }
}

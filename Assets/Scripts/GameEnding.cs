using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public CanvasGroup CaughtGameImage;
    bool m_IsPlayerCaught;
    //��������Դ����
    public AudioSource exitAudio;//ʤ��
    public AudioSource caughtAudio;//ʧ��
    bool m_HasAudioPlayed;
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(ExitGameImage,false,exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(CaughtGameImage,true,caughtAudio);
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught= true;
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
    //����1ΪUIͼƬ
    //����2Ϊ�Ƿ����¿�ʼ
    void EndLevel(CanvasGroup image,bool doRestart,AudioSource audioSource)
    {
        //���û�в��Ź�
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed= true;
        }
        //��������ʱ��ʼ��ʱ
        m_Timer += Time.deltaTime;
        //͸������ʱ�������������fadeDuration���ʱ��ȫ��ʾ
        image.alpha=m_Timer/fadeDuration;
        //����ȫ��ʾUI��ȴ�displayImageDurationʱ���������Ϸ
        if (m_Timer > fadeDuration + displayImageDuration)
        {

            if (doRestart)
            {
                //������SceneManager
                SceneManager.LoadScene(0);
            }
            else
            {
                //�˳���ǰӦ�ó��򣬴���ɷ���ʱ�����Ǹ���Ч
                //Application.Quit();
                //��Unity�������У�ֹͣ��Ϸ������
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        
    }
}

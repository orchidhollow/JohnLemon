using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //TODO
    //1.�ƶ�
    //2.ת��
    //3.����

    //����һ��3dʸ������ʾ��ɫ�ƶ�
    Vector3 m_Movement;
    //������������ȡ�û����뷽��
    float horizontal;
    float vertical;

    //����һ���������
    Rigidbody m_Rigidbody;
    //����һ��Animator�������
    Animator m_Animator;
    void Start()
    {
        //����Ϸ��ʼʱ����ȡ��������Ͷ������
        m_Animator= GetComponent<Animator>();
        m_Rigidbody= GetComponent<Rigidbody>();
    }

    void Update()
    {
        //��ȡ�û�����
        horizontal=Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        //���û�������װΪ3D�˶���Ҫ����άʸ��
        m_Movement.Set(horizontal,0.0f,vertical);
        m_Movement.Normalize();

        //���ж��Ƿ��к����ƶ�
        bool hasHorizontal = !Mathf.Approximately(horizontal,0);//�Ƚ���������ֵ������������ƣ��򷵻� true
        bool hasVertical = !Mathf.Approximately(vertical,0);
        //ֻҪ��һ�������ƶ�������Ϊ�����ƶ�״̬
        bool isWalking = hasHorizontal || hasVertical;
        //���������ݸ�����������
        m_Animator.SetBool("IsWalking", isWalking);
    }
    private void OnAnimatorMove()
    {
        //ʹ�ô��û������ȡ������άʸ����Ϊ�ƶ�����ʹ�ö�����ÿ��0.02s�ƶ��ľ�����Ϊ�������ƶ�
        m_Rigidbody.MovePosition(m_Rigidbody.position+m_Movement*m_Animator.deltaPosition.magnitude);//magnitude���ظ������ĳ��ȡ���ֻ����
        //m_Animator.deltaPosition��ȡ��һ���Ѽ���֡�Ļ���λ���������������� Animator.applyRootMotion ���ܼ��� deltaPosition��
    }
}

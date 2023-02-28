using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //TODO
    //1.移动
    //2.转向
    //3.动画

    //创建一个3d矢量，表示角色移动
    Vector3 m_Movement;
    //创建变量，获取用户输入方向
    float horizontal;
    float vertical;

    //创建一个刚体对象
    Rigidbody m_Rigidbody;
    //创建一个Animator组件对象
    Animator m_Animator;

    //用四元数对象m_Rotation 来表示3D游戏中的旋转
    //初始化四元数对象，初始化为不旋转
    Quaternion m_Rotation = Quaternion.identity;
    //旋转速度
    public float turnSpeed = 20;

    void Start()
    {
        //在游戏开始时，获取刚体组件和动画组件
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //获取用户输入
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        //将用户输入组装为3D运动需要的三维矢量
        m_Movement.Set(horizontal, 0.0f, vertical);
        m_Movement.Normalize();

        //先判断是否有横向移动
        bool hasHorizontal = !Mathf.Approximately(horizontal, 0);//比较两个浮点值，如果它们相似，则返回 true
        bool hasVertical = !Mathf.Approximately(vertical, 0);
        //只要有一个方向移动，就认为处于移动状态
        bool isWalking = hasHorizontal || hasVertical;
        //将变量传递给动画管理器
        m_Animator.SetBool("IsWalking", isWalking);

        //用三维矢量来表示转向后的角色方向
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,m_Movement,turnSpeed*Time.deltaTime,0f);//初始向量，目标向量，变化角度
        //设置四元数对象的值
        m_Rotation=Quaternion.LookRotation(desiredForward);//
    }

    //当动画播放引发根移动时执行
    private void OnAnimatorMove()
    {
        //使用从用户输入获取到的三维矢量作为移动方向，使用动画中每次0.02s移动的距离作为距离来移动
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);//magnitude返回该向量的长度。（只读）
        //m_Animator.deltaPosition获取上一个已计算帧的化身位置增量。必须启用 Animator.applyRootMotion 才能计算 deltaPosition。

        //旋转游戏对象
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}

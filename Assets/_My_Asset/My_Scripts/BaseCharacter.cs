using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> compenents;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] private float smothTime;
    [SerializeField] protected float distanceStop;
    public float SmothTime { get => smothTime; }
    public float rotateVelocity;
    public bool isAttack;

    [Header("Stats")]
    [SerializeField] private float dame;
    [SerializeField] protected float attackSpeed;
    protected float interval;
    protected float lastAttack;
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public float Dame { get => dame; set => dame = value; }
    public List<MonoBehaviour> Compenents { get => compenents;}

    protected string animName = ConstString.defaultAttack;
    private void Start()
    {
        interval = 60f / attackSpeed;
    }
    private void Update()
    {
        UpdateSlash();
    }
    public void ChangeAnim(string animChange)
    {
        if (animChange != animName)
        {
            anim.ResetTrigger(animName);
            animName = animChange;
            anim.SetTrigger(animName);
        }
        else if (animChange == animName)
        {
            anim.SetTrigger(animName);
        }
    }
    public void MoveAnim(string nameAnim, float speed, float smoothTime)
    {
        anim.SetFloat(nameAnim, speed, smoothTime, Time.deltaTime);
    }
    public void ChangeAnimBool(string name, bool status)
    {
        anim.SetBool(name, status);
    }
    public virtual void MoveToPoint(Vector3 point)
    {
        Agent.SetDestination(point);
        RotatePlayer(point);
    }
    public virtual void MoveToEnemy(Vector3 enemy)
    {
        
    }
    public virtual void RotatePlayer(Vector3 hit)
    {
        Quaternion rotateLookAt = Quaternion.LookRotation(hit - transform.position);
        float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            rotateLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeed * (Time.deltaTime * 5));
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }

    protected bool UpdateSlash()
    {
        if (Time.time - lastAttack >= interval)
        {
            lastAttack = Time.time;
            return true;
        }
            return false;
    }
    protected virtual float CheckSpeed()
    {
        float speed = Agent.velocity.magnitude / Agent.speed;
        return speed;
    }
}

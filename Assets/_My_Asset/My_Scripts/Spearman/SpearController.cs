using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpearController : BaseCharacter
{
    [SerializeField] protected Istate<SpearController> currentState;
    [SerializeField] private Health characterHealth;
    [SerializeField] protected float radius;
    [SerializeField] private Transform player;
    [SerializeField] private VisionDetective vision;
    public float timeCount;
    public AudioSource spearHit;
    public GameObject healthBar;
    public Collider coliider;
    private Vector3 randomDirection;
    protected bool isFocus;
    public bool isMoving;
    public Health CharacterHealth { get => characterHealth;}
    public VisionDetective Vision { get => vision;}
    public Transform Player { get => player; set => player = value; }

    public float SpeedMove() => CheckSpeed();
    public float SmoothTime() => SmothTime; 
    private void Start()
    {
        MoveRandom();
        ChangeState(new SpearIdleState());
    }
    protected void MoveToEnemy()
    {
        if (vision.isDetected && !characterHealth.dead)
        {
            Player = GameObject.FindGameObjectWithTag(ConstString.playerTag).transform;
            MoveToPoint(Player.position);
            Agent.stoppingDistance = distanceStop;
            RotatePlayer(Player.position);
            isMoving = true;
        }
        if (!vision.isDetected)
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                MoveRandom();
                timeCount = 3f;
            }
            Agent.stoppingDistance = 0f;
            isMoving = true;
        }
    }
    protected void AttackCondition()
    {
        if (player != null && !isAttack)
        {
            float remainDistance = Vector3.Distance(transform.position, player.position);
            if (remainDistance <= Agent.stoppingDistance)
            {
                isAttack = true;
                isMoving = false;
            }
        }
    }
    private void MoveRandom()
    {
        Vector3 randomPoint = RandomNavmeshLocation(10f);
        MoveToPoint(randomPoint);
        RotatePlayer(randomDirection);
    }
    //Tính vị trí random trong vòng tròn với radius khai báo từ vị trí  trung tâm spearman
    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            return hit.position; 
        }
        return transform.position; 
    }
    public void ChangeState(Istate<SpearController> newState)
    {
        if(currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    protected void StateControl()
    {
        if (currentState != null)
        {
            currentState.OnExercute(this);
        }
    }
    private void Update()
    {
        StateControl();
        MoveToEnemy();
        AttackCondition();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
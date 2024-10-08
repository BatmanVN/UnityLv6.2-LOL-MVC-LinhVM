using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : BaseCharacter
{
    [SerializeField] protected Istate<SpearController> currentState;
    [SerializeField] private Health characterHealth;
    [SerializeField] protected float radius;
    [SerializeField] private Transform player;
    [SerializeField] private VisionDetective vision;
    public GameObject healthBar;
    public Collider coliider;
    private Vector3 firstPoint;
    protected bool isFocus;
    public bool isMoving;
    public Health CharacterHealth { get => characterHealth;}
    public VisionDetective Vision { get => vision;}
    public Transform Player { get => player; set => player = value; }

    public float SpeedMove() => CheckSpeed();
    public float SmoothTime() => SmothTime;
    private void Start()
    {
        firstPoint = transform.position;
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
            Player = null;
            MoveToPoint(firstPoint);
            Agent.stoppingDistance = 0f;
            RotatePlayer(firstPoint);
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
}
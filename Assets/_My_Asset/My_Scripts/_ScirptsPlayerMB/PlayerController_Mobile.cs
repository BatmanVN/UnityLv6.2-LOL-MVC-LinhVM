using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Mobile : BaseCharacter
{
    [SerializeField] protected VariableJoystick joystick;
    [SerializeField] private SetOutlineManager_Mobile outlineManager;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Health charaterHealth;
    [SerializeField] private float qualifiedDistance;
    [SerializeField] private float minDistance;
    [SerializeField] private DFAttack dfAttack;
    [SerializeField] private SkillAttack_mobile skillattack;
    [SerializeField] private float speedMove;
    [SerializeField] private float healAmount;
    [SerializeField] private Transform target;
    public GameObject BlessGod;
    public GameObject BonusDame;
    public GameObject fireSkill;
    private Coroutine coroutine;
    public bool isUseJoy;
    public bool isMoving;

    public float HealAmount { get => healAmount; }
    public Health CharaterHealth { get => charaterHealth; }
    public Transform Target { get => target; set => target = value; }
    public float QualifiedDistance { get => qualifiedDistance; }
    public float MinDistance { get => minDistance; }

    private void OnValidate() => characterController = GetComponent<CharacterController>();
    private void Start()
    {
        
    }
    private void Update()
    {
        MoveWithJoy();
        CheckEnemy();
        AttackEnemy();
        CheckLive();
    }
    protected void MoveWithJoy()
    {
        float hInput = joystick.Horizontal;
        float vInput = joystick.Vertical;
        Vector3 direction = new Vector3(hInput, 0, vInput);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0f;

        float moveAnim = characterController.velocity.magnitude;
        characterController.SimpleMove(direction * speedMove);
        if (characterController.velocity != Vector3.zero)
        {
            Quaternion targetRotate = Quaternion.LookRotation(characterController.velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, rotateSpeed * Time.deltaTime);
            MoveAnim(ConstString.moveParaname, moveAnim, SmothTime);
            isUseJoy = true;
            isMoving = true;
        }
        if (moveAnim <= 0.1f)
        {
            MoveAnim(ConstString.moveParaname, 0f, SmothTime);
            isMoving = false;
        }
    }
    protected void CheckEnemy()
    {
        var listEnemy = SpearManager.Instance.SpearMan;
        for (int i = 0; i < listEnemy.Count; i++)
        {
            float distanceTarget = Vector3.Distance(transform.position, listEnemy[i].transform.position);
            if (distanceTarget <= QualifiedDistance && !listEnemy[i].CharacterHealth.dead)
            {
                outlineManager.SelectTarget();
                target = listEnemy[i].transform;
                break;
            }
            else
            {
                outlineManager.DeSelectTarget();
                target = null;
            }
        }
    }
    protected void AttackEnemy()
    {
        if (target != null)
        {
            float attackDistance = Vector3.Distance(transform.position, target.transform.position);
            if (attackDistance <= minDistance && !isMoving)
            {
                RotatePlayer(target.transform.position);
                isAttack = true;
            }
            if (isMoving || target.GetComponent<Health>().dead)
            {
                isAttack = false;
            }
        }
    }
    protected void CheckLive()
    {
        if (charaterHealth.dead)
        {
            ChangeAnim(ConstString.dieParaname);
            coroutine = StartCoroutine(EnableLoseBar());
            foreach (var component in Compenents)
            {
                component.enabled = false;
            }
        }
        if (!charaterHealth.dead && charaterHealth.beAttack && !isMoving && !SkillAttack_mobile.Instance.isCastSkill)
        {
            ChangeAnim(ConstString.hitParaname);
            charaterHealth.beAttack = false;
        }
    }
   private IEnumerator EnableLoseBar()
    {
        yield return new WaitForSeconds(3f);
        UiManager.Instance.UiGames[1].SetActive(true);
        StopCoroutine(coroutine);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, QualifiedDistance);

    }
}

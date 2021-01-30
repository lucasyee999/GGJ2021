using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agenter { get { return _agent; } }

    [Header("Idle")]
    public float MinIdleTime;
    public float MaxIdleTime;
    private Vector2 _startingTransform;

    [Header("Patrol")]
    public Transform[] PatrolPoints;
    public float PatrolMovementSpeed = 5f;
    [HideInInspector] public float ActualPatrolSpeed;

    [Header("Chase")]
    public float ChaseMovementSpeed = 5f;
    [HideInInspector] public float ActualChaseSpeed;

    public Transform enemySpriteTransform;

    private NavMeshAgent _agent;
    public Transform Target;
    [HideInInspector] public PolygonCollider2D coneCollider;
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite SideSprite;

    public StateMachine stateMachine = new StateMachine();

    public bool TestTarget = false;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _startingTransform = transform.position;

    }

    private void Start()
    {
        ActualChaseSpeed = PatrolMovementSpeed;
        ActualPatrolSpeed = ChaseMovementSpeed;

        if (!TestTarget)
        {
            stateMachine.ChangeState(new EnemyIdleState(this));
        }
    }

    private void Update()
    {
        if(!TestTarget)
        {
            stateMachine.Update();
        }
        else
        {
            //MoveTowards(Target, ChaseMovementSpeed);
        }
    }

    public void MoveTowards(Transform target, float speed)
    {
        Target = target;
        _agent.SetDestination(Target.position);
        _agent.speed = speed;

        if (Vector2.Distance(transform.position, target.transform.position) > 1.5f)
        {
            Vector2 direction = ((Vector2)target.transform.position - (Vector2)coneCollider.transform.position).normalized;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var offset = 90f;
            coneCollider.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }

        DirectionOfTarget(Target, transform);
    }

    public void OnEnter(Collider2D other)
    {
        stateMachine.ChangeState(new EnemyChaseState(this, other.transform));
    }

    public void OnExit(Collider2D other)
    {
        stateMachine.ChangeState(new EnemyPatrolState(this));
    }

    private void DirectionOfTarget(Transform target, Transform origin)
    {
        var directionVector = (target.transform.position - origin.transform.position).normalized;

        // target is right
        if(directionVector.y > 0.3f)
        {
            enemySpriteTransform.transform.localScale = new Vector2(5, 5);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = UpSprite;
        }
        
        else if(directionVector.y < -0.3f)
        {
            enemySpriteTransform.transform.localScale = new Vector2(5, 5);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = DownSprite;
        }

        else if(directionVector.x > 0)
        {
            enemySpriteTransform.transform.localScale = new Vector2(5, 5);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = SideSprite;

        }
        // target is left
        else if(directionVector.x < 0)
        {
            enemySpriteTransform.transform.localScale = new Vector2(-5, 5);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = SideSprite;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            UIManager.instance.OpenLoseView();
        }
    }


}

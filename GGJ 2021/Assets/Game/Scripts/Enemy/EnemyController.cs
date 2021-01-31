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

    private GameObject player;

    [SerializeField]
    private bool isStaticEnemy;


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
        this.player = GameObject.Find("Player");
        if (!TestTarget)
        {
            if (this.isStaticEnemy)
            {
                enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = SideSprite;
            }

            var initialState = this.isStaticEnemy ? new EnemyStaticState(this) as IState : new EnemyIdleState(this);
            stateMachine.ChangeState(initialState);
        }
    }

    private void Update()
    {
        if (!TestTarget)
        {
            stateMachine.Update(this.IsPlayerVisible(), GameManager.instance.found, this);
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
        if (directionVector.y > 0.3f)
        {
            enemySpriteTransform.transform.localScale = new Vector2(1, 1);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = UpSprite;
        }

        else if (directionVector.y < -0.3f)
        {
            enemySpriteTransform.transform.localScale = new Vector2(1, 1);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = DownSprite;
        }

        else if (directionVector.x > 0)
        {
            enemySpriteTransform.transform.localScale = new Vector2(-1, 1);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = SideSprite;

        }
        // target is left
        else if (directionVector.x < 0)
        {
            enemySpriteTransform.transform.localScale = new Vector2(1, 1);
            enemySpriteTransform.GetComponent<SpriteRenderer>().sprite = SideSprite;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            UIManager.instance.OpenLoseView();
        }
    }

    private bool IsPlayerVisible()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, this.player.transform.position - transform.position, 1000f, LayerMask.NameToLayer("NonDetection"));
        if (!hit)
        {
            return false;
        }
        return hit.collider.CompareTag("Player") || hit.collider.tag == "Player";
    }

    public void FlipSideways()
    {
        enemySpriteTransform.transform.localScale = new Vector2(-enemySpriteTransform.transform.localScale.x, 1);
    }
}

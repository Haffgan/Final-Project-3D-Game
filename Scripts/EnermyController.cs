using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnermyController : MonoBehaviour
{
    public float startSpeed = 10f;
    public float lookRadius = 5f;

    [HideInInspector]
    public float speed;

    Transform target;
    NavMeshAgent agent;
    private Animator anim;
    Transform destination;

    public float startHealth = 100;
    public float health;
    public int value = 2;
    public int crate = 2;
    PlayerHealth playerHealth;
    bool canAttack;

    [Header("Unity Stuff")]
    public Image healthBar;

    public float attackDamage = 3;
    //public float timeBetweenAttack = 0.5f;
    //public float autoAttackCooldown;
    //public float autoAttackCurTime;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        destination = GameObject.FindGameObjectWithTag("Finish").transform;
        speed = startSpeed;
        health = startHealth;
    }

    void Update()
    {
        agent.SetDestination(destination.position);
        anim.SetInteger("moving", 1);
        
        float finalDestination = Vector3.Distance(destination.position, transform.position);
        if (finalDestination <= 2f)
        {
            EndPath();
            return;
        }
        speed = startSpeed;
    }

    void LateUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 5)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
            if (canAttack && playerHealth.currentHealth > 0)
            {
                anim.SetInteger("battle", 1);
                Attack();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRadius = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRadius, Time.deltaTime * 5f);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if ( health <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Attacking hero");
        }
    }

    public void Slow (float Pct)
    {
        speed = startSpeed * (1f - Pct);
    }

    void Die()
    {
        PlayerManager.Money += value;
        PlayerManager.Crate += crate;
        anim.SetTrigger("isDead");
        WaveSpawner.EnemiesAlive--;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2f);
    }

    void EndPath()
    {
        PlayerManager.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void OnDrawGizonsSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


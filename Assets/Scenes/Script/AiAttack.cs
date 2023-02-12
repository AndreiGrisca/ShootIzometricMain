using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore;

public class AiAttack : MonoBehaviour
{
    [SerializeField] private Transform positionTarnasform;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform[] patrulPoint;
    [SerializeField] private Vector2 waitTame;
    [SerializeField] private int currentHealth;
    public HealthBar _healthBar;
    private float curentTime;
    private int _curentIndex;   
    private Vector3 target;
    private bool _waiting;
    private bool trigger;
    private Animator _animator;
    
    
    private void Awake()
    {
        
        enemy = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = 100;
        _waiting = true;
        DetectedPatroll();
        
    }

    private void Update()
    {
        _animator.SetFloat("SpeedEnemi", enemy.velocity.magnitude);
        PatrulingAi();
        if (trigger)
          { 
              ShootEnemi();
          }
       
    }
    private void PatrulingAi()
    {
        if (Vector3.Distance(transform.position, target) < 0.2f&&_waiting==false)
        {
           transform.LookAt(target); 
            enemy.speed = 0;
            _waiting = true;
            curentTime = Random.Range(waitTame.x, waitTame.y);
        }
        else if (_waiting)
        {
            Waiting();
        }
    }
    private void ShootEnemi()
        {
        
            if (enemy.remainingDistance<3)
            {
                transform.LookAt(positionTarnasform);
                enemy.speed = 0;
                _animator.SetBool("AttackEnemi", true);
            }
            else
            {
                enemy.speed = 1;
                _animator.SetBool("AttackEnemi", false);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemy.destination=positionTarnasform.position;
                trigger = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("start");
                trigger = false;
                DetectedPatroll();
            }
        }

        private void DetectedPatroll()
        {
            enemy.speed = 1;
            target = patrulPoint[_curentIndex].position;
            enemy.SetDestination(target);
        }

        private void Waiting()
        {
            curentTime -= Time.deltaTime;
            
            if (curentTime <= 0)
            {
                
                _curentIndex++;
                if (_curentIndex == patrulPoint.Length)
                {
                    _curentIndex = 0; 
                }
                DetectedPatroll();
                _waiting = false;
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            _healthBar.SetHealth(currentHealth); 
        }
        
}

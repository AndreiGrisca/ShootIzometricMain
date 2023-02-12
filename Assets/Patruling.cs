using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Patruling : StateMachineBehaviour
{
    private float timer;
    private List<Transform>point=new List<Transform>();
    private NavMeshAgent enemy;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer = 0;
        Transform pointObject = GameObject.FindGameObjectWithTag("Point").transform;
        foreach (Transform t in pointObject)
        {
            point.Add(t);
        }
        enemy.SetDestination(point[0].position);
        enemy = animator.GetComponent<NavMeshAgent>();
    }

 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.remainingDistance <= enemy.stoppingDistance)
        {
            enemy.SetDestination(point[Random.Range(0, point.Count)].position);
           
        }
 timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("IsPatruling",false);
        }
            
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.SetDestination(enemy.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

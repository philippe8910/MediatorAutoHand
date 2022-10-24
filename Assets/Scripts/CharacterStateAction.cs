using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Events;
using Project;
using Sirenix.OdinInspector;
using State;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterStateAction : MonoBehaviour
{
    [SerializeField] protected IState currentState = new IdleState();
    
    [FoldoutGroup("StateName")] public string walkState = "isWalking", idleState = "a_Idle" , runState = "isRunning" , jumpUpState = "isJump" , fallingState = "isFalling" , landingState = "isGrounding" , climbState = "isClimbing";

    [FoldoutGroup("TriggerValue")] [SerializeField] private float groundTriggerValue;

    [FoldoutGroup("TriggerValue")] [SerializeField] private float climbTriggerValue;

    [FoldoutGroup("TriggerValue")] [SerializeField] private LayerMask groundLayer;

    [FoldoutGroup("TriggerValue")] [SerializeField] private LayerMask climbLayer;

    [FoldoutGroup("TriggerValue")] [SerializeField] private Vector3 groundOffset;
    
    [FoldoutGroup("TriggerValue")] [SerializeField] private Vector3 climbOffset;

    [FoldoutGroup("WallCheckRayCast")] [SerializeField] private GameObject rightRay, leftRay;

    [FoldoutGroup("WallCheckRayCast")] [SerializeField] private float wallCheckRayDistance;

    private bool canClimb = true , isStop;

    private GameObject anchor = null;

    private Animator animator;

    private CharacterActor actor;

    private Vector2 inputVector2;

    public Volume stopTimeCameraEffect;

    private PlayerControllerAction playerControllerAction;
    void Start()
    {
        animator = GetComponent<Animator>();
        actor = GetComponent<CharacterActor>();
        playerControllerAction = GameObject.FindObjectOfType<PlayerControllerAction>();
        
        if(rightRay == null) rightRay = GameObject.Find("RightRay");
        if(leftRay == null) leftRay = GameObject.Find("LeftRay");
        if (stopTimeCameraEffect == null) FindObjectOfType<Volume>();
    }
    

    // Update is called once per frame
    void Update()
    {
        currentState.OnStayState(this);

        /*
         * if (playerControllerAction.GetDropdropDoppelgangerAction() && anchor == null)
        {
            Debug.Log("Press");
            
            var g = Resources.Load<GameObject>("Prefab/Jammo_Doppelganger");
            anchor = Instantiate(g, transform.position, transform.rotation);
        }
        else if (playerControllerAction.GetDropdropDoppelgangerAction() && anchor != null)
        {
            Debug.Log("Press2");

            transform.position = anchor.transform.position;
            Destroy(anchor);
        }
        
        if (playerControllerAction != null)
        {
            if (playerControllerAction.GetStopTimeAction())
            {
                isStop = !isStop;
                stopTimeCameraEffect.gameObject.SetActive(isStop);
                
                EventBus.Post(new StopTimeDetected(isStop));
                Debug.Log("StopTime");
            }
        }
         */
         

        //Debug.Log("Right : " + GetRightSideClimbWallCheck());
        //Debug.Log("Left : " + GetLeftSideClimbWallCheck());
        

        
    }

    public void SetAnimatorState(string nextState)
    {
        animator.Play(nextState);
    }

    public void SetAnimatorState(string stateName , bool stateAction)
    {
        animator.SetBool(stateName , stateAction);
    }
    
    public void SetAnimatorState(string stateName , float value)
    {
        animator.SetFloat(stateName , value);
    }

    public void ResetAnimatorState()
    {
        
    }

    public bool GetRightSideClimbWallCheck()
    {
        return Physics.Raycast(rightRay.transform.position, rightRay.transform.forward, wallCheckRayDistance , climbLayer);
    }
    
    public bool GetLeftSideClimbWallCheck()
    {
        return Physics.Raycast(leftRay.transform.position, leftRay.transform.forward, wallCheckRayDistance , climbLayer);
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExitState(this);
        newState.OnEnterState(this);
        currentState = newState;
    }

    public Vector2 GetInputVector2()
    {
        return playerControllerAction.GetInput();
    }

    public CharacterActor characterActor()
    {
        return actor;
    }

    public PlayerControllerAction ControllerAction()
    {
        return playerControllerAction;
    }

    public bool GetIsGround()
    {
        return Physics.CheckSphere(transform.position + groundOffset, groundTriggerValue , groundLayer);
    }

    public bool GetIsClimb()
    {
        return Physics.CheckSphere(transform.position + climbOffset, climbTriggerValue , climbLayer) && canClimb;
    }

    public async void DelayClimb()
    {
        canClimb = false;
        await Task.Delay(1000);
        canClimb = true;
    }

    public void SetCanClimb(bool value)
    {
        canClimb = value;
    }

    public GameObject GetClimbingObject()
    {
        var g = Physics.OverlapSphere(transform.position + climbOffset, climbTriggerValue, climbLayer);

        if (g.Length != 0)
        {
            return g[0].transform.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((1 << collision.gameObject.layer | groundLayer) == groundLayer)
        {
            //transform.SetParent(collision.transform);
            //Debug.Log("Ground");
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            //transform.SetParent(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            ChangeState(new DeadState());
            EventBus.Post(new ChangeLevelDetected(Dead, true));
        }
    }

    private void Dead()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Destroy(playerControllerAction.gameObject);
        EventBus.ClearAllAction();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + groundOffset , groundTriggerValue);
        Gizmos.DrawSphere(transform.position + climbOffset , climbTriggerValue);
        
        Gizmos.DrawRay(rightRay.transform.position,  rightRay.transform.forward);
        Gizmos.DrawRay(leftRay.transform.position,  leftRay.transform.forward);
    }
}

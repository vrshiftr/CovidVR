using UnityEngine;
using System.Collections;

public class homing : MonoBehaviour
{
    private Transform _transform;

    public Transform target; // object to follow
    public float speed = 1f; // missile speed

    public float angularThreshold = 0.05f; // how much the missile can turn
    public float angularThresholdRandomOffset = 0.01f; // random offset added to the missile turn value

    private float _angularThreshold = 0.05f;

    public float craziness = 0.2f; // how chaotic the path of the missile will be
    public float crazinessRandomOffset = 0.1f; // random offset added to the craziness value
    private float _craziness = 0.1f;

    public float crazinessFrequency = 0.05f; // how often the craziness will occur along the trajectory
    private float crazynessFreqElapsed = 0f;

    public float straightLaunchTime = 2f; // how long the missile is moving straight forward at launch (smoothly fading to seek path)
    public int lifeTime = 5; // how long the missile will live

    private Vector3 launchDirection;
    private float targetRadius = 3f;

    [HideInInspector]
    public Vector3 moveVector = Vector3.forward; // current moving vector of the missile

    [HideInInspector]
    public float age = 0f; // age of the missile

    public void Awake()
    {
        _transform = transform;
    }

   // public void Start()
   // {
       // Launch(_transform.position, _transform.forward, this.target);
  // }

    public void Launch(Vector3 startPosition, Vector3 startDirection, Transform targetToFollow, float missileSpeed = 10f)
    {

        // reset some variables

        _transform.position = startPosition;
        moveVector = startDirection;
        launchDirection = startDirection;
        _angularThreshold = angularThreshold + Random.Range(0, angularThresholdRandomOffset);
        _craziness = craziness + Random.Range(0, crazinessRandomOffset);
        crazynessFreqElapsed = 0f;
        age = 0f;

        speed = missileSpeed;
        target = targetToFollow;

        targetRadius = 3f;
        //guess target radius automatically
        

        // align the missile to it's starting direction
        _transform.forward = startDirection;

        // activate the gameObject to see the missile
        gameObject.SetActive(true);

        // activate this script
        this.enabled = true;
    }

    void Update()
    {

        float delta = Time.deltaTime;

        Vector3 direction;
        float distance = 1000;

        if (target == null)
        {
            // no target defined, the missile go straight forward
            direction.x = launchDirection.x;
            direction.y = launchDirection.y;
            direction.z = launchDirection.z;
        }
        else
        {
            if (_angularThreshold == 0)
            {
                direction.x = launchDirection.x;
                direction.y = launchDirection.y;
                direction.z = launchDirection.z;
            }
            else
            {
                direction = target.position - _transform.position;
            }
            distance = direction.sqrMagnitude;
        }

        crazynessFreqElapsed += delta;
        age += delta;

        // launch the missile straight forward, and gradually orient it to its target
        if (age < straightLaunchTime)
        {
            direction = direction * age / straightLaunchTime + launchDirection * (1f - age / straightLaunchTime);
        }

        // define the movement vector toward the target
        moveVector = (moveVector + direction * _angularThreshold * delta).normalized;

        // randomize trajectory
        if (_craziness != 0 && crazynessFreqElapsed >= crazinessFrequency)
        {
            moveVector += Random.insideUnitSphere * _craziness;
            crazynessFreqElapsed = 0f;
        }

        // align the missile to its path
        _transform.forward = moveVector.normalized;

        // move the missile
        if (age > 0) _transform.position += _transform.forward * speed * delta;

        // kill the missile if it's too old or have reached the target
        if (age > lifeTime || distance <= targetRadius) Kill();
    }

    public void Kill()
    {
        // disable the gameObject to hide the missile
        gameObject.SetActive(false);

        // disable this script to stop the Update() function
        enabled = false;
    }

    public bool ReadyForRecycle()
    {
        // return true if the missile is ready to be reused
        return age >= lifeTime;
    }
}
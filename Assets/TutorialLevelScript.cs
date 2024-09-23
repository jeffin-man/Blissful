using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEditor;

public class NewBehaviourScript : MonoBehaviour
{
    public PathCreator currentPath;
    public float speed;
    public float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;
    private Vector3 pathPosition;
    public float yposition;
    public Vector3 pathRotation;

    // Start is called before the first frame update
    void Start()
    {
        yposition = transform.position.y;
        if (currentPath != null)
        {
            currentPath.pathUpdated += OnPathChanged;
        }
    }

    // Update is called once per frame
    void OnPathChanged()
    {
        distanceTravelled = currentPath.path.GetClosestDistanceAlongPath(transform.position);
    }


    void Update()
    {
        float PlayerVerticalInput = Input.GetAxis("Vertical");
        float PlayerHorizontallInput = Input.GetAxis("Horizontal");

        distanceTravelled += PlayerHorizontallInput * speed * Time.deltaTime;

        pathPosition = currentPath.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

        yposition += PlayerVerticalInput * speed * Time.deltaTime;

        transform.position = new Vector3(pathPosition.x, yposition, pathPosition.z);


        pathRotation = currentPath.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;
        transform.eulerAngles = pathRotation;




    }
}

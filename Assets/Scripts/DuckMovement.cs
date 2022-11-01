using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    Camera cam;
    Collider floorCollider;
    RaycastHit hit;
    Ray ray;
    public bool isMoving = false;
    public List<Vector3> PositionHistory = new List<Vector3>();
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        floorCollider = GameObject.Find("Floor").GetComponent<Collider>();
    }
    private void Update()
    {

        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == floorCollider)
            {
                isMoving = true;
                Vector3 difference = transform.position - hit.point;
                //Store Position History
                if (difference.sqrMagnitude > 0.5f)
                {
                    PositionHistory.Insert(0, transform.position);
                    
                }
                Debug.Log(PositionHistory.Count);
                //Make the duck moves towards the mouse
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5);
                //Make the duck rotare towards the mouse
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
            else
            {
                isMoving = false;
            }
        }
        
    }
}

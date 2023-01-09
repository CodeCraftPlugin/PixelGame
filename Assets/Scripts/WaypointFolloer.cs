using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFolloer : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curuntwaypointindex = 0;
    [SerializeField]private float speed = 4f;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[curuntwaypointindex].transform.position,transform.position)<1f)
        {
            curuntwaypointindex++;
            if (curuntwaypointindex >= waypoints.Length)
            {
                curuntwaypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[curuntwaypointindex].transform.position, Time.deltaTime*speed);
    }
}

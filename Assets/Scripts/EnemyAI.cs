using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    // Our overall target (player)
    public Transform target;

    // Speed
    public float speed = 200f;
    // How close an enemy must be to a waypoint before moving on to the next one
    public float nextWaypointDistance = 3f;

    public float radius = 4f;

    // The current path we're folling
    Path path;
    // The current waypoint along the path that we're targeting
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    // Allow us to reference external classes and such
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Finds our objects and assigns them to variables
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .2f);
    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            // Our seeker is responsible for creating paths
            // Generates a path with a start point, end point,
            // and a function that will be called when the calculations are done
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ensures we have a path we can follow
        if (path == null) {
            return;
        }
        // Detects if we've hit the end of the path or not
        if (currentWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        }
        // Tells us that we're not at the end of the path yet
        else {
            reachedEndOfPath = false;
        }
        
        // Moves the enemy
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if ((target.position.x - transform.position.x) < radius && (target.position.x - transform.position.x) > -radius 
            && (target.position.y - transform.position.y) < radius && (target.position.y - transform.position.y) > -radius
        ) { 
            // Adds a force to the object
            rb.AddForce(force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }
    }
}

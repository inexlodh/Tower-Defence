using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Follow : MonoBehaviour {

    private int index = 1;
    private Vector3 velocity;

    public float speed = 0.06f;
    public bool dead = false;
    public List<GameObject> waypoints;
	// Use this for initialization
	void Start () {
        // UnityEngine.Debug.Log(waypoints.size);
        /*foreach (GameObject wp in waypoints)
        {
            Debug.Log(wp.transform.position.x);
        }*/

        velocity = new Vector3(0, 0, 0);
        this.transform.position = waypoints[0].transform.position;
        setDirection();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            passed();

            this.transform.position += velocity;
        }
	}

    void setDirection ()
    {
        Vector3 target = waypoints[index].transform.position;
        if (target.x != this.transform.position.x)
        {
            velocity = new Vector3(speed * Math.Sign(target.x - this.transform.position.x), 0, 0);
        }
        else if (target.z != this.transform.position.z)
        {
            velocity = new Vector3(0, 0, speed * Math.Sign(target.z - this.transform.position.z));
        }
    }
    void passed ()
    {
        Vector3 target = waypoints[index].transform.position;
        if (Vector3.Distance(this.transform.position, target) <= .1)
        {
            this.transform.position = target;
            index++;

            if (index >= waypoints.Count)
            {
                // reached its final point
                dead = true;
            }
            setDirection();
        }
    }
}

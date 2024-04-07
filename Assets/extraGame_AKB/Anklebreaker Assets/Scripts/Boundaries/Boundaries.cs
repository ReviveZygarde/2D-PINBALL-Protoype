using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private GameObject basket_ball;
    private Collider self_collider;

    public GameObject bound_one;
    public GameObject bound_two;

    private Vector3 origin;

    private Vector3 collider_center; //center of the volume of the collider
    private Vector3 collider_size, collider_min, collider_max;
    // Start is called before the first frame update
    void Start()
    {
        basket_ball = GameObject.FindGameObjectWithTag("basket_ball");
        origin = basket_ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Found_bounds();
    }

    void Found_bounds()
    {
        if(basket_ball.transform.position.x <  bound_one.transform.position.x || basket_ball.transform.position.x > bound_two.transform.position.x)
        {
            reset_basket_ball();
        }

        if (basket_ball.transform.position.z < bound_one.transform.position.z || basket_ball.transform.position.z > bound_two.transform.position.z)
        {
            reset_basket_ball();
        }
    }

    void reset_basket_ball()
    {
        //Debug.Log("the ball got out and now back to the start point (Brain said 'uh oh')");
        basket_ball.transform.position = origin;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public UnityEngine.AI.NavMeshAgent agent;
    public float maxdistance = 3;
    public GameObject Tony;
    private GameObject Game_Manager;
    private bool Movement_Over = false;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Game_Manager = GameObject.FindWithTag("Game_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Tony.GetComponent<Player_Character>().isyourturn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //if you click an enemy
                if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
                {
                    //checks if there's nothing in the way of the attack
                    if (!Physics.Linecast(Tony.transform.position, hit.transform.position, ~(1 << 8)))
                    {
                        //checks if the selected enemy is in range
                        if (Vector3.Distance(Tony.transform.position, hit.transform.position) < gameObject.GetComponent<Player_Character>().Range)
                        {
                            hit.transform.GetComponent<Enemy_Manager>().Current_Health -= Tony.GetComponent<Player_Character>().Damage;
                        }
                    }
                }
                else if (Physics.Raycast(ray, out hit))
                {
                    if (Vector3.Distance(agent.transform.position, hit.point) <= maxdistance)
                    {
                        agent.SetDestination(hit.point);
                        Debug.Log("Valid point");
                    }
                    else
                    {
                        Debug.Log("Invaild point");
                    }
                }                 
            }
        }
    }
}
    
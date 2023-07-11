using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System;
public class enemyfollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public  bool playerinrange;
    public float sightrange;
    public LayerMask whatisplayer;
    private Rigidbody rb;
    private Vector3 startpos;
    private double distance;
    public string str;
    public Text text;
    public Transform textobj;
    // Start is called before the first frame update
    void Start()
    {
        startpos=transform.position;
        //textobj.gameObject..SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player) //if player hasnt been caught yet and object hasnt been destroyed
        {
            float dpx=player.position.x;//calculating distance btw player and enemy
            float dpz=player.position.z;
            float dex=transform.position.x;
            float dez=transform.position.z;
            double dx=Math.Pow(dpx-dex,2);
            double dz=Math.Pow(dpz-dez,2);
            distance=Math.Sqrt(dx+dz);
            if (dpz<30){
                sightrange=40;
                enemy.speed=4;
                enemy.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
            }
            else if (dpz<45){
                sightrange=30;
                enemy.speed=3;
                enemy.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
            }
            else
            {
                sightrange=60;
                enemy.speed=5;
                enemy.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
            }
            //playerinrange=Physics.CheckSphere(player.position,sightrange,whatisplayer);
            rb=gameObject.GetComponent<Rigidbody>();
            if (distance<sightrange)
            {
                float ez=startpos.z;
                float pz=player.position.z;
                if(ez<20 && pz<30)
                    enemy.SetDestination(player.position);
                else if(ez<45 && pz>20 && pz<45)
                    enemy.SetDestination(player.position);
                else if (ez>40 && pz>40)
                    enemy.SetDestination(player.position);
                else
                    enemy.SetDestination(startpos);
            }
             
            else
            {
                enemy.SetDestination(startpos);
                //this.rb.velocity = Vector3.zero;
                //this.rb.angularVelocity = Vector3.zero;
            }
            if (player.position.z>66) //if player reached the exit, detroying the enemy's object
                //str="YOU WIN :)";
                //gameObject.active = true;
                Destroy(this.gameObject);
        }
        //else
        //    enemy.SetDestination(vector3(-1,enemy.position.y,-16));
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            //str="YOU LOSE :(";
            //textobj.gameObject.active = true;          
            Destroy(other.gameObject);
        }
    }
}

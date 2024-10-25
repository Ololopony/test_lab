using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject cloud;
    public float speed = 10f;
    public List<GameObject> villagers = new List<GameObject>();
    private int number = -1;
    private Vector3 posVillager;
    private Vector3 posCloud;
    private Vector3 posDist;
    private float dist;
    private bool floating = false;
    public ParticleSystem ps;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(number == 6)
            {
                number = 0;
            }
            else
            {
                number++;
            }            
        }
        if(number != -1)
        {
            posVillager = villagers[number].gameObject.GetComponent<Transform>().position;
            posCloud = cloud.GetComponent<Transform>().position;
            posDist = new Vector3(posVillager.x, posCloud.y, posVillager.z);

            cloud.GetComponent<Transform>().position = Vector3.MoveTowards(posCloud, posDist, speed * Time.deltaTime);

            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            floating = Vector3.Distance(posCloud, posDist) > 1f;

            if(floating)
            {
                ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
            
            if(!floating)
            {
                ps.Play(false);
            }
        }
    }
}

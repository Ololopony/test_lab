using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject rock;

    public GameObject fallingRock;

    private List<GameObject> rocks = new List<GameObject>();

    void Start()
    {
        rock.SetActive(false);
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GameObject newObject = Instantiate(fallingRock, new Vector3(56f + RandomNumber(), 39f + RandomNumber(), -47f + RandomNumber()), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
            rocks.Add(newObject);
            if(rocks.Count >= 5)
            {
                Destroy(rocks[0].gameObject);
                rocks.RemoveAt(0);
            }
        }   
    }
    private int RandomNumber()
    {
        return Random.Range(0, 10);
    }
}

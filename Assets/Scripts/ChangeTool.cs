using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    public List<GameObject> tools = new List<GameObject>();
    private List<GameObject> newTools = new List<GameObject>();
    public List<GameObject> toolsPrefabs = new List<GameObject>();
    public List<GameObject> villagersPalms = new List<GameObject>();
    private int number = -1;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(number == 3)
            {
                number = 0;
            }
            else
            {
                number++;
            }
            if(newTools.Count != 0)
            {
                foreach(GameObject newTool in newTools)
                {
                    Destroy(newTool);
                }
                newTools.Clear();
            }
            for(int i = 0; i < tools.Count; i++)
            {
                GameObject go = Instantiate(toolsPrefabs[number].gameObject, tools[i].gameObject.transform) as GameObject;
                go.transform.parent = villagersPalms[i].gameObject.transform;
                newTools.Add(go);
                tools[i].SetActive(false);
            }
        }
    }
}

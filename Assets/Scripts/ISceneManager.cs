using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneManager : MonoBehaviour
{
    public static ISceneManager instance;

    public GameObject player;
    public List<Transform> transitionSpawnPoints;

    public Animation transitionAnimation;

    [HideInInspector] public int currentScene;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }

    public void ChangeScene(int i)
    {
        if(i < transitionSpawnPoints.Count)
        {
            player.transform.position = transitionSpawnPoints[i].position;
        }
        currentScene = i;
        transitionAnimation.Play();
    }
}

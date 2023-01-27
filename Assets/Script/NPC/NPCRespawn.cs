using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCRespawn : MonoBehaviour
{
    [HideInInspector]
    public GameObject currentProblem;
    public GameObject NPCPrefab;
    private Transform characterPool;

    [HideInInspector]
    public ProblemWaypoint _pw;

    public List<GameObject> NPCSpawns;
    public List<Transform> spawnPoints;
    public List<GameObject> hearts;

    private int currentSpawnPoint;

    private void Start()
    {
        characterPool = GameObject.Find("CharacterPool").transform;

        for (int i = 0; i < 4; i++)
        {
            CharacterCreation(false, null);
        }
        
        _pw = GetComponent<ProblemWaypoint>();
        currentSpawnPoint = Random.Range(0, spawnPoints.Count);
        currentProblem = NPCSpawns[Random.Range(0, NPCSpawns.Count)];
        _pw.npc = currentProblem.transform;

        currentProblem.transform.position = new Vector2(spawnPoints[currentSpawnPoint].transform.position.x, spawnPoints[currentSpawnPoint].transform.position.y);
    }

    private void Update()
    {
        if(hearts.Count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    public void CharacterCreation(bool delete, GameObject charToDelete) //creates a new NPC and randomizes its color and storyline
    {
        GameObject newNPC = Instantiate(NPCPrefab, characterPool);
        newNPC.transform.Find("Body").gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        int randomStoryline = Random.Range(0, 5);
        newNPC.GetComponent<NPCStory>().storyline = (NPCStory.Storyline)randomStoryline;
        NPCSpawns.Add(newNPC);
    }

    public void RespawnProblemNPC(bool lostHeart)
    {
        while (true)
        {
            int randomSpawnPoint = Random.Range(0, spawnPoints.Count);

            if(randomSpawnPoint != currentSpawnPoint)
            {
                currentSpawnPoint = randomSpawnPoint;
                break;
            }
        }

        currentProblem.transform.position = new Vector2(characterPool.position.x, characterPool.position.y);
        currentSpawnPoint = Random.Range(0, spawnPoints.Count);
        currentProblem = NPCSpawns[Random.Range(0, NPCSpawns.Count)];
        currentProblem.transform.position = new Vector2(spawnPoints[currentSpawnPoint].transform.position.x, spawnPoints[currentSpawnPoint].transform.position.y);
        _pw.npc = currentProblem.transform;
        _pw.timer = 0;

        if (lostHeart)
        {
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }
}

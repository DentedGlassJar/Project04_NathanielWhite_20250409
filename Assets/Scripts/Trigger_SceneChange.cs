using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SceneChange : MonoBehaviour
{
    public string sceneName;
    public string spawnPoint;

    public GameObject levelManagementObj;

    private LevelManager levelManagerRef;

    
    // Start is called before the first frame update
    void Start()
    {
        levelManagerRef = levelManagementObj.GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManagerRef.LoadSceneSpawnPoint(spawnPoint, sceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string spawnPointName;

    public void LoadSceneSpawnPoint(string spawnPoint, string sceneName)
    {
        spawnPointName = spawnPoint;

        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadScene(sceneName);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPlayerSpawnPoint();

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void SetPlayerSpawnPoint()
    {
        GameObject spawnPointObj = GameObject.Find(spawnPointName);

        GameManager.Instance.playerRef.transform.position = spawnPointObj.transform.position;
    }
}



using UnityEngine;
using UnityEngine.SceneManagement;

public class Perehod : MonoBehaviour
{
    public string targetSceneName;
    public float triggerDistance = 0.5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < triggerDistance)
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

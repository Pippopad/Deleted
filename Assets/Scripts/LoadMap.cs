using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public string levelName;

    public GameObject[] onTriggerActivate;
    public GameObject[] onTriggerDeactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(onTriggerActivate.Length != 0)
        {
            for (int i = 0; i < onTriggerActivate.Length; i++)
            {
                Debug.Log("OKKO");
                if (onTriggerActivate[i].activeSelf == false) onTriggerActivate[i].SetActive(true);
            }
        }

        if(collision.tag == "Player")
        {
            Debug.Log("Teleport");
            SceneManager.LoadScene(levelName);
        }
    }
}

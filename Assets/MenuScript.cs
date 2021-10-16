using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Transform rotateItem;

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    void Update()
    {
        rotateItem.Rotate(new Vector3(0, 45f * Time.deltaTime, 0));
    }
}

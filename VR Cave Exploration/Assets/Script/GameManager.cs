using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> goldRockList;
    [SerializeField] private GameObject grabTextPanel;
    public AudioSource audio;
    public AudioSource audio1;

    private void Awake()
    {
        DisableGoldRocks();
    }
    private void Start()
    {
        if (audio1)
        {
            audio1.Play();
        }

    }

    public void DisableGoldRocks()
    {
        foreach (GameObject gold in goldRockList)
        {
            gold.SetActive(false);
        }
    }


    public void EnableGoldRocks()
    {
        foreach(GameObject gold in goldRockList)
        {
            gold.SetActive(true);
        }
    }

    public void ShowGrabTextPanel()
    {
        ShowPanel(grabTextPanel);
    }

    public void ShowPanel(GameObject panelObject)
    {
        panelObject.SetActive(true);
    }
}

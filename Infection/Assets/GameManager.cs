using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerDead;
    public string endScene;
    public Person person;
    public PlayerMovement doctor;

    List<GameObject> listOfOpponents = new List<GameObject>();
    void Start()
    {
        listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Person"));
        //Debug.Log(listOfOpponents.Count);
    }
    void Awake()
    {
        MakeSingleton();
    }
    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private static bool clean(Person p)
    {
        if (p.sprite.color == Color.red)
            return false;
        return true;
    }
    void Update()
    {
        if (doctor.PlayerDead == true)
            SceneManager.LoadScene(endScene);

    }
}


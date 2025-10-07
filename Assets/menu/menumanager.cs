using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menumanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject play;


    void Start()
    {
        quit.GetComponent<Button>().onClick.AddListener(QuitApplication);
        play.GetComponent<Button>().onClick.AddListener(PlayApplication);


    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void QuitApplication()
    {
        Application.Quit();
    }

    void PlayApplication()
    {
        
        SceneManager.LoadSceneAsync("constant");
        SceneManager.LoadSceneAsync("SampleScene",LoadSceneMode.Additive);
    }




}

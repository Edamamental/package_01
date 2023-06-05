using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.useful;
using UnityEngine.SceneManagement;

public class SingletonParentDD : SingletonMonoBehaviour<SingletonParentDD>
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        /*
        Debug.Log(SingletonParent.Instance.gameObject.name);
        Debug.Log(SingletonChild.Instance.gameObject.name);
        Debug.Log(SingletonChildDD.Instance.gameObject.name);
        */
        CheckSingletons();
    }

    void CheckSingletons()
    {
        Debug.Log(SingletonParent.Instance.gameObject.name);
        Debug.Log(SingletonChild.Instance.gameObject.name);
        Debug.Log(SingletonChildDD.Instance.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(SceneManager.GetActiveScene().name == "SceneA")
            {
                SceneManager.LoadScene("SceneB");
            }
            else
            {
                SceneManager.LoadScene("SceneA");
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            CheckSingletons();
        }
    }
}

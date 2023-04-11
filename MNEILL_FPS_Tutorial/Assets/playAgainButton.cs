using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class playAgainButton : MonoBehaviour
{


    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//if restart, reload the scene
    }


}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public void OnButtonStartGameClick(int sceneIndex)
    {
        Application.LoadLevel(sceneIndex);
    }
   
}

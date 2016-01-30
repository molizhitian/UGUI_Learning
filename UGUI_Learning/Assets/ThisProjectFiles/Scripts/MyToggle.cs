using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {


    public GameObject on;
    public GameObject off;

    public Toggle toggle;

    void Start()
    {
        this.MyOnValueChange(toggle.isOn);
    }


    public void MyOnValueChange(bool isOn)
    {
        on.SetActive(isOn);
        off.SetActive(!isOn);
    }
}

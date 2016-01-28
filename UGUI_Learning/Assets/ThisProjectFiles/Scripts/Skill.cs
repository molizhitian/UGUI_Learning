using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

    public float coldTimer = 1;
    private float timer = 0;

    public Image skill;
    private bool isNeedCoolDown = false;

    public KeyCode key;

	void Start () {
	
	}
	
	void Update () {

        if (Input.GetKeyDown(key))
        {
            this.OnClick();
        }

        if (isNeedCoolDown)
        {
            timer += Time.deltaTime;
            skill.fillAmount = (coldTimer - timer) / coldTimer;
            if (timer >= coldTimer)
            {
                skill.fillAmount = 0;
                timer = 0;
                isNeedCoolDown = false;
            }
        }
	}

    public void OnClick()
    {
        isNeedCoolDown = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float health;
    public HudManager HudManager;
    

    // Start is called before the first frame update
    private void Awake()
    {
        HudManager = GameObject.Find("HUD").GetComponent<HudManager>();
        HudManager.UpdateHealthField(health);
    }
    

    public void UpdateHealth(float value)
    {
        health += value;
        HudManager.UpdateHealthField(health);
        
    }
}

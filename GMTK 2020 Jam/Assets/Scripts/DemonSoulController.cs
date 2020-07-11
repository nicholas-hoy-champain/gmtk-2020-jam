using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GainPowerPrompt
{
    none = -1, claw, demonShield, teleFrag, landmine
}

public class DemonSoulController : MonoBehaviour
{
    public float healthIncrease = 2;
    public float manaIncrease = 6;
    public float corruptionIncrease = 0.5f;
    public GainPowerPrompt powerGain = GainPowerPrompt.none;
    public float timeToLive = 10f;
    private float startingTime;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if(timeToLive <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

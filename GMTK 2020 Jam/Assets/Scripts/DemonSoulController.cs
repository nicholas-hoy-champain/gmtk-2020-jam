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
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = timeToLive;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, timeToLive / startingTime);
        if(timeToLive <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

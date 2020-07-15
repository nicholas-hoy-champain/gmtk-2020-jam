using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTeleportPower : MonoBehaviour
{
    public WizardController wizardController;
    public float manaCost = 10;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!wizardController.possessed && !wizardController.busy && manaCost <= wizardController.currentMana)
        {
            CheckForInput();
        }
    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PointerIsInRoom())
        {
            Teleport();
        }
    }

    bool PointerIsInRoom()
    {
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        return (pos.x < Camera.main.transform.position.x + 6.4 && pos.x > Camera.main.transform.position.x - 6.4) && (pos.y < Camera.main.transform.position.y + 3.4 && pos.y > Camera.main.transform.position.y - 3.4);
    }

    void Teleport()
    {
        wizardController.currentMana -= manaCost;

        //Instantiate Smoke/Residue Here

        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        wizardController.transform.position = new Vector3(pos.x, pos.y, wizardController.transform.position.z);

        //Instantiate Explosion Here
        Instantiate(explosionPrefab,transform.position,transform.rotation);
    }
}

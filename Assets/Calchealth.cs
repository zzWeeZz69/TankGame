using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calchealth : MonoBehaviour
{
    [SerializeField] PlayerHPScript HpScript;

    private Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float NormalizeHealth = Mathf.InverseLerp(0, HpScript.maxHealth, HpScript.health);
        Debug.LogError(NormalizeHealth);
        HealthBar.fillAmount = NormalizeHealth;
    }
}

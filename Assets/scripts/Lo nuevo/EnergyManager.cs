using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    // Variables publicas
    public float energy, consumptionRate;
    public UnityEvent OnDischarged;

    public Image usageFiller;
    public Text powerLeftText;

    // Variables privadas
    private int consumptionLevel;
    private bool isDischarged;

    // Singleton
    public static EnergyManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de Variables
        consumptionLevel = 0;
        isDischarged = false;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Si no estamos descargados
        if (!isDischarged)
        {
            Consumption();
        }
    }

    // Funcion de consumo de energia
    void Consumption()
    {
        if (energy > 0f)
        {
            energy -= consumptionRate * consumptionLevel * Time.deltaTime;
            UpdateUI();
        }
        else
        {
            UpdateUI();
            isDischarged=true;
            OnDischarged.Invoke();
        }
    }

    public void IncreaseConsumptionLevel()
    {
        consumptionLevel++;
    }

    public void DecreaseConsumptionLevel()
    {
        consumptionLevel--;
    }

    void UpdateUI()
    {
        powerLeftText.text = (int)energy + "%";
        usageFiller.fillAmount = consumptionLevel / 5f;
    }
}

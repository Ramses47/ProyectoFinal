using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Musicbox : MonoBehaviour
{
    //Variables publicas
    public UnityEvent OnOpened, OnWindUp;
    public GameObject musicboxPanel, warningIcon;
    public Image fillerImage;

    [SerializeField] private float fill, windUpCooldownTime, fillPerWindUp, consumptionRate, warninglLevel;
    private bool isActive, isOpen, canWindUp;


    public static Musicbox Instance { get; private set; }

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
        fill = 1f;
        canWindUp = true;
        isOpen = false;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //si el panel esta activado
        if (musicboxPanel.activeSelf)
        {
            UpdateUI();
        }
        //si la caja esta activada 
        if(isActive && !isOpen)
        {
            Consumption();
        }
    }

    //Funcion de consumo
    public void Consumption()
    {
        fill -= fillPerWindUp * Time.deltaTime;

        //Advertecia
        if(fill <= warninglLevel)
        {
            warningIcon.SetActive(true);
        }
        else
        {
            warningIcon.SetActive(false);
        }
        //0 caja

        if(fill <= 0f)
        {
            warningIcon.SetActive(false);
            isOpen = true;
            OnOpened.Invoke();
        }
    }
    //Funcion para activar y desactivar la UI
    public void SetStateUI(bool _state)
    {
        musicboxPanel.SetActive(_state);
    }

    //fincion para actualizar
    public void UpdateUI()
    {
        fillerImage.fillAmount = fill;
    }

    //activar y desactivar caja 
    public void SetIsAtive(bool _state)
    {
        isActive = _state;
    }

    //Dar cuerda
    public void WindUpMusicBox()
    {
        //caja cativa
        if(isActive && !isOpen)
        {
            if (canWindUp)
            {
                fill += fillPerWindUp;
                fill = Mathf.Clamp(fill, 0f, 1f);
                OnWindUp.Invoke();
                StartCoroutine(ButtonCooldowm());
            }
        }
    }

    //Cooldown 
    IEnumerator ButtonCooldowm()
    {
        canWindUp = false;
        yield return new WaitForSecands(windUpCooldownTime);
        canWindUp = true;
   
    }
}

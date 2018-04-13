using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка бомб, но нужен рефакторинг 
/// </summary>
public class BtnBomb : MonoBehaviour {

    [Header("Bomb Parameters")]
    [SerializeField] private int m_bombId;

    [Header("Image links")]
    [SerializeField] private Image img;
    [SerializeField] private Button btn;
    [SerializeField] private Image selector;

    private float delta = 0.1f;
    private float CoolDown;

    private void OnEnable()
    {
        EventManager.CallDownTime += StartTick;
        BombController.OnChangeActiveBomb += SetStatus;
        BombController.OnChangeBombsSet += SetBombImage;
    }


    private void OnDisable()
    {
        EventManager.CallDownTime -= StartTick;
        BombController.OnChangeActiveBomb -= SetStatus;
        BombController.OnChangeBombsSet -= SetBombImage;
    }
    private void SetBombImage()
    {
        img.sprite = BombController.instance.ActiveBombsSet[m_bombId].GetComponent<SpriteRenderer>().sprite;
    }

    private void SetStatus()
    {
        if(BombController.instance.ActiveBombId == m_bombId)
        {
            selector.gameObject.SetActive(true);
        }
        else
        {
            selector.gameObject.SetActive(false);
        }
    }

    private void StartTick(float time, int id)
    {
       if(m_bombId == id && Player.instance.canDroppingBomb)
        {
            CoolDown = time;
            StopAllCoroutines();
            SetCircleFull();

            StartCoroutine(Tic());
        }
    }


    public void OnClick()
    {
        BombController.instance.SetId(m_bombId);
    }

    private void SetCircleFull()
    {
        btn.GetComponent<Image>().fillAmount = 1;
        btn.GetComponentInChildren<Text>().text = CoolDown.ToString();
    }

    private IEnumerator Tic()
    {
        var cdown = CoolDown;
        Text txt = btn.GetComponentInChildren<Text>();
        Image img = btn.GetComponent<Image>();
        while (true)
        {
       //     Debug.Log(cdown);
            yield return new WaitForSeconds(delta);
            //Debug.Log("Cdown = " + cdown + " fl = " + btnImg.fillAmount);
            cdown -= delta;
            txt.text = string.Format("{0}", cdown);
            img.fillAmount = cdown/CoolDown;
            if (cdown <= 0) break;
        }
        txt.text = string.Empty;
        img.fillAmount = 0;
    }
}

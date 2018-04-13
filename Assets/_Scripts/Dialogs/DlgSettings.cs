using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DlgSettings : DlgAbstract {

    [SerializeField] private Slider SliderFly;
    [SerializeField] private Slider SliderDown;
    [SerializeField] private Slider BombJumpForce;

    [SerializeField] private Text m_flyValueText;
    [SerializeField] private Text m_downValueText;
    [SerializeField] private Text m_bombJumpForceValueText;
    [SerializeField] private Dropdown m_bomb_0;
    [SerializeField] private Dropdown m_bomb_1;
    [SerializeField] private Dropdown m_bomb_2;
    
    private void Start()
    {
        SetStartValues(); 
    }

    private void SetStartValues()
    {
        SliderFly.value = 3f;
        SliderDown.value = 0.3f;
        BombJumpForce.value = 10f;
        Settings.SpeedFly = SliderFly.value;
        Settings.SpeedDown = SliderDown.value;
        Settings.BombJumpForce = BombJumpForce.value;

        m_bomb_0.ClearOptions();
        m_bomb_1.ClearOptions();
        m_bomb_2.ClearOptions();
        List<Dropdown.OptionData> bombs = new List<Dropdown.OptionData>();
        foreach (var item in BombController.instance.Bombs)
        {
            Sprite sp = item.GetComponent<SpriteRenderer>().sprite;
            bombs.Add(new Dropdown.OptionData(item.name, sp));
        }
        m_bomb_0.AddOptions(bombs);
        m_bomb_1.AddOptions(bombs);
        m_bomb_2.AddOptions(bombs);
        m_bomb_0.GetComponent<Dropdown>().value = BombController.instance.FirstBomb;
        m_bomb_1.GetComponent<Dropdown>().value = BombController.instance.SecondBomb;
        m_bomb_2.GetComponent<Dropdown>().value = BombController.instance.ThirdBomb;
    }
    private void Update()
    {
        Settings.SpeedFly = SliderFly.value;
        Settings.SpeedDown = SliderDown.value;
        Settings.BombJumpForce = BombJumpForce.value;
        m_flyValueText.text = SliderFly.value.ToString("#.0");
        m_downValueText.text = SliderDown.value.ToString("#.0");
        m_bombJumpForceValueText.text = BombJumpForce.value.ToString("#.0");
    }

    private IEnumerator CheckSpeed()
    {
        for(; ;)
        {
            yield return new WaitForEndOfFrame();
            Settings.SpeedFly = SliderFly.value;
            Settings.SpeedDown = SliderDown.value;
            Settings.BombJumpForce = BombJumpForce.value;
            m_flyValueText.text = SliderFly.value.ToString("#.0");
            m_downValueText.text = SliderDown.value.ToString("#.0");
            m_bombJumpForceValueText.text = BombJumpForce.value.ToString("#.0");
        }
    }

    public void DropDownSelectBomb()
    {
        BombController.instance.ChangeActiveBombsSet(
            m_bomb_0.GetComponent<Dropdown>().value,
            m_bomb_1.GetComponent<Dropdown>().value,
            m_bomb_2.GetComponent<Dropdown>().value
            );
        
    }

    public override void OnOpenBtnDown()
    {
        base.OnOpenBtnDown();
        ReadButtons();
		StartCoroutine(CheckSpeed());
        GameController.ChangePause();
    }

    private void ReadButtons()
    {
        m_bomb_0.GetComponent<Dropdown>().value = BombController.instance.FirstBomb;
        m_bomb_1.GetComponent<Dropdown>().value = BombController.instance.SecondBomb;
        m_bomb_2.GetComponent<Dropdown>().value = BombController.instance.ThirdBomb;
        m_bomb_0.onValueChanged.AddListener(delegate { DropDownSelectBomb(); });
        m_bomb_1.onValueChanged.AddListener(delegate { DropDownSelectBomb(); });
        m_bomb_2.onValueChanged.AddListener(delegate { DropDownSelectBomb(); });
    }

    public override void OnCloseBtnDown()
    {
        RemoveListenerDropDown();
		StopAllCoroutines();
        base.OnCloseBtnDown();
        GameController.ChangePause();
    }

    private void RemoveListenerDropDown()
    {
        m_bomb_0.onValueChanged.RemoveListener(delegate { DropDownSelectBomb(); });
        m_bomb_1.onValueChanged.RemoveListener(delegate { DropDownSelectBomb(); });
        m_bomb_2.onValueChanged.RemoveListener(delegate { DropDownSelectBomb(); });
    }
}

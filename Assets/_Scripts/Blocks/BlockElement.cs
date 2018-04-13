using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockElement : MonoBehaviour {

    [SerializeField] private SpriteRenderer m_img;

    public void SetSprite(Sprite sprite)
    {
        m_img.sprite = sprite;
    }
	
}

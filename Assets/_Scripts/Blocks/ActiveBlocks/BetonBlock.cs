using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetonBlock : BlockBase
{
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private int m_hitAmount = 3;

    [Tooltip("0 - defaut, 1 - hit, 2 - hit, 3 crash")]
    [SerializeField] private List<Sprite> m_sprites = new List<Sprite>();

    private int m_currentHitAmount = 0;

    private void Start()
    {
        SwitchTexture();
    }
    public override void Hit()
    {
        base.Hit();
        m_currentHitAmount++;
        SwitchTexture();
        if(m_currentHitAmount == 3) BlockController.instance.DestroyBlock(Pos);
    }
    private void SwitchTexture()
    {
        switch (m_currentHitAmount)
        {
            case 0:
                m_spriteRenderer.sprite = m_sprites[0];
                break;
            case 1:
                m_spriteRenderer.sprite = m_sprites[1];
                break;
            case 2:
                m_spriteRenderer.sprite = m_sprites[2];
                break;
            default:
                m_spriteRenderer.sprite = m_sprites.GetRandomOrDefault();
                break;
        }
    }

}

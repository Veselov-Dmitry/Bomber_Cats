using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlockSpawner : MonoBehaviour {

    [Header("Blocks")]
    [SerializeField] private Transform m_parent;

    [Header("Params")]
    [SerializeField] private float m_startXPos;
    [SerializeField] private float m_startYPos;
    [SerializeField] private float m_incXValue; //через сколько спавнить блок начиная со стартовой позиции
    [SerializeField] private float m_incYValue;
    [SerializeField] private float m_additionalHeight;

    private int m_rows;
    private int m_columns;
    private List<GameObject> m_levelBlocks = new List<GameObject>();
    private List<Vector2> m_emptyPositions = new List<Vector2>();
    private List<SpecialBlocks> m_specialBlocks = new List<SpecialBlocks>();

    public List<BlockBase> m_blocks = new List<BlockBase>();

    [Space(10)]
    [SerializeField] private int m_currentLevel;

    public List<BlockBase> Blocks
    {
        get
        {
            return m_blocks;
        }
    }

    private void Start()
    {
        Init();
        InitBlocks();
        CreateField();
        InitCamera();
        FindObjectOfType<PlaneBase>().Init(); //TODO REF
    }
    #region Init
    private void Init()
    {
        m_rows = LevelsData.instance.GetRowsByLevel(m_currentLevel);
        m_columns = LevelsData.instance.GetColumnsByLevel(m_currentLevel);
    }
    private void InitBlocks()
    {
        m_levelBlocks = LevelsData.instance.GetLevelObjects(m_currentLevel);
        m_emptyPositions = LevelsData.instance.GetEmptyCells(m_currentLevel);
        m_specialBlocks = LevelsData.instance.GetSpecialBlocks(m_currentLevel);
    }
    private void InitCamera()
    {
        var pos = new Vector2(GetCenterPositionX(), GetCameraHeight());
        Camera.main.GetComponent<CameraBase>().SetStartPosition(pos);
        Camera.main.GetComponent<CameraBase>().SetFieldOfView(m_columns);
    }
    #endregion

    public void CreateField()
    {
        for (int i = 0; i < m_columns; i++)
        {
            for (int j = 0; j < m_rows; j++)
            {
                var vec = new Vector2(i, j);
                if (!m_emptyPositions.Contains(vec))
                {
                    var pos = new Vector3(m_startXPos + m_incXValue * i, m_startYPos + m_incYValue * j, 0);

                    var specBlock = m_specialBlocks.Find(x => x.position == vec);
                    if (specBlock != null) SpawnPrefab(pos, specBlock.blockPrefab,vec);
                    else  SpawnPrefab(pos, m_levelBlocks.GetRandomOrDefault(),vec);

                }
            }
        }
    }

    private void SpawnPrefab(Vector3 pos, GameObject obj,Vector2 coord)
    {
        var block = Instantiate(obj, m_parent) as GameObject;
        block.transform.localPosition = pos;
        block.GetComponent<BlockBase>().Pos = coord;
        m_blocks.Add(block.GetComponent<BlockBase>());
       
    }

    #region CameraValues
    private float GetCenterPositionX()
    {
        float min = m_blocks.Min(x => x.transform.position.x);
        float max = m_blocks.Max(x => x.transform.position.x);
        float res = (min + max) / 2;
        return res;
    }
    private float GetCameraHeight()
    {
        float height = m_blocks.Max(x => x.transform.position.y);
        return (height + m_additionalHeight);
    }
    #endregion

}

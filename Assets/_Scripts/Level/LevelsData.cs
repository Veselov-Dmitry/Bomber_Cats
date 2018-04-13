using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelsData : MonoBehaviour {
    public static LevelsData instance;
     
    [SerializeField] private List<Level> m_levels;

    private void Awake()
    {
        instance = this;
    }

    public int GetRowsByLevel(int level)
    {
        return m_levels.First(x => x.levelId == level).rows;
    }

    public int GetColumnsByLevel(int level)
    {
        return m_levels.First(x => x.levelId == level).columns;
    }

    public List<GameObject> GetLevelObjects(int level)
    {
        return m_levels.First(x => x.levelId == level).defaultBlocks;
    }

    public List<Vector2> GetEmptyCells(int level)
    {
        return m_levels.First(x => x.levelId == level).emptyCells;
    }

    public List<SpecialBlocks> GetSpecialBlocks(int level)
    {
        return m_levels.First(x => x.levelId == level).specialBlocks;
    }


}

using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Level {
    public int levelId;
    public int rows;
    public int columns;
    [Header("List of default blocks from prefabs")]
    public List<GameObject> defaultBlocks;
    [Header("Positions of empty blocks")]
    public List<Vector2> emptyCells = new List<Vector2>();
    [Header("SpecialBlocks")]
    public List<SpecialBlocks> specialBlocks = new List<SpecialBlocks>();
}

[Serializable]
public class SpecialBlocks
{
    public GameObject blockPrefab;
    public Vector2 position;
}

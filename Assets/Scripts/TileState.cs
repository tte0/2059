using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Tile State")]
public class TileState : ScriptableObject
{
    public int number;
    public Color backgroundColor;
    public Sprite sprite;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishDungeonManager : MonoBehaviour {

    public string dungeon;
    public static int DungeonLv;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void FishDungeonClicked()
    {
        dungeon = EventSystem.current.currentSelectedGameObject.name;
        dungeon = dungeon.Replace("Dungeon", "");
        DungeonLv = int.Parse(dungeon.ToString());

        Debug.Log(DungeonLv);

        AutoFade.LoadLevel("FishGame", 1, 1, Color.black);


    }
    public void EnterDungeonButton()
    {
       
    }
}

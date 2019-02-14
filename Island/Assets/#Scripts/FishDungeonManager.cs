using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishDungeonManager : MonoBehaviour {

    public static string dungeonLv;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void FishDungeonClicked()
    {
        dungeonLv = EventSystem.current.currentSelectedGameObject.name;
        dungeonLv = dungeonLv.Replace("Dungeon", "");
        AutoFade.LoadLevel("FishGame", 1, 1, Color.black);
    }
    public void EnterDungeonButton()
    {
       
    }
}

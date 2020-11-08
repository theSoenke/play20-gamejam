using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public RectTransform StatsRoot;
    public GameObject StatsEntryPrefab;
    public SceneField Scene;
   

    void Awake()
    {
        ClearEntries();
        AddStatsEntry("Time played", GetTimeFormat(GameStateManager.Instance.State.Time));
        if (GameStateManager.Instance.State.WasCaughtByPolice)
        {
            AddStatsEntry("Caught by police", "Yes");
        } 
        else
        {
            AddStatsEntry("Drunk too much", "Yes");
        }
        AddStatsEntry("Promille", (GameStateManager.Instance.State.Drunk / 100f * 3f).ToString("0.00")+ " ‰");
        AddStatsEntry("Drinks", GameStateManager.Instance.State.Drinks.ToString("0"));
        AddStatsEntry("Beers", GameStateManager.Instance.State.Beers.ToString("0"));
        AddStatsEntry("Longdrinks", GameStateManager.Instance.State.Longdrinks.ToString("0"));
        AddStatsEntry("Shots", GameStateManager.Instance.State.Shots.ToString("0"));
        AddStatsEntry("Danced", GameStateManager.Instance.State.Danced.ToString("0"));
        AddStatsEntry("Talked to Guests", GameStateManager.Instance.State.Talked.ToString("0"));
        if (GameStateManager.Instance.State.TalkCausedAnnoyedGuest > 0)
        {
            AddStatsEntry("Talking annoyed Guests", GameStateManager.Instance.State.TalkCausedAnnoyedGuest.ToString("0"));
        }
        AddStatsEntry("Puked", GameStateManager.Instance.State.Puked.ToString("0"));
        var pukedInRoom = GameStateManager.Instance.State.Puked - GameStateManager.Instance.State.PukedInToilett;
        if (pukedInRoom > 0)
        {
            AddStatsEntry("Puked in room", pukedInRoom.ToString("0"));
        }
        if (GameStateManager.Instance.State.HasPeedHimself)
        {
            AddStatsEntry("Peed yourself", "Yes");
        }
        //AddStatsEntry("Suspicious", GameStateManager.Instance.State.Sus.ToString("0"));
    }

    public void AddStatsEntry(string name, string value)
    {
        var obj = Instantiate(StatsEntryPrefab, StatsRoot);
        if(obj.TryGetComponent<StatEntry>(out var entry))
        {
            entry.SetData(name, value);
        }
    }

    public void ClearEntries()
    {
        var children = Enumerable.Range(0, StatsRoot.childCount).Select(cId => StatsRoot.GetChild(cId));
        foreach (var child in children)
        {
            child.parent = null;
            Destroy(child.gameObject);
        }
    }

    public void OkClicked()
    {
        SceneManager.LoadScene(Scene.SceneName);
    }

    private string GetTimeFormat(float seconds)
    {
        var ms = seconds * 1000f;
        var minutes = seconds / 60f;
        var hours = minutes / 60f;

        return $"{hours % 24:00}:{minutes % 60:00}:{seconds % 60:00}";
    }
}

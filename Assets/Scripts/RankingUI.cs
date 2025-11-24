using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RankingUI : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; 

    void Start()
    {
        LoadRankingUI();
    }

    void LoadRankingUI()
    {
        List<int> ranking = RankingManager.LoadRanking();

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < ranking.Count)
            {
                scoreTexts[i].text = (i + 1) + ". " + ranking[i];
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ---";
            }
        }
    }
}

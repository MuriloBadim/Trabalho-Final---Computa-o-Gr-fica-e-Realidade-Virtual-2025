using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RankingScreen : MonoBehaviour
{
    public TextMeshProUGUI rankingText;

    void Start()
    {
        List<int> ranking = RankingManager.LoadRanking();

        rankingText.text = "🏆 TOP 10 SCORES 🏆\n\n";

        if (ranking.Count == 0)
        {
            rankingText.text += "Nenhum score registrado ainda.";
            return;
        }

        for (int i = 0; i < ranking.Count; i++)
        {
            rankingText.text += $"{i + 1}° - {ranking[i]} pontos\n";
        }
    }
}

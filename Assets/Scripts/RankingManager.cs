using UnityEngine;
using System.Collections.Generic;

public static class RankingManager
{
    private const string key = "Ranking";

    // Salvar novo score
    public static void SaveScore(int score)
    {
        List<int> ranking = LoadRanking();

        ranking.Add(score);

        // Ordena do maior para o menor
        ranking.Sort((a, b) => b.CompareTo(a));

        // Mantém somente os top 10
        if (ranking.Count > 10)
            ranking.RemoveRange(10, ranking.Count - 10);

        // Salvar como string
        PlayerPrefs.SetString(key, string.Join(",", ranking));
        PlayerPrefs.Save();
    }

    // Carregar ranking
    public static List<int> LoadRanking()
    {
        string data = PlayerPrefs.GetString(key, "");

        List<int> list = new List<int>();

        if (string.IsNullOrEmpty(data))
            return list;

        string[] parts = data.Split(',');

        foreach (string p in parts)
        {
            if (int.TryParse(p, out int value))
                list.Add(value);
        }

        return list;
    }
}

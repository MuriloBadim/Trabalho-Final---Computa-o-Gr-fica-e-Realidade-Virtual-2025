using UnityEngine;

public class ShipSkinLoader : MonoBehaviour
{
    public Sprite blueShip;
    public Sprite yellowShip;
    public Sprite redShip;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);

        switch (selectedSkin)
        {
            case 0: sr.sprite = blueShip; break;
            case 1: sr.sprite = yellowShip; break;
            case 2: sr.sprite = redShip; break;
        }

        Debug.Log("Skin carregada: " + selectedSkin);
    }
}

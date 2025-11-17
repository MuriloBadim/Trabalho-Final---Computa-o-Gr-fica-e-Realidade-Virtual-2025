using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinMenuManager : MonoBehaviour
{
    public Image previewImage; 
    public Sprite blueShip;
    public Sprite yellowShip;
    public Sprite redShip;

    private int currentSkin = 0; 
    // 0 = azul | 1 = amarelo | 2 = vermelho

    void Start()
    {
        currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        UpdatePreview();
    }

    public void SelectBlue()
    {
        currentSkin = 0;
        PlayerPrefs.SetInt("SelectedSkin", currentSkin);
        UpdatePreview();
        Debug.Log("Skin selecionada: Azul");
    }

    public void SelectYellow()
    {
        currentSkin = 1;
        PlayerPrefs.SetInt("SelectedSkin", currentSkin);
        UpdatePreview();
        Debug.Log("Skin selecionada: Amarela");
    }

    public void SelectRed()
    {
        currentSkin = 2;
        PlayerPrefs.SetInt("SelectedSkin", currentSkin);
        UpdatePreview();
        Debug.Log("Skin selecionada: Vermelha");
    }

    void UpdatePreview()
    {
        switch (currentSkin)
        {
            case 0: previewImage.sprite = blueShip; break;
            case 1: previewImage.sprite = yellowShip; break;
            case 2: previewImage.sprite = redShip; break;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

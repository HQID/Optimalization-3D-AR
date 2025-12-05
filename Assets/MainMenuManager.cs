using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ada untuk pindah scene

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject creditsPanel; // Masukkan Panel Credits disini

    [Header("Scene Names")]
    public string arSceneName = "AR"; // Pastikan nama ini SAMA PERSIS dengan nama scene AR Anda

    // Fungsi untuk Tombol START
    public void TombolStart()
    {
        // Memuat scene AR
        SceneManager.LoadScene(arSceneName);
    }

    // Fungsi untuk Tombol CREDITS
    public void TombolCredits()
    {
        // Menampilkan panel credits
        creditsPanel.SetActive(true);
    }

    // Fungsi untuk Tombol CLOSE di dalam Panel Credits
    public void TombolCloseCredits()
    {
        // Menyembunyikan panel credits
        creditsPanel.SetActive(false);
    }

    // Fungsi untuk Tombol QUIT
    public void TombolQuit()
    {
        Debug.Log("Aplikasi Keluar!"); // Pesan ini hanya muncul di Unity Editor
        Application.Quit();
    }
}
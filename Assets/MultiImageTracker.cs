using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class MultiImageTracker : MonoBehaviour
{
    // 1. Struct untuk memasangkan nama marker dengan prefab di Inspector
    [System.Serializable]
    public struct MarkerPrefabPair
    {
        public string markerName; // Nama harus sama persis dengan di Reference Image Library
        public GameObject prefab; // Objek 3D yang akan muncul
    }

    [Header("Pasangkan Marker dengan Objek disini")]
    public List<MarkerPrefabPair> markerPrefabsList; // List yang diisi di Inspector

    private ARTrackedImageManager trackedImageManager;
    private Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        // Memindahkan List ke Dictionary agar pencarian lebih cepat
        foreach (var pair in markerPrefabsList)
        {
            if (!prefabDictionary.ContainsKey(pair.markerName))
            {
                prefabDictionary.Add(pair.markerName, pair.prefab);
            }
        }
    }

    void OnEnable()
    {
        // Subscribe ke event saat gambar terdeteksi/berubah
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Fungsi utama yang dijalankan saat ada perubahan tracking
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // 1. Saat Marker Baru Terdeteksi (Added)
        foreach (var trackedImage in eventArgs.added)
        {
            string name = trackedImage.referenceImage.name;
            
            // Cek apakah nama marker ada di daftar kita
            if (prefabDictionary.ContainsKey(name))
            {
                // Instantiate (munculkan) prefab yang sesuai
                GameObject newObject = Instantiate(prefabDictionary[name], trackedImage.transform.position, trackedImage.transform.rotation);
                
                // Jadikan child dari trackedImage agar posisi ikut marker otomatis
                newObject.transform.parent = trackedImage.transform;
                
                // Simpan referensi objek yang sudah dispawn
                spawnedObjects[name] = newObject;
            }
        }

        // 2. Saat Marker Hilang/Diupdate (Updated & Removed)
        // AR Foundation biasanya menangani posisi child otomatis, 
        // tapi kita bisa menambahkan logika hide/show jika marker hilang (tracking state limited) di sini.
        foreach (var trackedImage in eventArgs.updated)
        {
            string name = trackedImage.referenceImage.name;
            if (spawnedObjects.ContainsKey(name))
            {
                // Sembunyikan objek jika tracking marker buruk
                spawnedObjects[name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }
        }
    }
}
# AR 3D Object Optimization Showcase - Kelompok 6

![Unity](https://img.shields.io/badge/Unity-2021.3%2B-000000?style=for-the-badge&logo=unity)
![AR Foundation](https://img.shields.io/badge/AR_Foundation-5.0%2B-4B6112?style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20iOS-blue?style=for-the-badge)

Project ini adalah implementasi Augmented Reality (AR) berbasis **Image Tracking** (Marker-based) yang dikembangkan untuk memenuhi tugas mata kuliah. Fokus utama dari project ini adalah teknik **optimalisasi aset 3D** untuk memastikan performa yang stabil (tidak lag) dan tracking yang akurat (tidak bergoyang) pada perangkat mobile.

Aplikasi ini mendeteksi 6 marker berbeda dan memunculkan model 3D zonasi area yang telah dioptimasi secara agresif namun tetap mempertahankan kualitas visual.

## 😎 Anggota Kelompok

* Novita Fadhilah F55123002
* Suparman F55123006
* Hasby Ashidiq F55123010
* Muh. Qhiran N F55123021
* Fahril Hande F55123034
* Angelina Febriani M F55123084

## 🚀 Fitur Utama

* **Multi-Image Tracking:** Mendeteksi dan melacak 6 marker unik secara simultan atau bergantian.
* **High Performance:** Aset 3D yang sangat ringan untuk memastikan *frame rate* stabil (60 FPS target).
* **Stable Tracking:** Menggunakan XR Core (ARCore/ARKit) untuk stabilitas jangkar objek yang lebih baik dibandingkan solusi pihak ketiga lainnya.
* **Offline Ready:** Tidak membutuhkan cloud rendering; semua aset di-render secara lokal di perangkat.

## 🛠️ Pipeline Optimalisasi Objek 3D

Untuk mencapai performa maksimal dan ukuran aplikasi yang efisien, kami menerapkan pipeline pemrosesan aset (Geometry Processing) yang ketat sebelum aset dimasukkan ke dalam Unity.

**Alur Kerja Optimalisasi:**

1.  **Raw Assets:** Pengumpulan aset mentah.
2.  **GLTF-Transform:** Menggunakan *command-line tool* `gltf-transform` untuk:
    * **Resize:** Menyesuaikan skala tekstur.
    * **Simplify:** Mengurangi jumlah *polygon/tris* tanpa merusak bentuk visual utama.
    * **Join/Mesh:** Menggabungkan *draw calls* untuk mengurangi beban CPU.
    * **Draco Compression:** Kompresi data geometri.
3.  **Blender Conversion:** Import hasil optimasi ke Blender untuk penyesuaian akhir material dan **Export ke format .FBX**.
4.  **Unity Integration:** Import .FBX ke Unity dan pengaturan Prefab.

## 🏙️ Daftar Objek 3D (Zones)

Aplikasi ini memvisualisasikan 6 zona area berikut:

1.  🏭 **Industri**
2.  🌾 **Agro Industri**
3.  ⚡ **Electrical Zone**
4.  📦 **Gudang (Warehouse)**
5.  🏥 **Kantor & Rumah Sakit**
6.  🏡 **Real Estate**

## 💻 Tech Stack

Project ini dibangun menggunakan teknologi berikut (Sesuai spesifikasi tugas, tanpa Vuforia):

* **Game Engine:** Unity (Disarankan versi LTS terbaru).
* **AR Framework:** Unity AR Foundation.
* **Low-Level API:** XR Core Utilities (Memanfaatkan ARCore pada Android & ARKit pada iOS).
* **Version Control:** Git.
* **Optimization Tools:** gltf-transform, Blender.

## 📱 Cara Menjalankan Project

### Prasyarat
* Unity Hub & Unity Editor (dengan modul Android Build Support / iOS Build Support terinstall).
* Smartphone yang mendukung ARCore (Android) atau ARKit (iOS).

### Instalasi
1.  **Clone Repository ini:**
    ```bash
    git clone [https://github.com/username-kalian/nama-repo-kalian.git](https://github.com/username-kalian/nama-repo-kalian.git)
    ```
2.  **Buka di Unity:**
    Buka Unity Hub, pilih "Add Project from Disk", dan arahkan ke folder hasil clone.
3.  **Pengaturan Build:**
    * Pergi ke `File` > `Build Settings`.
    * Switch Platform ke **Android** atau **iOS**.
    * Pastikan scene utama (`MainScene`) sudah

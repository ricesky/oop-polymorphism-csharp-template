# oop-polymorphism-csharp

## Sub Capaian Pembelajaran

1. Mahasiswa mampu menerapkan polymorphism (runtime dispatch) melalui pemanggilan method virtual pada referensi bertipe kelas induk.
2. Mahasiswa mampu mengimplementasikan overriding (override) untuk mengubah perilaku method virtual dari kelas induk.
3. Mahasiswa mampu melakukan upcasting dan downcasting secara aman serta memahami risiko cast yang salah.

## Lingkungan Pengembangan

1. Platform: .NET 6.0
2. Bahasa: C# 10
3. IDE: Visual Studio 2022

## Cara membuka project menggunakan Visual Studio

1. Clone repositori project `oop-polymorphism-csharp` ke direktori lokal git Anda.
2. Buka Visual Studio, pilih menu File > Open > Project/Solution > Pilih file *.sln.
3. Tekan tombol Open untuk  untuk membuka solusi.
4. Baca soal dengan seksama. Buat implementasi kode sesuai dengan petunjuk.
6. Jalankan unit test di project *.Tests

> PERINGATAN: Push kode program ke remote repository jika hanya seluruh test case sudah lolos/passed (bertanda hijau).

## Soal-soal

### Parade Hewan

Buat solusi dari soal ini di project `Solution` folder `PetParade` dengan namespace `Solution.PetParade`.

Sebuah taman hiburan mengadakan parade hewan setiap akhir pekan. Dalam parade tersebut, berbagai jenis hewan tampil dan memperkenalkan diri dengan suara khasnya masing-masing. Panitia parade ingin membuat sistem sederhana untuk mengelola daftar hewan dan menampilkan suara mereka secara bergantian.

Buatlah sebuah kelas publik bernama `Hewan` yang merepresentasikan hewan secara umum. Kelas ini memiliki satu informasi penting berupa nama hewan yang disimpan dalam field private `_nama` bertipe string. Sediakan properti publik `Nama` untuk membaca dan mengubah nilai tersebut. Kelas `Hewan` harus memiliki sebuah konstruktor yang menerima nama hewan saat objek dibuat.

Tambahkan sebuah metode publik bernama `Bersuara` yang bertipe `virtual` dan mengembalikan string. Secara default, metode ini mengembalikan teks `"Tidak diketahui"`.

Selanjutnya, buat dua kelas turunan dari `Hewan`, yaitu `Kucing` dan `Anjing`. Kelas `Kucing` harus meng-override metode `Bersuara` sehingga mengembalikan `"Meong"`, sedangkan kelas `Anjing` harus meng-override metode tersebut sehingga mengembalikan `"Guk"`. Tambahkan masing-masing satu properti khusus pada setiap kelas turunan (misalnya `WarnaBulu` untuk `Kucing` dan `LevelPatuh` untuk `Anjing`).

Buat kelas publik bernama `ParadeHewan` yang memiliki atribut private berupa `List<Hewan>` untuk menyimpan semua hewan yang ikut parade. Sediakan metode `TambahHewan` untuk menambahkan hewan ke dalam daftar, serta metode `HapusHewan` untuk menghapus hewan dari daftar.

Tambahkan metode `MulaiParade(int putaran)` yang akan menampilkan suara setiap hewan sesuai urutan di dalam daftar dan diulang sebanyak jumlah putaran yang diberikan. Format tampilannya adalah:

```
{Nama} bersuara: {hasilBersuara}
```

Terakhir, buat kelas `Program` dengan metode statik `Main`. Instansiasikan beberapa objek `Kucing` dan `Anjing`, tambahkan ke dalam `ParadeHewan`, lalu panggil `MulaiParade` untuk menampilkan suara mereka ke layar.

---

### Studio Musik

Buat solusi dari soal ini di project `Solution` folder `MusicStudio` dengan namespace `Solution.MusicStudio`.

Sebuah studio musik memiliki berbagai jenis instrumen yang dapat dimainkan. Setiap instrumen memiliki nama dan suara khas yang berbeda ketika dimainkan. Pemilik studio ingin membuat sistem untuk menyimpan berbagai instrumen dan memainkannya secara bergantian.

Buatlah sebuah kelas publik bernama `Instrumen` yang memiliki field private `_nama` bertipe string dan properti publik `Nama`. Sediakan konstruktor untuk menginisialisasi nama instrumen saat objek dibuat.

Tambahkan metode publik bertipe `virtual` bernama `Mainkan` yang mengembalikan string. Secara default, metode ini mengembalikan `"Tidak ada suara"`.

Buat dua kelas turunan, yaitu `Gitar` dan `Piano`. Kelas `Gitar` harus meng-override metode `Mainkan` sehingga mengembalikan `"tring tring"`, sedangkan kelas `Piano` harus meng-override metode tersebut sehingga mengembalikan `"tink tink"`. Tambahkan satu properti khusus pada masing-masing kelas (misalnya `JumlahSenar` pada `Gitar` dan `JumlahTuts` pada `Piano`).

Buat kelas `StudioMusik` yang memiliki atribut private berupa `List<Instrumen>` untuk menyimpan daftar instrumen. Sediakan metode `TambahInstrumen` untuk menambahkan instrumen ke dalam daftar.

Tambahkan metode `MainkanInstrumen` yang akan mengembalikan gabungan suara seluruh instrumen dengan format:

```
{Nama} berbunyi: {hasilMainkan}
```

Buat kelas `Program` dan metode `Main` untuk menguji sistem dengan membuat beberapa instrumen dan memanggil metode `MainkanInstrumen`.

---

### Bengkel Kendaraan

Buat solusi dari soal ini di project `Solution` folder `Workshop` dengan namespace `Solution.Workshop`.

Sebuah bengkel menerima berbagai jenis kendaraan untuk diservis setiap hari. Setiap kendaraan memiliki nomor plat dan prosedur servis yang berbeda tergantung jenisnya. Pemilik bengkel ingin membuat sistem untuk mengelola kendaraan yang masuk dan memproses servisnya.

Buatlah sebuah kelas publik bernama `Kendaraan` yang memiliki field private `_plat` bertipe string dan properti publik `Plat`. Sediakan konstruktor untuk menginisialisasi nomor plat kendaraan.

Tambahkan metode publik bertipe `virtual` bernama `Servis` yang secara default mengembalikan `"Servis umum"`.

Buat dua kelas turunan, yaitu `Mobil` dan `Motor`. Kelas `Mobil` harus meng-override metode `Servis` sehingga mengembalikan `"Ganti oli + cek rem"`, sedangkan kelas `Motor` harus meng-override metode tersebut sehingga mengembalikan `"Ganti oli + cek rantai"`.

Buat kelas `Bengkel` yang memiliki atribut private berupa `List<Kendaraan>` untuk menyimpan kendaraan yang akan diservis. Sediakan metode `Tambah` untuk menambahkan kendaraan dan metode `ProsesServis(int putaran)` untuk memproses servis setiap kendaraan sesuai jumlah putaran yang diberikan.

Format output servis adalah:

```
{Plat} servis: {hasilServis}
```

Buat kelas `Program` untuk menguji implementasi ini.

---

### Pusat Notifikasi

Buat solusi dari soal ini di project `Solution` folder `NotificationCenter` dengan namespace `Solution.NotificationCenter`.

Sebuah perusahaan memiliki sistem notifikasi yang dapat mengirim pesan melalui berbagai kanal seperti email dan SMS. Setiap jenis notifikasi memiliki cara pengiriman dan informasi tambahan yang berbeda.

Buat kelas publik bernama `Notifikasi` dengan field private `_tujuan` bertipe string dan properti publik `Tujuan`. Tambahkan konstruktor untuk menginisialisasi tujuan notifikasi.

Tambahkan metode publik bertipe `virtual` bernama `Kirim` yang secara default mengembalikan `"Notifikasi terkirim"`.

Buat dua kelas turunan, yaitu `EmailNotifikasi` dan `SmsNotifikasi`. Kelas `EmailNotifikasi` memiliki properti tambahan `Subjek` dan meng-override metode `Kirim` sehingga mengembalikan `"Email terkirim"`. Kelas `SmsNotifikasi` memiliki properti tambahan `Provider` dan meng-override metode `Kirim` sehingga mengembalikan `"SMS terkirim"`.

Buat kelas `PusatNotifikasi` yang menyimpan daftar notifikasi dalam `List<Notifikasi>`. Sediakan metode `Tambah` untuk menambahkan notifikasi.

Tambahkan metode `KirimSemua` yang menampilkan hasil pengiriman seluruh notifikasi dalam format:

```
{Tujuan}: {hasilKirim}
```

Tambahkan pula metode `DetailSemua` yang menggunakan pattern matching (`is`) untuk menampilkan detail khusus setiap jenis notifikasi.

Buat kelas `Program` untuk menguji sistem ini.

---

### Sistem Pembayaran

Buat solusi dari soal ini di project `Solution` folder `PaymentSystem` dengan namespace `Solution.PaymentSystem`.

Sebuah kasir modern mendukung berbagai metode pembayaran seperti tunai, QRIS, dan kartu bank. Setiap metode pembayaran memiliki cara pemrosesan yang berbeda.

Buat kelas publik bernama `MetodePembayaran` dengan field private `_nama` bertipe string dan properti publik `Nama`. Sediakan konstruktor untuk menginisialisasi nama metode pembayaran.

Tambahkan metode publik bertipe `virtual` bernama `Bayar(decimal nominal)` yang secara default mengembalikan `"Pembayaran diproses"`.

Buat tiga kelas turunan, yaitu `Cash`, `Qris`, dan `Kartu`. Kelas `Cash` meng-override metode `Bayar` sehingga menampilkan `"Bayar tunai sebesar {nominal}"`. Kelas `Qris` memiliki properti tambahan `MerchantId` dan meng-override metode tersebut sehingga menampilkan `"Bayar QRIS ke {MerchantId} sebesar {nominal}"`. Kelas `Kartu` memiliki properti tambahan `NamaBank` dan meng-override metode tersebut sehingga menampilkan `"Bayar kartu {NamaBank} sebesar {nominal}"`.

Buat kelas `Kasir` yang menyimpan daftar metode pembayaran dalam `List<MetodePembayaran>`. Sediakan metode `Tambah` untuk menambahkan metode pembayaran.

Tambahkan metode `Proses(decimal nominal)` untuk memproses semua metode pembayaran dalam format:

```
{Nama}: {hasilBayar}
```

Tambahkan metode `RingkasanQris` yang menggunakan pattern matching untuk menampilkan hanya metode pembayaran bertipe `Qris`.

Buat kelas `Program` untuk menguji implementasi ini.

=== Selesai ===
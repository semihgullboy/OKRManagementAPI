# TekhnelogosOkrApi

## Proje Açıklaması

Bu proje, Tekhnelogos firmasında staj yaparken geliştirmiş olduğum OKR sisteminin backend tarafını oluşturmaktadır. Şirketin stratejik hedeflerini belirlemesine, bu hedeflere ulaşmak için anahtar sonuçlar oluşturulmasına ve bu sonuçları takip etmesine olanak sağlar.Proje, Visual Studio kullanılarak .NET 6 ile geliştirilmiş ve çok katmanlı mimari yapısı kullanılarak yapılmıştır.

## Kullanılan Teknolojiler

- **.NET 6**: Web API ve arka uç iş mantığı için.
- **Entity Framework Core**: Veritabanı yönetimi ve Code-First için kullanılmıştır.
- **Swagger**: API dokümantasyonu için kullanılmıştır.
- **FluentValidation**: Veri doğruluğu için kullanılmıştır.
- **AutoMapper**: Veri transferi nesneleri (ViewModel) ile entity arasında dönüşüm için kullanılmıştır.
- **LDAP**: Kullanıcı bilgilerini LDAP'dan çekmek ve kullanıcı girişi için kullanılmıştır.

## Gereksinimler

Projeyi çalıştırmak için .NET 6'nın yüklü olması gerekir.

SQL Server veritabanı kullanılmalıdır.

## Kurulum

<details>
  
1. **Bu projeyi klonlayın:**

```bash
git clone https://gitlab.tekhnelogos.com/tekhnestars2024/tekhnelogosokrapi.git
```

2. **Projenizi IDE'nizde açın:**

   Uygulamayı Visual Studio kullanarak açın.

3. **Veritabanı yapılandırmasını yapın:**

   `appsettings.Development.json` dosyasındaki bağlantı dizesini ve diğer ayarları kendi ortamınıza göre yapılandırın. Örnek yapılandırma:

   ```bash
   "ConnectionStrings": {
   "TekhnelogosOkrContext": "Database=your_database;User Id=your_db_user;Password=your_db_password; TrustServerCertificate=True"
   ```

4. **Migration işlemini uygulayın:**

   Package manager konsolunu açınız ve varsayılan projeyi TekhnelogosOkr.DataAccess yapınız.

   ```bash
   add-migration init
   update-database
   ```

5. **Uygulamanızı başlatın ve API'yi test edin:**

Swagger üzerinden API endpoint'lerinizi aşağıda bulunan dökümanlara göre test edebilirsiniz.

</details>

## Auth API Kullanımı

<details>

#### Giriş yapmak için

```http
  POST /api/Auth/Login
```

| Parametre  | Tip      | Açıklama                                             |
| :--------- | :------- | :--------------------------------------------------- |
| `email`    | `string` | **Gerekli**. Kendinize ait Tekhnelogos şirket maili. |
| `password` | `string` | **Gerekli**. Mail şifreniz.                          |

**Başarıyla giriş yaptığınızda alacağınız yanıt:**

```json
{
  "token": "tokenbilgisi",
  "message": "Giriş başarılı bir şekilde gerçekleşti."
}
```

**Eğer başarısız giriş yaparsanız alabileceğiniz yanıtlar:**

    1. "401 Unauthorized" : Kullanıcı adı veya şifre hatalıysa.

    2. "404 Not Found": Kullanıcı LDAP üzerinde veya veritabanında mevcut değilse.

    3. "500 Internal Server Error": Genel bir hata oluştuysa.

</details>

## CompanyObjective API Kullanımı

<details>

#### Şirket hedefi oluşturmak için:

```http
  POST /api/CompanyObjective/add
```

| Parametre | Tip      | Açıklama                                |
| :-------- | :------- | :-------------------------------------- |
| `title`   | `string` | **Gerekli**. Şirket hedefi başlığı.     |
| `weight`  | `int`    | **Gerekli**. Şirket hedefinin ağırlığı. |

**Başarıyla kayıt yaptığınızda alacağınız yanıt:**

```json
{
  "message": "Şirket hedefi başarıyla eklendi."
}
```

**Eğer kayıt başarısız ise alacabileceğiniz hata kodları:**

    1. 400 Bad Request: Geçersiz istek veya model doğrulama hatası.

    2. 500 Internal Server Error: Genel bir hata oluştuysa.

#### Tüm şirket hedeflerini getirmek için:

```http
  GET /api/CompanyObjective
```

**İşlem başarılı olursa alacağınız yanıt:**

```json
{
  "id": 1,
  "title": "Hedef Başlığı",
  "weight": 10,
  "totalWeight": 100
}
```

1.  **İşlem başarısız olursa alacağınız hata kodu:**

2.  **"500 Internal Server Error:"** Genel bir hata oluştuysa.

#### Şirket hedefini ait OKR hedefleri ile getirmek için:

```http
  GET /api/CompanyObjective/{id}
```

| Parametre | Tip   | Açıklama                               |
| :-------- | :---- | :------------------------------------- |
| `id`      | `int` | **Gerekli**. Şirket hedefinin kimliği. |

**İşlem başarılı olursa alacağınız yanıt:**

```json
{
"id": 1,
"title": "Hedef Başlığı",
"weight": 10,
"createdDate": "2024-01-01T00:00:00",
"progress": 50,
"statusId": 1,
"totalWeight": 100,
"okrObjectives": [
  {
      "id": 1,
      "title": "OKR Hedefi Başlığı",
      "createdDate": "2024-01-01T00:00:00",
      "weight": 20,
      "progress": 75,
      "statusId": 1
  }
]
```

**İşlem başarısız olursa alabileceğiniz hata kodları:**

1.  "404 Not Found:" Şirket hedefi bulunamadıysa.
2.  "500 Internal Server Error:" Genel bir hata oluştuysa.

#### Şirket hedefini güncellemek için:

```http
  PUT /api/CompanyObjective/{id}
```

| Parametre | Tip      | Açıklama                                |
| :-------- | :------- | :-------------------------------------- |
| `id`      | `int`    | **Gerekli**. Şirket hedefinin kimliği.  |
| `title`   | `string` | **Gerekli**. Şirket hedefi başlığı.     |
| `weight`  | `int`    | **Gerekli**. Şirket hedefinin ağırlığı. |

**JSON Gövde Örneği**

```json
{
  "title": "Yeni Hedef Başlığı",
  "weight": 15
}
```

**Başarıyla güncellendiğinde alacağınız yanıt:**

```json
{
  "message": "Şirket hedefi başarıyla güncellendi."
}
```

**Güncellenmediği <aman alabileceğiniz hata kodları:**

1.  "400 Bad Request:" Geçersiz istek veya model doğrulama hatası.

2.  "404 Not Found:" Şirket hedefi bulunamadıysa.

3.  "500 Internal Server Error:" Genel bir hata oluştuysa

#### Şirket hedefini silmek için:

```http
  DELETE /api/CompanyObjective/{id}
```

| Parametre | Tip   | Açıklama                               |
| :-------- | :---- | :------------------------------------- |
| `id`      | `int` | **Gerekli**. Şirket hedefinin kimliği. |

**Başarıyla Silindiğinde Yanıt**

```json
{
  "message": "Şirket hedefi başarıyla silindi."
}
```

**Silinemediği Zaman Karşılacağınız Hata Kodları:**

    1. "404 Not Found:" Şirket hedefi bulunamadıysa.

    2. "500 Internal Server Error:" Genel bir hata oluştuysa

</details>

## KeyResult API Kullanımı

<details>

#### KeyResult eklemek için:

```http
  POST /api/KeyResult/create
```

| Parametre         | Tip        | Açıklama                                             |
| :---------------- | :--------- | :--------------------------------------------------- |
| `title`           | `string`   | **Gerekli**. Key Result başlık bilgisi.              |
| `targetDate`      | `datetime` | **Gerekli**. Hedef tarih bilgisi.                    |
| `createdByUserId` | `int`      | **Gerekli**. Key Result'ı oluşturan kişinin kimliği. |
| `okrObjectiveId`  | `int`      | **Gerekli**. Okr kimliği .                           |

**Başarıyla ekleme işlemi yaptığınızda alacağınız yanıt:**

```json
{
  "data": 136, //KeyResult ID'si
  "message": "Key Result başarılı bir şekilde kaydedildi."
}
```

**Eğer işlem başarısız olursa alabileceğiniz yanıtlar:**

    1. "400 Bad Request" : Geçersiz istek veya model doğrulama hatası.

    2. "500 Internal Server Error": Genel bir hata oluştuysa.

#### KeyResult eklemek için:

```http
  DELETE /api/KeyResult/{id}
```

| Parametre | Tip   | Açıklama                         |
| :-------- | :---- | :------------------------------- |
| `id`      | `int` | **Gerekli**. Key Result kimliği. |

**Başarıyla silindiğinde alacağınız yanıt:**

```json
  Key Result başarılı bir şekilde silindi.
```

**Eğer işlem başarısız olursa alabileceğiniz yanıtlar:**

    1. "404 Not Found" :  Şirket hedefi bulunamadıysa.

    2. "500 Internal Server Error": Genel bir hata oluştuysa.

#### KeyResult güncellemek için:

```http
  PUT /api/KeyResult/{id}
```

| Parametre | Tip      | Açıklama                                |
| :-------- | :------- | :-------------------------------------- |
| `id`      | `int`    | **Gerekli**. Key Result kimliği.        |
| `title`   | `string` | **Gerekli**. Key Result başlık bilgisi. |

**Başarıyla güncellendiğinde alacağınız yanıt:**

```json
  Key Result başarılı bir şekilde güncellendi.
```

**Eğer işlem başarısız olursa alabileceğiniz yanıtlar:**

    1. "400 Bad Request" : Geçersiz istek veya model doğrulama hatası.

    2. "404 Not Found" :  Şirket hedefi bulunamadıysa.

    3. "500 Internal Server Error": Genel bir hata oluştuysa.

</details>

## LDAP API Kullanımı

<details>

#### Kullanıcıları veritabanına eklemek için:

```http
  POST /api/Ldap/importUsers
```

**Başarıyla kullancılar kaydedilerse:**

```json
"Kullanıcılar kaydedildi."
```

**Eğer kullancılar kaydedilerken hata olursa:**

```json
"LDAP'den kullanıcıları içe aktarırken bir hata oluştu: {ex.Message}"
```

</details>

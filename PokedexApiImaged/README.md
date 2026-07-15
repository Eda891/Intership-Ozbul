# PokedexApi

Clean Architecture + CQRS + MediatR ile yazılmış basit bir Pokemon CRUD API'si.

## Katmanlar
- **PokedexApi.Domain**: `Pokemon` entity ve `IPokemonRepository` arayüzü.
- **PokedexApi.Application**: CQRS Command/Query'ler, MediatR handler'lar, DTO'lar, AutoMapper profili.
- **PokedexApi.Infrastructure**: EF Core (SQLite) `PokedexDbContext` ve `PokemonRepository`.
- **PokedexApi.API**: Controller'lar ve `Program.cs`.

## Çalıştırma
```bash
cd PokedexApi
dotnet restore
dotnet ef migrations add InitialCreate --project PokedexApi.Infrastructure --startup-project PokedexApi.API
dotnet ef database update --project PokedexApi.Infrastructure --startup-project PokedexApi.API
dotnet run --project PokedexApi.API
```

Swagger arayüzü: `https://localhost:xxxx/swagger`

## Uç Noktalar
| Metot | Yol | Açıklama |
|---|---|---|
| GET | /api/pokemon | Tüm pokemonları listeler |
| GET | /api/pokemon/{id} | ID'ye göre pokemon getirir |
| POST | /api/pokemon | Yeni pokemon ekler |
| PUT | /api/pokemon/{id} | Pokemon günceller |
| DELETE | /api/pokemon/{id} | Pokemon siler |

## Pokemon Modeli (sade)
| Alan | Açıklama | Örnek |
|---|---|---|
| Name | İsim | Charmeleon |
| Height | Boy | 3' 07" |
| Weight | Ağırlık | 41.9 lbs |
| Category | Kategori | Flame |
| Abilities | Yetenek(ler) | Blaze |
| ImageUrl | Görsel linki (opsiyonel) | https://... |

### Örnek POST isteği
```json
{
  "name": "Charmeleon",
  "height": "3' 07\"",
  "weight": "41.9 lbs",
  "category": "Flame",
  "abilities": "Blaze",
  "imageUrl": "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png"
}
```

### Örnek PUT isteği (id: 1)
```json
{
  "id": 1,
  "name": "Charmeleon",
  "height": "3' 07\"",
  "weight": "41.9 lbs",
  "category": "Flame",
  "abilities": "Blaze, Solar Power",
  "imageUrl": "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png"
}
```

Tüm alanlar `[Required]` — boş bırakırsan API otomatik `400 Bad Request` döner (extra kod yazmana gerek yok, `[ApiController]` attribute'u bunu otomatik yapıyor).

## Model Değiştiği İçin: Eski Migration'ı Sıfırlama
Alanlar değiştiği için önceki migration'ı ve veritabanını silip yeniden oluşturman gerekiyor:
```bash
# PokedexApi.Infrastructure/Migrations klasörünü sil (varsa)
rm -r PokedexApi.Infrastructure/Migrations   # Windows: rd /s /q PokedexApi.Infrastructure\Migrations

# eski veritabanı dosyasını sil (varsa)
rm PokedexApi.API/pokedex.db                 # Windows: del PokedexApi.API\pokedex.db

# yeniden oluştur
dotnet ef migrations add InitialCreate --project PokedexApi.Infrastructure --startup-project PokedexApi.API
dotnet ef database update --project PokedexApi.Infrastructure --startup-project PokedexApi.API
```

## Not
Category, kararlaştırdığımız gibi ayrı bir tabloya değil basit bir metin alanına (`string`)
olarak tutuluyor — ekstra Category entity/controller/repository yok. İleride ilişkisel
yapıya geçmek istersen (CategoryId + ayrı Category tablosu), söylemen yeterli.

`ImageUrl` alanı sadece bir link (`string`) tutar — sunucuya dosya yüklenmiyor, sadece
başka bir yerde (örn. pokemon.com, wikipedia, kendi CDN'in) barındırılan görselin adresi
kaydediliyor. Alan opsiyonel, boş bırakılabilir.

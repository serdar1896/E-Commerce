using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proje.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategoriAd = table.Column<string>(nullable: true),
                    KategoriTarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "marka",
                columns: table => new
                {
                    MarkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkaAdi = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    ResimYol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marka", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ulke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "altKategori",
                columns: table => new
                {
                    AltKategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategoriId = table.Column<int>(nullable: false),
                    AltKategoriAd = table.Column<string>(nullable: true),
                    AltKategoriTarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_altKategori", x => x.AltKategoriId);
                    table.ForeignKey(
                        name: "FK_altKategori_kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uyeler",
                columns: table => new
                {
                    UyeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    TcNo = table.Column<string>(nullable: true),
                    KayitTarihi = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UyeDurum = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyeler", x => x.UyeId);
                    table.ForeignKey(
                        name: "FK_uyeler_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "il",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Ulkeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_il", x => x.Id);
                    table.ForeignKey(
                        name: "FK_il_ulke_Ulkeid",
                        column: x => x.Ulkeid,
                        principalTable: "ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "urunler",
                columns: table => new
                {
                    UrunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunKodu = table.Column<string>(nullable: true),
                    UrunAdi = table.Column<string>(nullable: true),
                    AlisFiyati = table.Column<float>(nullable: false),
                    SatisFiyati = table.Column<float>(nullable: false),
                    UrunAciklama = table.Column<string>(nullable: true),
                    UrunTarih = table.Column<DateTime>(nullable: false),
                    UrunDurum = table.Column<bool>(nullable: false),
                    MarkaId = table.Column<int>(nullable: false),
                    AltKategoriId = table.Column<int>(nullable: false),
                    Kampanyaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunler", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_urunler_altKategori_AltKategoriId",
                        column: x => x.AltKategoriId,
                        principalTable: "altKategori",
                        principalColumn: "AltKategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_urunler_marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "marka",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ilce",
                columns: table => new
                {
                    IlceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Ilid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilce", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_ilce_il_Ilid",
                        column: x => x.Ilid,
                        principalTable: "il",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stok",
                columns: table => new
                {
                    StokId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(nullable: false),
                    UrunAdet = table.Column<string>(nullable: true),
                    DepoAdres = table.Column<string>(nullable: true),
                    Tip = table.Column<int>(nullable: false),
                    Giris = table.Column<DateTime>(nullable: false),
                    Cikis = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stok", x => x.StokId);
                    table.ForeignKey(
                        name: "FK_stok_urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "urunResim",
                columns: table => new
                {
                    ResimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(nullable: false),
                    ResimYol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunResim", x => x.ResimId);
                    table.ForeignKey(
                        name: "FK_urunResim_urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "urunyorum",
                columns: table => new
                {
                    YorumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(nullable: false),
                    UyeId = table.Column<int>(nullable: false),
                    Yorum = table.Column<string>(nullable: true),
                    YorumDurum = table.Column<bool>(nullable: false),
                    YorumTarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunyorum", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_urunyorum_urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_urunyorum_uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyeler",
                        principalColumn: "UyeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uyeAdress",
                columns: table => new
                {
                    AdresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UyeId = table.Column<int>(nullable: false),
                    IlceId = table.Column<int>(nullable: false),
                    AdresTanim = table.Column<string>(nullable: true),
                    PostaKodu = table.Column<string>(nullable: true),
                    AdresTuru = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uyeAdress", x => x.AdresId);
                    table.ForeignKey(
                        name: "FK_uyeAdress_ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "ilce",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_uyeAdress_uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyeler",
                        principalColumn: "UyeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kargo",
                columns: table => new
                {
                    KargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SirketAdi = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    AdresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kargo", x => x.KargoId);
                    table.ForeignKey(
                        name: "FK_kargo_uyeAdress_AdresId",
                        column: x => x.AdresId,
                        principalTable: "uyeAdress",
                        principalColumn: "AdresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "siparismaster",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiparisTarih = table.Column<DateTime>(nullable: false),
                    ToplamFiyat = table.Column<float>(nullable: false),
                    SepetteMi = table.Column<bool>(nullable: false),
                    SiparisDurum = table.Column<bool>(nullable: false),
                    KargoId = table.Column<int>(nullable: false),
                    UyeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siparismaster", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK_siparismaster_kargo_KargoId",
                        column: x => x.KargoId,
                        principalTable: "kargo",
                        principalColumn: "KargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_siparismaster_uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "uyeler",
                        principalColumn: "UyeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "siparisdetay",
                columns: table => new
                {
                    SiparisId = table.Column<int>(nullable: false),
                    UrunId = table.Column<int>(nullable: false),
                    Miktar = table.Column<int>(nullable: false),
                    BirimFiyat = table.Column<float>(nullable: false),
                    Indirim = table.Column<float>(nullable: false),
                    TeslimTarihi = table.Column<DateTime>(nullable: false),
                    OdemeSecenekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siparisdetay", x => new { x.SiparisId, x.UrunId });
                    table.ForeignKey(
                        name: "FK_siparisdetay_siparismaster_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "siparismaster",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_siparisdetay_urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_altKategori_KategoriId",
                table: "altKategori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_il_Ulkeid",
                table: "il",
                column: "Ulkeid");

            migrationBuilder.CreateIndex(
                name: "IX_ilce_Ilid",
                table: "ilce",
                column: "Ilid");

            migrationBuilder.CreateIndex(
                name: "IX_kargo_AdresId",
                table: "kargo",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_siparisdetay_UrunId",
                table: "siparisdetay",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_siparismaster_KargoId",
                table: "siparismaster",
                column: "KargoId");

            migrationBuilder.CreateIndex(
                name: "IX_siparismaster_UyeId",
                table: "siparismaster",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_stok_UrunId",
                table: "stok",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_urunler_AltKategoriId",
                table: "urunler",
                column: "AltKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_urunler_MarkaId",
                table: "urunler",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_urunResim_UrunId",
                table: "urunResim",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_urunyorum_UrunId",
                table: "urunyorum",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_urunyorum_UyeId",
                table: "urunyorum",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_uyeAdress_IlceId",
                table: "uyeAdress",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_uyeAdress_UyeId",
                table: "uyeAdress",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_uyeler_RoleId",
                table: "uyeler",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "siparisdetay");

            migrationBuilder.DropTable(
                name: "stok");

            migrationBuilder.DropTable(
                name: "urunResim");

            migrationBuilder.DropTable(
                name: "urunyorum");

            migrationBuilder.DropTable(
                name: "siparismaster");

            migrationBuilder.DropTable(
                name: "urunler");

            migrationBuilder.DropTable(
                name: "kargo");

            migrationBuilder.DropTable(
                name: "altKategori");

            migrationBuilder.DropTable(
                name: "marka");

            migrationBuilder.DropTable(
                name: "uyeAdress");

            migrationBuilder.DropTable(
                name: "kategoriler");

            migrationBuilder.DropTable(
                name: "ilce");

            migrationBuilder.DropTable(
                name: "uyeler");

            migrationBuilder.DropTable(
                name: "il");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "ulke");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSchool_Project.Migrations
{
    /// <inheritdoc />
    public partial class adddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
             
            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoTen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sdt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BangCap = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaChi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GioiTinh = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgaySinh = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UrlImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NganhHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenNganh = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhHocs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TenDangNhap = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MatKhau = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoaiTaiKhoan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TenDangNhap);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
             
            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoTen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sdt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BangCap = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaChi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GioiTinh = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgaySinh = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    idNganhHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangViens_NganhHocs_idNganhHoc",
                        column: x => x.idNganhHoc,
                        principalTable: "NganhHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenKhoaHoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoTa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HinhThuc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idNganhHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoaHocs_NganhHocs_idNganhHoc",
                        column: x => x.idNganhHoc,
                        principalTable: "NganhHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChuongHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenChuongHoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoTa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idKhoaHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuongHocs_KhoaHocs_idKhoaHoc",
                        column: x => x.idKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DangKyKhoaHocs",
                columns: table => new
                {
                    idGiangVien = table.Column<int>(type: "int", nullable: false),
                    idKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    NgayHoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GiaKhoaHoc = table.Column<float>(type: "float", nullable: true),
                    SoLuongKhoaHoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DangKyKhoaHocs_GiangViens_idGiangVien",
                        column: x => x.idGiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyKhoaHocs_KhoaHocs_idKhoaHoc",
                        column: x => x.idKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DanhGiaMonHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChiTietDanhGia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiemDanhGia = table.Column<int>(type: "int", nullable: false),
                    idHocVien = table.Column<int>(type: "int", nullable: false),
                    idKhoaHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaMonHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGiaMonHocs_HocViens_idHocVien",
                        column: x => x.idHocVien,
                        principalTable: "HocViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGiaMonHocs_KhoaHocs_idKhoaHoc",
                        column: x => x.idKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ThamGiaKhoaHocs",
                columns: table => new
                {
                    idKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    idHocVien = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ThamGiaKhoaHocs_HocViens_idHocVien",
                        column: x => x.idHocVien,
                        principalTable: "HocViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThamGiaKhoaHocs_KhoaHocs_idKhoaHoc",
                        column: x => x.idKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BaiHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenBaiHoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoTa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlVideo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlBaiTap = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idChuongHoc = table.Column<int>(type: "int", nullable: false),
                    idKhoaHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiHocs_ChuongHocs_idChuongHoc",
                        column: x => x.idChuongHoc,
                        principalTable: "ChuongHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiHocs_KhoaHocs_idKhoaHoc",
                        column: x => x.idKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
             
            migrationBuilder.CreateIndex(
                name: "IX_BaiHocs_idChuongHoc",
                table: "BaiHocs",
                column: "idChuongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_BaiHocs_idKhoaHoc",
                table: "BaiHocs",
                column: "idKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChuongHocs_idKhoaHoc",
                table: "ChuongHocs",
                column: "idKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_idGiangVien",
                table: "DangKyKhoaHocs",
                column: "idGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_idKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "idKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaMonHocs_idHocVien",
                table: "DanhGiaMonHocs",
                column: "idHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaMonHocs_idKhoaHoc",
                table: "DanhGiaMonHocs",
                column: "idKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "IX_GiangViens_idNganhHoc",
                table: "GiangViens",
                column: "idNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocs_idNganhHoc",
                table: "KhoaHocs",
                column: "idNganhHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaKhoaHocs_idHocVien",
                table: "ThamGiaKhoaHocs",
                column: "idHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaKhoaHocs_idKhoaHoc",
                table: "ThamGiaKhoaHocs",
                column: "idKhoaHoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropTable(
                name: "BaiHocs");

            migrationBuilder.DropTable(
                name: "DangKyKhoaHocs");

            migrationBuilder.DropTable(
                name: "DanhGiaMonHocs");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "ThamGiaKhoaHocs");
             
            migrationBuilder.DropTable(
                name: "ChuongHocs");

            migrationBuilder.DropTable(
                name: "GiangViens");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "NganhHocs");
        }
    }
}

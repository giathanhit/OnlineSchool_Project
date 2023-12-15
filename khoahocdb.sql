-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 15, 2023 at 09:54 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `khoahocdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `baihocs`
--

CREATE TABLE `baihocs` (
  `Id` int NOT NULL,
  `TenBaiHoc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MoTa` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UrlVideo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UrlBaiTap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ChuongHocsId` int NOT NULL,
  `KhoaHocsId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `chuonghocs`
--

CREATE TABLE `chuonghocs` (
  `Id` int NOT NULL,
  `TenChuongHoc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MoTa` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `KhoaHocsId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dangkykhoahocs`
--

CREATE TABLE `dangkykhoahocs` (
  `GiangVienId` int NOT NULL,
  `KhoaHocId` int NOT NULL,
  `NgayHoc` datetime(6) NOT NULL,
  `NgayKetThuc` datetime(6) NOT NULL,
  `GiaKhoaHoc` float DEFAULT NULL,
  `SoLuongKhoaHoc` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `danhgiamonhocs`
--

CREATE TABLE `danhgiamonhocs` (
  `Id` int NOT NULL,
  `ChiTietDanhGia` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DiemDanhGia` int NOT NULL,
  `HocViensId` int NOT NULL,
  `KhoaHocsId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `giangviens`
--

CREATE TABLE `giangviens` (
  `Id` int NOT NULL,
  `HoTen` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sdt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BangCap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DiaChi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GioiTinh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UrlImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NgaySinh` datetime(6) NOT NULL,
  `NganhHocsId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `hocviens`
--

CREATE TABLE `hocviens` (
  `Id` int NOT NULL,
  `HoTen` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sdt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BangCap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DiaChi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GioiTinh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NgaySinh` datetime(6) NOT NULL,
  `UrlImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `khoahocs`
--

CREATE TABLE `khoahocs` (
  `Id` int NOT NULL,
  `TenKhoaHoc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MoTa` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HinhThuc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UrlImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NganhHocsId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nganhhocs`
--

CREATE TABLE `nganhhocs` (
  `Id` int NOT NULL,
  `TenNganh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `taikhoans`
--

CREATE TABLE `taikhoans` (
  `TenDangNhap` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MatKhau` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoaiTaiKhoan` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `thamgiakhoahocs`
--

CREATE TABLE `thamgiakhoahocs` (
  `KhoaHocId` int NOT NULL,
  `HocVienId` int NOT NULL,
  `NgayDangKy` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231215094749_add-db', '7.0.9');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `baihocs`
--
ALTER TABLE `baihocs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_BaiHocs_ChuongHocsId` (`ChuongHocsId`),
  ADD KEY `IX_BaiHocs_KhoaHocsId` (`KhoaHocsId`);

--
-- Indexes for table `chuonghocs`
--
ALTER TABLE `chuonghocs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ChuongHocs_KhoaHocsId` (`KhoaHocsId`);

--
-- Indexes for table `dangkykhoahocs`
--
ALTER TABLE `dangkykhoahocs`
  ADD KEY `IX_DangKyKhoaHocs_GiangVienId` (`GiangVienId`),
  ADD KEY `IX_DangKyKhoaHocs_KhoaHocId` (`KhoaHocId`);

--
-- Indexes for table `danhgiamonhocs`
--
ALTER TABLE `danhgiamonhocs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_DanhGiaMonHocs_HocViensId` (`HocViensId`),
  ADD KEY `IX_DanhGiaMonHocs_KhoaHocsId` (`KhoaHocsId`);

--
-- Indexes for table `giangviens`
--
ALTER TABLE `giangviens`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_GiangViens_NganhHocsId` (`NganhHocsId`);

--
-- Indexes for table `hocviens`
--
ALTER TABLE `hocviens`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `khoahocs`
--
ALTER TABLE `khoahocs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_KhoaHocs_NganhHocsId` (`NganhHocsId`);

--
-- Indexes for table `nganhhocs`
--
ALTER TABLE `nganhhocs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `taikhoans`
--
ALTER TABLE `taikhoans`
  ADD PRIMARY KEY (`TenDangNhap`);

--
-- Indexes for table `thamgiakhoahocs`
--
ALTER TABLE `thamgiakhoahocs`
  ADD KEY `IX_ThamGiaKhoaHocs_HocVienId` (`HocVienId`),
  ADD KEY `IX_ThamGiaKhoaHocs_KhoaHocId` (`KhoaHocId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `baihocs`
--
ALTER TABLE `baihocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `chuonghocs`
--
ALTER TABLE `chuonghocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `danhgiamonhocs`
--
ALTER TABLE `danhgiamonhocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `giangviens`
--
ALTER TABLE `giangviens`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `hocviens`
--
ALTER TABLE `hocviens`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `khoahocs`
--
ALTER TABLE `khoahocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nganhhocs`
--
ALTER TABLE `nganhhocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `baihocs`
--
ALTER TABLE `baihocs`
  ADD CONSTRAINT `FK_BaiHocs_ChuongHocs_ChuongHocsId` FOREIGN KEY (`ChuongHocsId`) REFERENCES `chuonghocs` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_BaiHocs_KhoaHocs_KhoaHocsId` FOREIGN KEY (`KhoaHocsId`) REFERENCES `khoahocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `chuonghocs`
--
ALTER TABLE `chuonghocs`
  ADD CONSTRAINT `FK_ChuongHocs_KhoaHocs_KhoaHocsId` FOREIGN KEY (`KhoaHocsId`) REFERENCES `khoahocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `dangkykhoahocs`
--
ALTER TABLE `dangkykhoahocs`
  ADD CONSTRAINT `FK_DangKyKhoaHocs_GiangViens_GiangVienId` FOREIGN KEY (`GiangVienId`) REFERENCES `giangviens` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_DangKyKhoaHocs_KhoaHocs_KhoaHocId` FOREIGN KEY (`KhoaHocId`) REFERENCES `khoahocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `danhgiamonhocs`
--
ALTER TABLE `danhgiamonhocs`
  ADD CONSTRAINT `FK_DanhGiaMonHocs_HocViens_HocViensId` FOREIGN KEY (`HocViensId`) REFERENCES `hocviens` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_DanhGiaMonHocs_KhoaHocs_KhoaHocsId` FOREIGN KEY (`KhoaHocsId`) REFERENCES `khoahocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `giangviens`
--
ALTER TABLE `giangviens`
  ADD CONSTRAINT `FK_GiangViens_NganhHocs_NganhHocsId` FOREIGN KEY (`NganhHocsId`) REFERENCES `nganhhocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `khoahocs`
--
ALTER TABLE `khoahocs`
  ADD CONSTRAINT `FK_KhoaHocs_NganhHocs_NganhHocsId` FOREIGN KEY (`NganhHocsId`) REFERENCES `nganhhocs` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `thamgiakhoahocs`
--
ALTER TABLE `thamgiakhoahocs`
  ADD CONSTRAINT `FK_ThamGiaKhoaHocs_HocViens_HocVienId` FOREIGN KEY (`HocVienId`) REFERENCES `hocviens` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ThamGiaKhoaHocs_KhoaHocs_KhoaHocId` FOREIGN KEY (`KhoaHocId`) REFERENCES `khoahocs` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

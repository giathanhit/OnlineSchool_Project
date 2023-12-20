-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 20, 2023 at 07:26 PM
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
  `idChuongHoc` int NOT NULL,
  `idKhoaHoc` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `baihocs`
--

INSERT INTO `baihocs` (`Id`, `TenBaiHoc`, `MoTa`, `UrlVideo`, `UrlBaiTap`, `idChuongHoc`, `idKhoaHoc`) VALUES
(1, 'Giới thiệu khóa học', 'Giới thiệu tổng quan khóa học Blazor căn bản. Blazor là một framework opensrouce mới do Microsoft phát triển sử dụng ngôn ngữ C# để phát triển WebAssembly.', 'https://www.youtube.com/watch?v=R2Ttnd47T9Q&list=PLRhlTlpDUWszBRs388Koxf6sMBSuOs8cd', NULL, 1, 1),
(2, 'Blazor là gì?', 'Tìm hiểu tổng quan về Blazor, lịch sử của nó, tìm hiểu về các phiên bản ứng dụng Blazor', 'https://www.youtube.com/watch?v=SyqewfzqPis&list=PLRhlTlpDUWszBRs388Koxf6sMBSuOs8cd&index=3', NULL, 1, 1),
(3, 'test', '12', 'sa', NULL, 1, 3);

-- --------------------------------------------------------

--
-- Table structure for table `chuonghocs`
--

CREATE TABLE `chuonghocs` (
  `Id` int NOT NULL,
  `TenChuongHoc` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MoTa` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `idKhoaHoc` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `chuonghocs`
--

INSERT INTO `chuonghocs` (`Id`, `TenChuongHoc`, `MoTa`, `idKhoaHoc`) VALUES
(1, 'Lập trình Blazor căn bản', 'Hướng dẫn lập trình Blazor căn bản', 1),
(2, ' Giới thiệu về khóa học và kế hoạch phát triển ứng dụng', '1. Giới thiệu tổng quan khóa học\r\n2. Cách học lập trình trực tuyến sao cho hiệu quả\r\n3. Cách thức tương tác với giảng viên\r\n4. Xây dựng kế hoạch phát triển ứng dụng\r\n5. Định nghĩa tiêu chuẩn đầu  ra', 2),
(3, 'Tìm hiểu về ABP Framework', '1. Giới thiệu về ABP Framework \r\n2. Hiểu về Clean Architecture \r\n3. Cấu trúc solution của ABP Framework \r\n4. Cách setup và chạy một solution ABP Framework', 3);

-- --------------------------------------------------------

--
-- Table structure for table `dangkykhoahocs`
--

CREATE TABLE `dangkykhoahocs` (
  `idGiangVien` int NOT NULL,
  `idKhoaHoc` int NOT NULL,
  `KhoaHocsId` int DEFAULT NULL,
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
  `idHocVien` int NOT NULL,
  `idKhoaHoc` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `giangviens`
--

CREATE TABLE `giangviens` (
  `Id` int NOT NULL,
  `HoTen` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MatKhau` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CCCD` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sdt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BangCap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DiaChi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GioiTinh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UrlImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NgaySinh` datetime(6) NOT NULL,
  `idNganhHoc` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `giangviens`
--

INSERT INTO `giangviens` (`Id`, `HoTen`, `Email`, `MatKhau`, `CCCD`, `Sdt`, `BangCap`, `DiaChi`, `GioiTinh`, `UrlImage`, `NgaySinh`, `idNganhHoc`) VALUES
(1, 'Jiaqing', 'jiaqing@gmail.com', '123123', '35287469', '0321567894', 'Kỹ sư CNTT', 'hutech 2', 'Nam', 'jiaqing.jpeg', '1990-01-01 00:00:00.000000', 1),
(2, 'Hà Gia Bảo', 'hagiabao@gmail.com', '123123', '35287465', '0236514789', 'Kỹ sư CNTT', 'Bình Chánh, TP.HCM', 'Nam', 'ha-gia-bao.jpg', '1990-01-01 00:00:00.000000', 1);

-- --------------------------------------------------------

--
-- Table structure for table `hocviens`
--

CREATE TABLE `hocviens` (
  `Id` int NOT NULL,
  `HoTen` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MatKhau` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sdt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `BangCap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DiaChi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `GioiTinh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NgaySinh` datetime(6) NOT NULL,
  `UrlImage` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `hocviens`
--

INSERT INTO `hocviens` (`Id`, `HoTen`, `Email`, `MatKhau`, `Sdt`, `BangCap`, `DiaChi`, `GioiTinh`, `NgaySinh`, `UrlImage`) VALUES
(1, 'Jiaqing', 'jiaqing@gmail.com', '123123', '0123654788', 'Đại học', 'TP. Long Xuyên, An Giang', 'Nam', '1990-01-01 00:00:00.000000', 'jiaqing.jpg');

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
  `idNganhHoc` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `khoahocs`
--

INSERT INTO `khoahocs` (`Id`, `TenKhoaHoc`, `MoTa`, `HinhThuc`, `UrlImage`, `idNganhHoc`) VALUES
(1, 'Lập trình Keylogger với C# Application', 'Nâng cao tư duy bằng cách sử dụng C# để giải một số thuật toán cơ bản.', 'Online', 'lap-trinh-keylogger-voi-c-application.jpg', 1),
(2, 'Khóa Thực chiến SQL - Dự án quản lý sinh viên', 'Khóa học dạy lập trình cơ bản với ngôn ngữ Java', 'Online', 'khoa-thuc-chien-sql-du-an-quan-ly-sinh-vien.png', 1),
(3, 'Lập trình Blazor cơ bản', 'Khóa học về cách dùng Blazor cơ bản', 'Online', 'lap-trinh-blazor-co-ban.png', 1);

-- --------------------------------------------------------

--
-- Table structure for table `nganhhocs`
--

CREATE TABLE `nganhhocs` (
  `Id` int NOT NULL,
  `TenNganh` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `nganhhocs`
--

INSERT INTO `nganhhocs` (`Id`, `TenNganh`) VALUES
(1, 'Công nghệ thông tin'),
(2, 'Ngôn ngữ anh'),
(3, 'Thiết kế đồ họa');

-- --------------------------------------------------------

--
-- Table structure for table `taikhoans`
--

CREATE TABLE `taikhoans` (
  `TenDangNhap` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ID` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MatKhau` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `taikhoans`
--

INSERT INTO `taikhoans` (`TenDangNhap`, `ID`, `Email`, `MatKhau`) VALUES
('admin', '0c032e7e-b9a2-41b3-b6d5-dfe6ecfd7a2e', 'admin@gmail.com', '21232f297a57a5a743894a0e4a801fc3'),
('jiaqing', 'cee8e7df-496e-4f79-875d-a59745192eda', 'jiaqing@gmail.com', '4297f44b13955235245b2497399d7a93');

-- --------------------------------------------------------

--
-- Table structure for table `thamgiakhoahocs`
--

CREATE TABLE `thamgiakhoahocs` (
  `idKhoaHoc` int NOT NULL,
  `idHocVien` int NOT NULL,
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
('20231219044136_add-db', '7.0.9');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `baihocs`
--
ALTER TABLE `baihocs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `chuonghocs`
--
ALTER TABLE `chuonghocs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `dangkykhoahocs`
--
ALTER TABLE `dangkykhoahocs`
  ADD KEY `IX_DangKyKhoaHocs_KhoaHocsId` (`KhoaHocsId`);

--
-- Indexes for table `danhgiamonhocs`
--
ALTER TABLE `danhgiamonhocs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `giangviens`
--
ALTER TABLE `giangviens`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `hocviens`
--
ALTER TABLE `hocviens`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `khoahocs`
--
ALTER TABLE `khoahocs`
  ADD PRIMARY KEY (`Id`);

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
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `chuonghocs`
--
ALTER TABLE `chuonghocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `danhgiamonhocs`
--
ALTER TABLE `danhgiamonhocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `giangviens`
--
ALTER TABLE `giangviens`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `hocviens`
--
ALTER TABLE `hocviens`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `khoahocs`
--
ALTER TABLE `khoahocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `nganhhocs`
--
ALTER TABLE `nganhhocs`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dangkykhoahocs`
--
ALTER TABLE `dangkykhoahocs`
  ADD CONSTRAINT `FK_DangKyKhoaHocs_KhoaHocs_KhoaHocsId` FOREIGN KEY (`KhoaHocsId`) REFERENCES `khoahocs` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

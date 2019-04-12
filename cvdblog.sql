-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 12, 2019 at 12:10 PM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cvdblog`
--

-- --------------------------------------------------------

--
-- Table structure for table `baiviet`
--

CREATE TABLE `baiviet` (
  `ID` int(11) NOT NULL,
  `TENBAIVIET` varchar(300) CHARACTER SET utf8 NOT NULL,
  `NOIDUNGBAIVIET` varchar(5000) CHARACTER SET utf8 NOT NULL,
  `DANHMUCID` int(11) NOT NULL,
  `NGAYTAO` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `danhmuc`
--

CREATE TABLE `danhmuc` (
  `ID` int(11) NOT NULL,
  `TEN` varchar(200) CHARACTER SET utf8 NOT NULL,
  `IDDANHMUCCHA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `danhmuc`
--

INSERT INTO `danhmuc` (`ID`, `TEN`, `IDDANHMUCCHA`) VALUES
(1, 'Lập Trình', 0),
(2, 'C#', 1),
(3, 'C++', 1),
(4, 'HTML5/CSS3', 1),
(5, 'Góc Chia Sẻ', 0),
(6, 'Chuyện  lập trình', 5),
(7, 'Công nghệ', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `HOVATEN` varchar(120) CHARACTER SET utf8 NOT NULL,
  `TENDANGNHAP` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `MATKHAU` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `NGAYLAP` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `AVATAR` varchar(200) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `HOVATEN`, `TENDANGNHAP`, `MATKHAU`, `NGAYLAP`, `AVATAR`) VALUES
(1, 'Cao Van Dũng', 'admin', 'x3Xnt1ft5jDNCqERO9ECZhqziCnKUqZCKreChi8mhkY=', '8/4/2019', ''),
(2, 'Cao Trấn Thiên', 'caothien', 'admin', '08/04/2019', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `baiviet`
--
ALTER TABLE `baiviet`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `danhmuc`
--
ALTER TABLE `danhmuc`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `baiviet`
--
ALTER TABLE `baiviet`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `danhmuc`
--
ALTER TABLE `danhmuc`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

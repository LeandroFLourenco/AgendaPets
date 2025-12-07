-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 07/12/2025 às 21:02
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `crudpets`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `agendamento`
--

CREATE TABLE `agendamento` (
  `ID_AGENDAMENTO` int(11) NOT NULL,
  `NOMPET` varchar(100) NOT NULL,
  `ESPECIE` varchar(50) NOT NULL,
  `NOMTUTOR` varchar(100) NOT NULL,
  `SERVICO` varchar(100) NOT NULL,
  `DAT_AGENDAMENTO` datetime NOT NULL,
  `DAT_INCLUSAO` date DEFAULT NULL,
  `DAT_EXCLUSAO` date DEFAULT NULL,
  `DAT_ALTERACAO` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `agendamento`
--

INSERT INTO `agendamento` (`ID_AGENDAMENTO`, `NOMPET`, `ESPECIE`, `NOMTUTOR`, `SERVICO`, `DAT_AGENDAMENTO`, `DAT_INCLUSAO`, `DAT_EXCLUSAO`, `DAT_ALTERACAO`) VALUES
(1, 'dasfadsfasdfasfdsad', 'Cachorro', 'asdfasdf', 'asdfsafasd', '2025-12-08 00:00:00', '2025-12-07', '2025-12-07', '2025-12-07'),
(2, 'asdfasf', 'Gato', 'asdfasfas', 'asdfasdfa', '2025-12-17 00:00:00', '2025-12-07', '2025-12-07', NULL),
(3, 'nezuko', 'Cachorro', 'kaori', 'tosa', '2025-12-08 00:00:00', '2025-12-07', NULL, '2025-12-07'),
(4, 'teste', 'Ave', 'teste', 'teste', '2025-12-30 00:00:00', '2025-12-07', NULL, NULL);

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `agendamento`
--
ALTER TABLE `agendamento`
  ADD PRIMARY KEY (`ID_AGENDAMENTO`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `agendamento`
--
ALTER TABLE `agendamento`
  MODIFY `ID_AGENDAMENTO` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

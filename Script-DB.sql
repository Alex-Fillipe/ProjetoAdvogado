-- dbadvogado.advogado definição

CREATE TABLE `advogado` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Senioridade` varchar(20) NOT NULL,
  `Logradouro` varchar(100) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Estado` char(2) NOT NULL,
  `CEP` varchar(9) NOT NULL,
  `Numero` int NOT NULL,
  `Complemento` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


-- dbadvogado.login definição

CREATE TABLE `login` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Senha` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Usuario` (`Usuario`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

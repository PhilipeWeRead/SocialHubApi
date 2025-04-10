-- Código de exemplo para aplicação de uma mini rede social.
CREATE DATABASE SocialHub;

USE SocialHub;

-- Tabela de Usuários.

CREATE TABLE Users 
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    ProfileImageUrl NVARCHAR(255) NULL -- URL da imagem de perfil.
);

-- Tabela de Posts.

CREATE TABLE Posts 
(
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Content NVARCHAR(350) NOT NULL, -- Limite de 350 caracteres.
    CreatedAt DATETIME NOT NULL,
    UserId INT,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
);
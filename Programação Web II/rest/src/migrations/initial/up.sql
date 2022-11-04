CREATE TABLE `autores`
(
    `id`           int(11) NOT NULL AUTO_INCREMENT,
    `nome`         varchar(20)  DEFAULT NULL,
    `descricao`    varchar(100) DEFAULT NULL,
    `data_criacao` date         DEFAULT NULL,
    PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

CREATE TABLE `categoria`
(
    `id`   int(11) NOT NULL AUTO_INCREMENT,
    `nome` varchar(30) NOT NULL,
    PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

CREATE TABLE `posts`
(
    `id`           int(11) NOT NULL AUTO_INCREMENT,
    `titulo`       varchar(20) DEFAULT NULL,
    `texto`        text        DEFAULT NULL,
    `autor_id`     int(11) DEFAULT NULL,
    `data_criacao` date        DEFAULT NULL,
    PRIMARY KEY (`id`),
    KEY            `autor_id` (`autor_id`),
    CONSTRAINT `posts_ibfk_1` FOREIGN KEY (`autor_id`) REFERENCES `autores` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

CREATE TABLE `post_categoria`
(
    `id_post`      int(11) NOT NULL,
    `id_categoria` int(11) NOT NULL,
    PRIMARY KEY (`id_categoria`, `id_post`),
    KEY            `id_post` (`id_post`),
    CONSTRAINT `post_categoria_ibfk_1` FOREIGN KEY (`id_post`) REFERENCES `posts` (`id`),
    CONSTRAINT `post_categoria_ibfk_2` FOREIGN KEY (`id_categoria`) REFERENCES `categoria` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
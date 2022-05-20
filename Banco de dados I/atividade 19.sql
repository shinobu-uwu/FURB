INSERT INTO Cor (ds_cor) VALUES ('Amarelo');
INSERT INTO Cor (ds_cor) VALUES ('Prata');
INSERT INTO Cor (ds_cor) VALUES ('Preto');
INSERT INTO Cor (ds_cor) VALUES ('Cinza');
INSERT INTO Cor (ds_cor) VALUES ('Branco');
INSERT INTO Cor (ds_cor) VALUES ('Vermelho');
INSERT INTO Cor (ds_cor) VALUES ('Azul');
INSERT INTO Cor (ds_cor) VALUES ('Verde');
INSERT INTO Cor (ds_cor) VALUES ('Marrom');
INSERT INTO Combustivel (ds_combustivel) VALUES ('Álcool');
INSERT INTO Combustivel (ds_combustivel) VALUES ('Gasolina');
INSERT INTO Combustivel (ds_combustivel) VALUES ('Diesel');
INSERT INTO Marca (ds_marca) VALUES ('Abarth');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (1, '124 Spider');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (1, '595');
INSERT INTO Marca (ds_marca) VALUES ('Audi');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (2, 'A1');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (2, 'A3');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (2, 'e-tron');
INSERT INTO Marca (ds_marca) VALUES ('Bentley');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (3, 'Bentayga');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (3, 'Continental GT');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (3, 'Flying Spur');
INSERT INTO Marca (ds_marca) VALUES ('BMW');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (4, 'X6');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (4, 'X1');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (4, 'Serie 1');
INSERT INTO Marca (ds_marca) VALUES ('Cadillac');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (5, 'ATS');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (5, 'CT6');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (5, 'CTS');
INSERT INTO Marca (ds_marca) VALUES ('Chevrolet');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (6, 'Aveo');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (6, 'Captiva');
INSERT INTO Marca (ds_marca) VALUES ('Citroen');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (7, 'Berlingo');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (7, 'C-Elysée');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (7, 'C-Zero');
INSERT INTO Marca (ds_marca) VALUES ('Ferrari');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (8, 'F8 Tributo');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (8, 'SF90 Stradale');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (8, '812 Superfast');
INSERT INTO Marca (ds_marca) VALUES ('Fiat');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (9, '500X');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (9, '500');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (9, '500L');
INSERT INTO Marca (ds_marca) VALUES ('Ford');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (10, 'Fiesta');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (10, 'Mustang');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (10, 'Bronco');
INSERT INTO Marca (ds_marca) VALUES ('Honda');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (11, 'Jazz');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (11, 'Civic');
INSERT INTO Modelo (cd_marca, ds_modelo) VALUES (11, 'CR-V');
INSERT INTO Localidade (nm_localidade) VALUES ('Zona sul');
INSERT INTO Localidade (nm_localidade) VALUES ('Zona norte');
INSERT INTO Localidade (nm_localidade) VALUES ('Zona lest');
INSERT INTO Localidade (nm_localidade) VALUES ('Zona oeste');
INSERT INTO Localidade (nm_localidade) VALUES ('Centro');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Farol de milha');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Banco de couro');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Cinzeiro');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Rádio');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Suporte de celular');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Porta-copo');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Pingente');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Espelho para pontos cegos');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Gel de limpeza');
INSERT INTO Acessorio (ds_acessorio) VALUES ('Aspirador de pó portátil');
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (1, 'Jacinto Pinto', 'Rua 15 de novembro', '', 'Centro', '(68) 2277-6616', 'jacinto.pintoyahoo.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('MXU2656', 1, 1, 1, 2017, 2013, 50000, 6, 'Muito rápido');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MXU2656', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MXU2656', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MXU2656', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MXU2656', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MXU2656', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MXU2656', 6);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (2, 'Paulo Brificado', 'Rua 7 de setembro', 'ap 202', 'Centro', '(48) 2284-7544', 'paulo.brificadooutlook.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('NAO7547', 5, 2, 2, 2019, 2011, 60000, 8, 'Muito rápido');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('NAO7547', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 6);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NAO7547', 5);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (3, 'Vanessa Souza', 'Rua Coronel Vidal Ramos', '', 'Jardim Blumenau', '(82) 2434-2262', 'vanessa.souzaoutlook.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('NBI5403', 1, 3, 3, 2013, 2011, 30000, 4, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('NBI5403', 3);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('NBI5403', 2);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('NBI5403', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 6);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 8);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('NBI5403', 7);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (4, 'Lurdes dos Santos', 'Rua Paraguai', '', 'Ponta Aguda', '(92) 3856-4636', 'lurdes.dos.santosbol.com.br', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('JHP2228', 1, 4, 4, 2014, 2012, 50000, 4, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('JHP2228', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('JHP2228', 10);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (5, 'Pedro Rocha', 'Rua Uruguai', '', 'Ponta Aguda', '(86) 2727-3882', 'pedro.rochagmail.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('IND4426', 4, 5, 5, 2015, 2014, 10000, 4, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('IND4426', 1);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('IND4426', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 10);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 8);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 7);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('IND4426', 3);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (6, 'Amanda Nunes', 'Rua Venezuela', 'ap 202', 'Ponta Aguda', '(81) 2716-3178', 'amanda.nunesbol.com.br', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('MTZ2532', 2, 6, 6, 2012, 2010, 40000, 8, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MTZ2532', 2);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MTZ2532', 3);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MTZ2532', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 8);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 5);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 6);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 7);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MTZ2532', 3);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (7, 'Lilian Reinert', 'Rua Chile', '', 'Ponta Aguda', '(49) 2492-6426', 'lilian.reinertbol.com.br', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('HRI1923', 5, 7, 7, 2020, 2013, 20000, 6, 'Para Rally');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('HRI1923', 3);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('HRI1923', 1);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('HRI1923', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HRI1923', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HRI1923', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HRI1923', 4);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (8, 'Harry Potter', 'Rua dos Alfeneiros', '', 'Ponta Aguda', '(94) 2144-8274', 'harry.pottergmail.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('MZO3602', 7, 8, 8, 2016, 2013, 60000, 6, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MZO3602', 3);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MZO3602', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 9);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 7);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 5);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 8);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MZO3602', 1);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (9, 'Vernon Dursley', 'Rua Equador', '', 'Ponta Aguda', '(11) 3675-6825', 'vernon.dursleygmail.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('MVG1346', 4, 9, 9, 2011, 2011, 50000, 8, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MVG1346', 3);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MVG1346', 1);
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('MVG1346', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MVG1346', 10);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('MVG1346', 1);
INSERT INTO Proprietario (cd_localidade, nm_proprietario, ds_logradouro, ds_complemento, ds_bairro, nr_telefone, ds_email, sg_uf) VALUES (10, 'Geralt de Rivia', 'Rua Colômbia', '', 'Ponta Aguda', '(27) 3426-7745', 'geralt.de.riviaoutlook.com', 'SC');
INSERT INTO Veiculo (nr_placa, cd_cor, cd_proprietario, cd_modelo, nr_ano_fab, nr_ano_mod, qt_km_rodado, qt_portas, ds_observacao) VALUES ('HZC3547', 3, 10, 10, 2019, 2014, 70000, 6, 'Perfeito para a família');
INSERT INTO Veiculo_Combustivel (nr_placa, cd_combustivel) VALUES ('HZC3547', 3);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 5);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 7);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 2);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 4);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 1);
INSERT INTO veiculo_acessorio (nr_placa, cd_acessorio) VALUES ('HZC3547', 9);


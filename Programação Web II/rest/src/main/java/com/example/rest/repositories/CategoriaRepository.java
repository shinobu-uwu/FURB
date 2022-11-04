package com.example.rest.repositories;

import com.example.rest.entities.Categoria;
import org.springframework.data.repository.CrudRepository;

public interface CategoriaRepository extends CrudRepository<Categoria, Integer> {
    Categoria findCategoriaByNome(String nome);
}

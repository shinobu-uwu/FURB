package com.example.rest.repositories;

import com.example.rest.entities.Categoria;
import org.springframework.data.repository.CrudRepository;

import java.util.Optional;

public interface CategoriaRepository extends CrudRepository<Categoria, Integer> {
    Optional<Categoria> findCategoriaByNome(String nome);

    Iterable<Categoria> findCategoriasByNome(String nome);
}

package com.example.rest.repositories;

import com.example.rest.entities.Autor;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface AutorRepository extends CrudRepository<Autor, Integer> {
    Iterable<Autor> findAll();
    Autor save(Autor autor);
    Optional<Autor> findByNome(String name);

    Optional<Autor> findByDescricao(String desc);
}

package com.example.rest.repositories;

import com.example.rest.entities.Autor;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface AutorRepository extends CrudRepository<Autor, Integer> {
    Iterable<Autor> findAll();
}

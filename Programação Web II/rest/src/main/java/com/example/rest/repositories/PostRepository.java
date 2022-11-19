package com.example.rest.repositories;

import com.example.rest.entities.Categoria;
import com.example.rest.entities.Post;
import org.springframework.data.repository.CrudRepository;

public interface PostRepository extends CrudRepository<Post, Integer> {
    Iterable<Post> findAll();
    Iterable<Post> findAllByTituloContaining(String titulo);
    Iterable<Post> findAllByTextoContaining(String texto);
}

package com.example.rest.controllers;

import com.example.rest.dao.InsercaoPostDAO;
import com.example.rest.entities.Autor;
import com.example.rest.entities.Categoria;
import com.example.rest.entities.Post;
import com.example.rest.repositories.AutorRepository;
import com.example.rest.repositories.CategoriaRepository;
import com.example.rest.repositories.PostRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.Optional;

@RestController
public class PostController {
    private final AutorRepository autorRepository;
    private final PostRepository postRepository;
    private final CategoriaRepository categoriaRepository;

    public PostController(PostRepository postRepository, CategoriaRepository categoriaRepository, AutorRepository autorRepository) {
        this.postRepository = postRepository;
        this.categoriaRepository = categoriaRepository;
        this.autorRepository = autorRepository;
    }

    @GetMapping("/posts")
    Iterable<Post> getPosts() {
        return postRepository.findAll();
    }

    @GetMapping("/posts/{id}")
    Post getPost(@PathVariable Integer id) {
        Optional<Post> post = postRepository.findById(id);

        if (post.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o post");
        }

        return post.get();
    }

    @PostMapping("/posts")
    Post getPosts(@RequestBody InsercaoPostDAO postDAO) {
        Optional<Autor> autor = autorRepository.findById(postDAO.getAutorId());

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o autor");
        }

        return postRepository.save(new Post(postDAO.getTitulo(), postDAO.getTexto(), autor.get(), postDAO.getCategorias()));
    }

    @PostMapping("/posts/{postId}/categoria/{categoriaId}")
    Post addCategoria(@PathVariable(required = true) Integer postId, @PathVariable(required = true) Integer categoriaId) {
        Optional<Post> post = postRepository.findById(postId);
        Optional<Categoria> categoria = categoriaRepository.findById(categoriaId);

        if (post.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Não foi possível encontrar o post");
        }

        if (categoria.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Não foi possível encontrar a categoria");
        }

        post.get().addCategoria(categoria.get());

        return postRepository.save(post.get());
    }
}

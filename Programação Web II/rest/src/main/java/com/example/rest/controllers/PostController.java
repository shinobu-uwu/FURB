package com.example.rest.controllers;

import com.example.rest.entities.Categoria;
import com.example.rest.entities.Post;
import com.example.rest.repositories.CategoriaRepository;
import com.example.rest.repositories.PostRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.Optional;

@RestController
public class PostController {
    private PostRepository postRepository;
    private CategoriaRepository categoriaRepository;

    public PostController(PostRepository postRepository, CategoriaRepository categoriaRepository) {
        this.postRepository = postRepository;
        this.categoriaRepository = categoriaRepository;
    }

    @GetMapping("/posts")
    Iterable<Post> getPosts() {
        return postRepository.findAll();
    }

    @PostMapping("/posts")
    Post getPosts(@RequestBody Post post) {
        return postRepository.save(post);
    }

    @PostMapping("/posts/{postId}/categoria/{categoriaId}")
    Post addCategoria(@PathVariable(required = true) Integer postId, @PathVariable(required = true) Integer categoriaId) {
        Optional<Post> post = postRepository.findById(postId);
        Optional<Categoria> categoria = categoriaRepository.findById(categoriaId);

        if (post.isEmpty() || categoria.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Não foi possível encontrar o post ou a categoria");
        }

        post.get().addCategoria(categoria.get());

        return postRepository.save(post.get());
    }
}

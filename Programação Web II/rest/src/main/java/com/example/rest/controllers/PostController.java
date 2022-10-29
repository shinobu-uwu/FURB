package com.example.rest.controllers;

import com.example.rest.entities.Post;
import com.example.rest.repositories.PostRepository;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class PostController {
    private PostRepository postRepository;

    public PostController(PostRepository postRepository) {
        this.postRepository = postRepository;
    }

    @GetMapping("/posts")
    Iterable<Post> getPosts() {
        return postRepository.findAll();
    }
}

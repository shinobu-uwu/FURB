package com.example.rest.controllers;

import com.example.rest.dao.AtualizacaoPostDAO;
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

import java.util.HashSet;
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

    @GetMapping(value = "/posts", params = "titulo")
    Iterable<Post> getPostsByTitulo(@RequestParam String titulo) {
        return postRepository.findAllByTituloContaining(titulo);
    }

    @GetMapping(value = "/posts", params = "texto")
    Iterable<Post> getPostsByTexto(@RequestParam String texto) {
        return postRepository.findAllByTextoContaining(texto);
    }

    @PostMapping("/posts")
    Post getPosts(@RequestBody InsercaoPostDAO postDAO) {
        Optional<Autor> autor = autorRepository.findById(postDAO.getAutorId());

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o autor");
        }

        return postRepository.save(new Post(postDAO.getTitulo(), postDAO.getTexto(), getAutor(postDAO.getAutorId()), getCategorias(postDAO.getCategorias())));
    }

    @PostMapping("/posts/{postId}/categoria/{categoriaId}")
    Post addCategoria(@PathVariable Integer postId, @PathVariable Integer categoriaId) {
        Optional<Post> post = postRepository.findById(postId);
        Optional<Categoria> categoria = categoriaRepository.findById(categoriaId);

        if (post.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o post");
        }

        if (categoria.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar a categoria");
        }

        post.get().addCategoria(categoria.get());

        return postRepository.save(post.get());
    }

    @DeleteMapping("posts/{id}")
    void deletePost(@PathVariable int id) {
        boolean postExiste = postRepository.existsById(id);

        if (!postExiste) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o post");
        }

        postRepository.deleteById(id);
    }

    @PutMapping("/posts")
    Post updatePost(@RequestBody AtualizacaoPostDAO postDAO) {
        if (postDAO.getId() == null) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "É necessário especificar um id");
        }
        Optional<Post> postAntigo = postRepository.findById(postDAO.getId());

        if (postAntigo.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o post");
        }

        Post post = new Post(postDAO.getTitulo(), postDAO.getTexto(), getAutor(postDAO.getAutorId()), getCategorias(postDAO.getCategorias()));
        post.setId(postDAO.getId());
        post.setDataCriacao(postAntigo.get().getDataCriacao());

        return postRepository.save(post);
    }

    private Autor getAutor(Integer id) {
        Optional<Autor> autor = autorRepository.findById(id);

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o autor");
        }

        return autor.get();
    }

    private HashSet<Categoria> getCategorias(String[] nomes) {
        HashSet<Categoria> categorias = new HashSet<>();

        for (String nome : nomes) {
            Optional<Categoria> categoria = categoriaRepository.findCategoriaByNome(nome);

            if (categoria.isEmpty()) {
                throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar a categoria " + nome);
            }

            categorias.add(categoria.get());
        }

        return categorias;
    }
}

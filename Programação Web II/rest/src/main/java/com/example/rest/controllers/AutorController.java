package com.example.rest.controllers;

import com.example.rest.entities.Autor;
import com.example.rest.repositories.AutorRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.Optional;

@RestController
public class AutorController {
    private AutorRepository autorRepository;

    public AutorController(AutorRepository autorRepository) {
        this.autorRepository = autorRepository;
    }

    @GetMapping("/autores")
    Iterable<Autor> getAutores() {
        return autorRepository.findAll();
    }

    @PostMapping("/autores")
    Autor getAutores(@RequestBody Autor autor) {
        return autorRepository.save(autor);
    }

    @GetMapping("/autores?nome={nome}")
    Autor getAutorByNome(@PathVariable String nome) {
        Optional<Autor> autor = autorRepository.findByNome(nome);

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Autor não encontrado");
        }

        return autor.get();
    }

    @GetMapping("/autores/{id}")
    Autor getAutorById(@PathVariable int id) {
        Optional<Autor> autor = autorRepository.findById(id);

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Autor não encontrado");
        }

        return autor.get();
    }


    @DeleteMapping("/autores")
    void DeleteAutor(@RequestBody Autor autor) {
        autorRepository.delete(autor);
    }

    @PutMapping("/autores")
    Autor UpdateAutor(@RequestBody Autor autor) {
        if (autor.getId() == null) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Id está vazio");
        }
        return autorRepository.save(autor);
    }

    @GetMapping("/autores?descricao={descricao}")
    Autor getDesc(@PathVariable String desc) {
        Optional<Autor> autor = autorRepository.findByDescricao(desc);

        if (autor.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Autor não encontrado");
        }

        return autor.get();
    }
}

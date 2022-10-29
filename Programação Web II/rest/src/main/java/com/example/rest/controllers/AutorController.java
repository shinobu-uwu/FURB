package com.example.rest.controllers;

import com.example.rest.entities.Autor;
import com.example.rest.repositories.AutorRepository;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

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
}

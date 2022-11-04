package com.example.rest.controllers;

import com.example.rest.entities.Categoria;
import com.example.rest.repositories.CategoriaRepository;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CategoriaController {
    private CategoriaRepository categoriaRepository;

    public CategoriaController(CategoriaRepository categoriaRepository) {
        this.categoriaRepository = categoriaRepository;
    }

    @GetMapping("/categorias")
    Iterable<Categoria> getAllCategorias() {
        return categoriaRepository.findAll();
    }

    @PostMapping("/categorias")
    Categoria createCategoria(Categoria categoria) {
        return categoriaRepository.save(categoria);
    }
}

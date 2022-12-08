package com.example.rest.controllers;

import com.example.rest.entities.Categoria;
import com.example.rest.repositories.CategoriaRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.Optional;

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
    Categoria createCategoria(@RequestBody Categoria categoria) {
        return categoriaRepository.save(categoria);
    }

    @GetMapping("/categorias/{id}")
    Categoria getCategoria(@PathVariable Integer id) {
        Optional<Categoria> categoria = categoriaRepository.findById(id);

        if (categoria.isEmpty()) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar a categoria");
        }

        return categoria.get();
    }

    @GetMapping("/categorias?nome={nome}")
    Iterable<Categoria> getCategoriaByNome(@PathVariable String nome) {
        System.out.println(nome);
        return categoriaRepository.findCategoriasByNome(nome);
    }

    @DeleteMapping("/categorias/{id}")
    void DeleteCategoria(@PathVariable Integer id) {
        boolean existe = categoriaRepository.existsById(id);

        if (existe) {
            categoriaRepository.deleteById(id);
        } else {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Não foi possível encontrar o a categoria");
        }

    }

    @PutMapping("/categorias")
    Categoria CriarCategoria(@RequestBody Categoria categoria) {
        if (categoria.getId() != null) {
            return categoriaRepository.save(categoria);
        } else {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "O id informado não foi encontrado");
        }
    }
}

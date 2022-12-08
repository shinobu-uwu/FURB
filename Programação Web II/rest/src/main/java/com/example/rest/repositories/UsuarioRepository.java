package com.example.rest.repositories;

import java.util.Optional;

import org.springframework.data.repository.CrudRepository;

import com.example.rest.entities.Usuario;

public interface UsuarioRepository extends CrudRepository<Usuario, Integer> {
	Optional<Usuario> findByUsername(String username);
}

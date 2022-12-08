package com.example.rest.service;

import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.example.rest.entities.Usuario;
import com.example.rest.repositories.UsuarioRepository;

@Service
public class JwtUserService implements UserDetailsService {
	private final UsuarioRepository usuarioRepository;

	public JwtUserService(UsuarioRepository usuarioRepository) {
		this.usuarioRepository = usuarioRepository;
	}

	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Optional<Usuario> usuario = usuarioRepository.findByUsername(username);
		
		if (usuario.isEmpty()) {
			throw new UsernameNotFoundException("User not found with username: " + username);
		}
		
		return usuario.get();
	}
}
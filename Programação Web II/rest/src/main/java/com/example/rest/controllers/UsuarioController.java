package com.example.rest.controllers;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.example.rest.config.SecurityConstantes;
import com.example.rest.dao.UsuarioDao;
import com.example.rest.entities.Usuario;
import com.example.rest.repositories.UsuarioRepository;
import com.example.rest.service.JwtUserService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

import java.util.Date;

@RestController
public class UsuarioController {
    private final AuthenticationManager authenticationManager;
    private final PasswordEncoder passwordEncoder;
    private final UsuarioRepository usuarioRepository;

    public UsuarioController(AuthenticationManager authenticationManager, JwtUserService userDetailsService, PasswordEncoder passwordEncoder, UsuarioRepository usuarioRepository) {
        this.authenticationManager = authenticationManager;
        this.passwordEncoder = passwordEncoder;
        this.usuarioRepository = usuarioRepository;
    }

    @PostMapping(value = "/usuario/registrar")
    public ResponseEntity<?> createUsuario(@RequestBody UsuarioDao usuarioDao) {
        String senha = passwordEncoder.encode(usuarioDao.getSenha());
        Usuario usuario = new Usuario(usuarioDao.getUsername(), senha);
        usuarioRepository.save(usuario);

        return ResponseEntity.created(null).build();
    }

    @PostMapping(value = "/usuario/entrar")
    public String createAuthenticationToken(@RequestBody UsuarioDao usuarioDao) throws Exception {
        try {
            authenticationManager
                    .authenticate(new UsernamePasswordAuthenticationToken(usuarioDao.getUsername(), usuarioDao.getSenha()));

            return JWT.create().withSubject(usuarioDao.getUsername()).withExpiresAt(new Date(System.currentTimeMillis() + SecurityConstantes.VALIDADE)).sign(Algorithm.HMAC512(SecurityConstantes.SECRET.getBytes()));
        } catch (BadCredentialsException e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Usuario ou senha incorretos");
        }
    }
}

package com.example.rest.dao;

import com.fasterxml.jackson.annotation.JsonProperty;

public class UsuarioDao {
	@JsonProperty(value = "username", required = true)
	private String username;
	@JsonProperty(value = "senha", required = true)
	private String senha;

	public UsuarioDao()
	{
		
	}

	public UsuarioDao(String username, String senha) {
		this.setUsername(username);
		this.setSenha(senha);
	}

	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getSenha() {
		return senha;
	}
	public void setSenha(String senha) {
		this.senha = senha;
	}
}

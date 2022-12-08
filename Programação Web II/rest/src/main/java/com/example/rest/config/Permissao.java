package com.example.rest.config;

import org.springframework.security.core.GrantedAuthority;

public class Permissao implements GrantedAuthority {
	private static final long serialVersionUID = 1290381381290389012L;

	@Override
	public String getAuthority() {
		return "Padrão";
	}

}

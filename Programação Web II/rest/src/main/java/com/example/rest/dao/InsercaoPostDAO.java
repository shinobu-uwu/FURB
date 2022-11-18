package com.example.rest.dao;

import com.example.rest.entities.Categoria;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Set;

public class InsercaoPostDAO {
    @JsonProperty(value = "titulo", required = true)
    private String titulo;
    @JsonProperty(value = "texto", required = true)
    private String texto;
    @JsonProperty(value = "texto", defaultValue = "[]")
    private Set<Categoria> categorias;
    @JsonProperty(value = "autor", required = true)
    private Integer autorId;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    @JsonIgnore
    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public Set<Categoria> getCategorias() {
        return categorias;
    }

    public void setCategorias(Set<Categoria> categorias) {
        this.categorias = categorias;
    }

    public Integer getAutorId() {
        return autorId;
    }

    public void setAutorId(Integer autorId) {
        this.autorId = autorId;
    }
}

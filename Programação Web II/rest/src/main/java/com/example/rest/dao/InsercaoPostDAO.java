package com.example.rest.dao;

import com.fasterxml.jackson.annotation.JsonProperty;

public class InsercaoPostDAO {
    @JsonProperty(value = "titulo", required = true)
    private String titulo;
    @JsonProperty(value = "texto", required = true)
    private String texto;
    @JsonProperty(value = "categorias", defaultValue = "[]")
    private String[] categorias;
    @JsonProperty(value = "autor", required = true)
    private Integer autorId;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public String[] getCategorias() {
        return categorias;
    }

    public void setCategorias(String[] categorias) {
        this.categorias = categorias;
    }

    public Integer getAutorId() {
        return autorId;
    }

    public void setAutorId(Integer autorId) {
        this.autorId = autorId;
    }
}

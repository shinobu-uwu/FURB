package com.example.rest.dao;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AtualizacaoPostDAO {
    @JsonProperty(value = "id", required = true)
    private Integer id;
    @JsonProperty(value = "titulo", required = true)
    private String titulo;
    @JsonProperty(value = "texto", required = true)
    private String texto;
    @JsonProperty(value = "categorias", defaultValue = "[]")
    private String[] categorias;
    @JsonProperty(value = "autor", required = true)
    private Integer autorId;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

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

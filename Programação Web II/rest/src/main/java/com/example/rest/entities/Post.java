package com.example.rest.entities;

import javax.persistence.*;
import java.sql.Date;
import java.util.Set;

@Entity
@Table(name = "posts")
public class Post {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    private String titulo;
    private String texto;
    @ManyToOne
    @JoinColumn(name = "autor_id")
    private Autor autor;
    private Date dataCriacao = new Date(System.currentTimeMillis());

    @ManyToMany(targetEntity = Categoria.class)
    @JoinTable(
            name = "post_categoria",
            joinColumns = { @JoinColumn(name = "id_post") },
            inverseJoinColumns = {@JoinColumn(name = "id_categoria")}
    )
    private Set<Categoria> categorias;

    public Post(String titulo, String texto, Autor autor, Set<Categoria> categorias) {
        this.titulo = titulo;
        this.texto = texto;
        this.autor = autor;
        this.categorias = categorias;
    }

    public Post() {

    }

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

    public Autor getAutor() {
        return autor;
    }

    public void setAutor(Autor autor) {
        this.autor = autor;
    }

    public Date getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(Date dataCriacao) {
        this.dataCriacao = dataCriacao;
    }

    public Set<Categoria> getCategorias() {
        return categorias;
    }

    public void setCategorias(Set<Categoria> categorias) {
        this.categorias = categorias;
    }
}

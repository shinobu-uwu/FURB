using Compilador;

var texto =
    "fun main { var lado: int; readln (\"digite o lado do quadrado: \", lado); area = lado * lado; print (area); }";
var lexico = new Lexico(texto);
var sintatico = new Sintatico();
var semantico = new Semantico();

sintatico.Parse(lexico, semantico);
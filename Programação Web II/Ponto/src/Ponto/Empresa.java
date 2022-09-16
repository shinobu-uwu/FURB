package Ponto;

import java.util.ArrayList;

public class Empresa {
    private String nome;
    ArrayList<Funcionario> funcionarios = new ArrayList<Funcionario>();

    public Empresa() {
    }

    public Empresa(String nome) {
        this.nome = nome;
    }

    public Empresa(String nome, ArrayList<Funcionario> func) {
        this.nome = nome;
        this.funcionarios = func;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public ArrayList<Funcionario> getFuncionarios() {
        return funcionarios;
    }

    public void addFuncionario(Funcionario func) {
        funcionarios.add(func);
    }

    public void RemoveFuncionario(Funcionario func) {
        for (int i = 0; i < funcionarios.size(); i++) {
            if (funcionarios.get(i).getNome().equals(func.getNome())) {
                funcionarios.remove(i);
            }
        }
    }
}

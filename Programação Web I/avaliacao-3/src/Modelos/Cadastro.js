export class Cadastro {
    constructor(id, nome, departamento, endereco, email) {
        this.id = id;
        this.nome = nome;
        this.departamento = departamento;
        this.endereco = endereco;
        this.email = email;
    }

    getNome() {
        return this.nome;
    }

    getEmail() {
        return this.email;
    }
}
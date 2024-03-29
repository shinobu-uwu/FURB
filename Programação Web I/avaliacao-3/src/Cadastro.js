import {Button, Form, Table} from "react-bootstrap";

export default function Cadastro() {
    return (
        <>
            <h1>Cadastar produto</h1>
            <Form className="w-50 mx-auto">
                <div className="row mb-3">
                    <div className="col">
                        <Form.Control type="text" placeholder="Código de barras" id="codigo-barras"/>
                    </div>
                    <div className="col">
                        <Form.Control type="text" placeholder="Nome do produto" id="nome"/>
                    </div>
                </div>
                <div className="row mb-3">
                    <div className="col">
                        <Form.Control type="text" placeholder="Marca" id="marca"/>
                    </div>
                    <div className="col">
                        <Form.Control type="number" placeholder="Quantidade em estoque" min="0" id="quantidade"/>
                    </div>
                </div>
                <div className="w-25 mx-auto">
                    <Button type="button" className="mb-2" onClick={cadastrarProduto}>Cadastrar produto</Button>
                    <a className="btn btn-dark" href="/Relatorio">Relatório</a>
                </div>
            </Form>
            <Table bordered className="mt-3">
                <thead>
                <tr>
                    <th>Código de barras</th>
                    <th>Nome do produto</th>
                    <th>Nome da marca</th>
                    <th>Quantidade em estoque</th>
                    <th>Editar</th>
                    <th>Excluir</th>
                </tr>
                </thead>
                <tbody id="produtos">
                {Object.keys(localStorage).map((key) => {
                    const produto = JSON.parse(localStorage.getItem(key));
                    return (
                        <tr id={produto.codigoBarras}>
                            <td>{produto.codigoBarras}</td>
                            <td>{produto.nome}</td>
                            <td>{produto.marca}</td>
                            <td>{produto.quantidade}</td>
                            <td><Button variant="success"
                                        onClick={() => editarProduto(produto.codigoBarras)}></Button></td>
                            <td><Button variant="danger"
                                        onClick={() => excluirProduto(produto.codigoBarras)}></Button></td>
                        </tr>
                    );
                })}
                </tbody>
            </Table>
        </>
    );
}

function getProduto() {
    return {
        codigoBarras: document.getElementById('codigo-barras').value,
        nome: document.getElementById('nome').value,
        marca: document.getElementById('marca').value,
        quantidade: document.getElementById('quantidade').value
    };
}

function cadastrarProduto() {
    const produto = getProduto();
    localStorage.setItem(produto.codigoBarras, JSON.stringify(produto));
    const bodyTabela = document.getElementById('produtos');

    // Colocamos o id da tr como o código de barras para conseguirmos achar para excluir e editar o registro
    bodyTabela.innerHTML += `
                    <tr id="${produto.codigoBarras}">
                        <td>${produto.codigoBarras}</td>
                        <td>${produto.nome}</td>
                        <td>${produto.marca}</td>
                        <td>${produto.quantidade}</td>
                        <td><button class="btn btn-success" onclick="editarProduto('${produto.codigoBarras}')"></Button></td>
                        <td><button class="btn btn-danger" onclick="excluirProduto('${produto.codigoBarras}')"></button></td>
                    </tr>
                        `;
}

function editarProduto(codigoBarras) {
    let tableRow = document.getElementById(codigoBarras);
    const produto = getProduto();

    tableRow.id = produto.codigoBarras;
    tableRow.innerHTML = `
                        <td>${produto.codigoBarras}</td>
                        <td>${produto.nome}</td>
                        <td>${produto.marca}</td>
                        <td>${produto.quantidade}</td>
                        <td>
                            <button class="btn btn-success" onclick="editarProduto('${produto.codigoBarras}')"></button>
                        </td>
                        <td>
                            <button class="btn btn-danger" onclick="excluirProduto('${produto.codigoBarras}')"></button>
                        </td>
                            `;
}

function excluirProduto(codigoBarras) {
    localStorage.removeItem(codigoBarras);
    document.getElementById(codigoBarras).remove();
}

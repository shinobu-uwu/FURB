package Ponto;

import Exceptions.ParametroInvalidoException;

import java.util.ArrayList;

public class FuncionarioControle {
    private EmpresaControle empresaControle = new EmpresaControle();

    public void CriarFuncionario(String nome, String nomeEmpresa) throws Exception {
        if (nome.isEmpty()) {
            throw new ParametroInvalidoException();
        }
        Empresa emp = empresaControle.Ler(nomeEmpresa);
        emp.addFuncionario(new Funcionario(nome));
    }

    public void Editar(Funcionario funcionario, String nome) throws ParametroInvalidoException {
        if (nome.isEmpty()) {
            throw new ParametroInvalidoException();
        }
        funcionario.setNome(nome);
    }

    public void Delete(Empresa empresa, Funcionario func) {
        empresa.RemoveFuncionario(func);
    }

    public Funcionario Ler(String nome, String nomeEmpresa) throws Exception {
        if (nome.isEmpty()) {
            throw new ParametroInvalidoException();
        }

        Empresa emp = empresaControle.Ler(nomeEmpresa);

        for (Funcionario func : emp.getFuncionarios()) {
            if (func.getNome().equals(nome)) {
                return func;
            }

        }

        throw new Exception();
    }

    public Empresa[] listarEmpresas(Funcionario funcionario) {
        Empresa[] empresas = empresaControle.lerTodas();
        ArrayList<Empresa> empresasResultado = new ArrayList<Empresa>();

        for (Empresa empresa : empresas) {
            for (Funcionario funcionarioEmpresa : empresa.getFuncionarios()) {
                if (funcionarioEmpresa.getNome().equals(funcionario.getNome())) {
                    empresasResultado.add(empresa);
                }
            }
        }

        return empresasResultado.toArray(new Empresa[0]);
    }
}

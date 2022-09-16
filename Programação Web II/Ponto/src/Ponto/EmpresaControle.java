package Ponto;

import java.util.ArrayList;

import Exceptions.NaoEncontradoException;
import Exceptions.ParametroInvalidoException;

import javax.xml.bind.ValidationException;

public class EmpresaControle {
    private static ArrayList<Empresa> empresas = new ArrayList<Empresa>();

    public void CriarEmpresa(String nomeEmpresa) throws ParametroInvalidoException {
        if (nomeEmpresa.isEmpty()) {
            throw new ParametroInvalidoException();
        }

        empresas.add(new Empresa(nomeEmpresa));
    }

    public void Editar(Empresa empresa, String nome) throws ParametroInvalidoException {
        if (nome.isEmpty()) {
            throw new ParametroInvalidoException();
        }

        for (Empresa empresaProcura : empresas) {
            if (empresa.getNome().equals(empresaProcura.getNome())) {
                empresaProcura.setNome(nome);
                break;
            }
        }
    }

    public void Delete(String nomeEmpresa) {
        empresas.removeIf(empresa -> empresa.getNome().equals(nomeEmpresa));
    }

    public Empresa Ler(String nome) throws NaoEncontradoException, ParametroInvalidoException {
        if (nome.isEmpty()) {
            throw new ParametroInvalidoException();
        }

        for (Empresa empresa : empresas) {
            if (empresa.getNome().equals(nome)) {
                return empresa;
            }
        }

        throw new NaoEncontradoException();
    }

    public Empresa[] lerTodas() {
        return empresas.toArray(new Empresa[0]);
    }

    public void alterarFuncionario(Empresa empresa, Funcionario funcionario, String nome) throws ValidationException {
        if (nome.isEmpty()) {
            throw new ValidationException("Nome não pode ser em branco");
        }

        for (Empresa empresaProcura : empresas) {
            if (empresaProcura.getNome().equals(empresa.getNome())) {
                empresa = empresaProcura;
                break;
            }
        }

        for (Funcionario funcionarioProcura : empresa.getFuncionarios()) {
            if (funcionarioProcura.getNome().equals(funcionario.getNome())) {
                funcionarioProcura.setNome(nome);
            }
        }
    }

    public void removeFuncionario(Empresa empresa, Funcionario funcionario) {
        for (Empresa empresaProcura : empresas) {
            if (empresaProcura.getNome().equals(empresa.getNome())) {
                empresa = empresaProcura;
                break;
            }
        }

        for (int i = 0; i < empresa.getFuncionarios().size(); i++) {
            if (empresa.getFuncionarios().get(i).getNome().equals(funcionario.getNome())) {
                empresa.getFuncionarios().remove(i);
                break;
            }
        }
    }
}

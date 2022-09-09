package Server;

import Exceptions.ParametroInvalidoException;
import Ponto.Empresa;
import Ponto.Funcionario;
import Ponto.FuncionarioControle;

import javax.jws.WebService;

@WebService(name = "funcionario", endpointInterface = "Server.FuncionarioServer")
public class FuncionarioServerImpl implements FuncionarioServer {
    private FuncionarioControle funcionarioControle = new FuncionarioControle();

    @Override
    public void criar(String nomeFuncionario, String nomeEmpresa) throws Exception {
        funcionarioControle.CriarFuncionario(nomeFuncionario, nomeEmpresa);
    }

    @Override
    public Funcionario ler(String nomeFuncionario, String nomeEmpresa) throws Exception {
        return funcionarioControle.Ler(nomeFuncionario, nomeEmpresa);
    }

    @Override
    public void atualizar(Funcionario funcionario, String nome) throws ParametroInvalidoException {
        funcionarioControle.Editar(funcionario, nome);
    }

    @Override
    public void deletar(Empresa empresa, Funcionario funcionario) {
        funcionarioControle.Delete(empresa, funcionario);
    }

    @Override
    public Empresa[] listarEmpresas(Funcionario funcionario) {
        return funcionarioControle.listarEmpresas(funcionario);
    }
}

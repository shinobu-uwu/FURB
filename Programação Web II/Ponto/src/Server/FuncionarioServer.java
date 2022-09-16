package Server;


import Exceptions.ParametroInvalidoException;
import Ponto.Empresa;
import Ponto.Funcionario;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.xml.bind.ValidationException;

@WebService
@SOAPBinding(style = SOAPBinding.Style.RPC)
public interface FuncionarioServer {
    @WebMethod
    void criar(String nomeFuncionario, String nomeEmpresa) throws Exception;

    @WebMethod
    Funcionario ler(String nomeFuncionario, String nomeEmpresa) throws Exception;

    @WebMethod
    void atualizar(Funcionario funcionario, Empresa empresa, String nome) throws ParametroInvalidoException, ValidationException;

    @WebMethod
    void deletar(Empresa empresa, Funcionario funcionario) throws Exception;

    @WebMethod
    Empresa[] listarEmpresas(Funcionario funcionario);
}
package Server;

import Exceptions.ParametroInvalidoException;
import Ponto.Empresa;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;
import java.util.ArrayList;

@WebService
@SOAPBinding(style = Style.RPC)
public interface EmpresaServer {
    @WebMethod
    void criar(String nomeEmpresa) throws ParametroInvalidoException;

    @WebMethod
    Empresa ler(String nomeEmpresa) throws Exception;

    @WebMethod
    Empresa[] lerTodas();

    @WebMethod
    void atualizar(Empresa empresa, String nome) throws ParametroInvalidoException;

    @WebMethod
    void deletar(String nomeEmpresa);
}

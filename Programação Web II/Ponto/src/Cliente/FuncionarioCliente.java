package Cliente;

import java.net.MalformedURLException;
import java.net.URL;

import javax.xml.namespace.QName;
import javax.xml.ws.Service;

import Exceptions.ParametroInvalidoException;
import Ponto.Empresa;
import Ponto.Funcionario;
import Server.EmpresaServer;
import Server.FuncionarioServer;

public class FuncionarioCliente {
	private final FuncionarioServer funcionarioServer;

	public FuncionarioCliente() throws MalformedURLException {
		URL url = new URL("http://127.0.0.1:9876/funcionario?wsdl");
		QName qname = new QName("http://Server/", "FuncionarioServerImplService");
		Service service = Service.create(url, qname);
		funcionarioServer = service.getPort(FuncionarioServer.class);
	}

	public void criar(String nomeFuncionario, String nomeEmpresa) throws Exception {
		funcionarioServer.criar(nomeFuncionario, nomeEmpresa);
	}

	public Funcionario ler(String nomeFuncionario, String nomeEmpresa) throws Exception {
		return funcionarioServer.ler(nomeFuncionario, nomeEmpresa);
	}

	public void atualizar(Funcionario funcionario, String nome) throws ParametroInvalidoException {
		funcionarioServer.atualizar(funcionario, nome);
	}

	public Empresa[] listarEmpresas(Funcionario funcionario) {
		return funcionarioServer.listarEmpresas(funcionario);
	}
	
}

import Cliente.EmpresaCliente;
import Cliente.FuncionarioCliente;
import Ponto.Empresa;
import Ponto.Funcionario;
import Server.EmpresaServerImpl;
import Server.FuncionarioServerImpl;

import javax.xml.ws.Endpoint;

public class Main {
    public static void main(String[] args) throws Exception {
        System.out.println("Iniciando o servidor");
        Endpoint.publish(
                "http://127.0.0.1:9876/empresa",
                new EmpresaServerImpl()
        );

        Endpoint.publish(
                "http://127.0.0.1:9876/funcionario",
                new FuncionarioServerImpl()
        );

        EmpresaCliente cliente = new EmpresaCliente();
        cliente.adicionar("Abc");
        cliente.adicionar("Dfg");
        Empresa empresa1 = cliente.ler("Abc");
        cliente.atualizar(empresa1, "Piriquito");
        empresa1 = cliente.ler("Piriquito");
        Empresa empresa2 = cliente.ler("Dfg");
        Empresa[] empresas = cliente.lerTodas();

        for (Empresa empresa : empresas) {
            System.out.println(empresa.getNome());
        }

        cliente.deletar(empresa2.getNome());

        FuncionarioCliente funcionarioCliente = new FuncionarioCliente();
        funcionarioCliente.criar("Matheus", "Piriquito");
        funcionarioCliente.criar("Leonardo", "Piriquito");
        Funcionario funcionario = funcionarioCliente.ler("Matheus", "Piriquito");
        funcionarioCliente.atualizar(funcionario, empresa1, "Luciana");
        funcionario = funcionarioCliente.ler("Luciana", "Piriquito");

        for (Empresa empresa : funcionarioCliente.listarEmpresas(funcionario)) {
            System.out.println(empresa.getNome());
        }

        funcionarioCliente.remove(funcionario, empresa1);

        for (Empresa empresa : funcionarioCliente.listarEmpresas(funcionario)) {
            System.out.println(empresa.getNome());
        }
    }
}

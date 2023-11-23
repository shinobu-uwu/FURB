import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;

public class Main {
    public static void main(String[] args) {
        try {
            CalculadoraServerInterface server = new CalculadoraServerInterfaceImpl();
            Registry registry = LocateRegistry.getRegistry();
            registry.rebind("CalculadoraServerInterfaceImpl", server);
            System.out.println("Servidor Calculadora " + server +
                    " registrado e pronto para aceitar solicitações.");
        }
        catch (Exception ex) {
            System.out.println("Houve um erro: " + ex.getMessage());
        }
    }
}

interface CalculadoraServerInterface  {
    public int somar(int a, int b) throws RemoteException;
}

class CalculadoraServerInterfaceImpl extends UnicastRemoteObject implements CalculadoraServerInterface {
    public CalculadoraServerInterfaceImpl() throws RemoteException {
    }

    public int somar(int a, int b) throws RemoteException {
        System.out.println("A: " + a + ", B: " + b + ", A + B: " + a + b);
        return a + b;
    }
}

import java.sql.Date;
import java.text.SimpleDateFormat;

public class Main {
    public static void main(String[] args) {
        Servidor servidor = new Servidor(1700751600);
        Cliente[] clientes = {new Cliente(1700752200), new Cliente(1700752800), new Cliente(1700751000)};

        System.out.println("Antes do algoritmo:");
        System.out.println("Data do servidor: " + formataData(servidor.getHorario()));

        for (int i = 0; i < clientes.length; i++) {
            Cliente cliente = clientes[i];
            System.out.println("Cliente " + (i + 1) + ": " + formataData(cliente.getHorario()));
        }

        servidor.berkeley(clientes);

        System.out.println("Após o algoritmo:");
        System.out.println("Data do servidor: " + formataData(servidor.getHorario()));

        for (int i = 0; i < clientes.length; i++) {
            Cliente cliente = clientes[i];
            System.out.println("Cliente " + (i + 1) + ": " + formataData(cliente.getHorario()));
        }
    }

    private static String formataData(long timestamp) {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

        return sdf.format(new Date(timestamp * 1000));  // date espera a timestamp em milisegundos
    }
}
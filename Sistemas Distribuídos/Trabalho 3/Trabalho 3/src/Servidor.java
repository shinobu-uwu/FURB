import java.security.Timestamp;
import java.util.Date;

public class Servidor {
    private long horario;  // horário em timestamp

    public Servidor(long horario) {
        this.horario = horario;
    }

    public long getHorario() {
        return horario;
    }

    public void berkeley(Cliente[] clientes) {
        long total = horario;

        for (Cliente cliente : clientes) {
            total += cliente.getHorario();
        }

        long media = total / (clientes.length + 1);

        for (Cliente cliente : clientes) {
            cliente.ajustaHorario(media - cliente.getHorario());
        }

        horario += media - horario;
    }
}

public class Cliente {
    private long horario;  // horário em timestamp

    public Cliente(long horario) {
        this.horario = horario;
    }

    public long getHorario() {
        return horario;
    }

    public void ajustaHorario(long ajuste) {
        horario += ajuste;
    }
}

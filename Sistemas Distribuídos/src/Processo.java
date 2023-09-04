public class Processo {
    public long id;

    public Processo(long id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "Processo " + id;
    }
}

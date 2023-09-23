import java.util.*;

public class Main {
    private  static final List<Processo> processos = Collections.synchronizedList(new ArrayList<>());
    private static Processo coordenador;
    private static long id = 1;
    private static boolean temEleicao = false;

    public static void main(String[] args) {
        Thread t1 = new Thread(Main::addProcesso);
        Thread t2 = new Thread(Main::removeCoordenador);
        Thread t3 = new Thread(Main::inativaProcesso);
        Thread t4 = new Thread(Main::fazEleicao);

        Scanner scanner = new Scanner(System.in);
        t1.start();
        t2.start();
        t3.start();
        t4.start();

        scanner.nextLine();
    }

    private static void addProcesso() {
        try {
            while (true) {
                Thread.sleep(30_000);
                processos.add(new Processo(id++));
                System.out.println(processos);

                if (coordenador != null) {
                    System.out.println("Lider: " + coordenador.id);
                }
            }
        } catch (Exception e) {
            System.out.println("Exception!!! " + e.getMessage());
            e.printStackTrace();
        }
    }

    private static void removeCoordenador() {
        try {
            while (true) {
                Thread.sleep(100_000);
                processos.remove(coordenador);
                coordenador = null;
                System.out.println(processos);

                if (coordenador != null) {
                    System.out.println("Lider: " + coordenador.id);
                }
            }
        } catch (Exception e) {
            System.out.println("Exception!!! " + e.getMessage());
            e.printStackTrace();
        }
    }

    private static void inativaProcesso() {
        try {
            Random random = new Random();
            while (true) {
                Thread.sleep(80_000);
                int n = random.nextInt(processos.size());
                Processo processo = processos.remove(n);

                if (coordenador != null && processo.id == coordenador.id) {
                    coordenador = null;
                }

                System.out.println(processos);
                if (coordenador != null) {
                    System.out.println("Lider: " + coordenador.id);
                }
            }
        } catch (Exception e) {
            System.out.println("Exception!!! " + e.getMessage());
            e.printStackTrace();
        }
    }

    private static void fazEleicao() {
        try {
            Random random = new Random();
            while (true) {
                Thread.sleep(25000);

                if (temEleicao || coordenador != null || processos.isEmpty()) {
                    continue;
                }

                temEleicao = true;
                int n = random.nextInt(processos.size());
                Processo requisitor = processos.get(n);
                Processo novoCoordenador = requisitor;

                for (Processo processo : processos) {
                    if (processo.id > requisitor.id) {
                        novoCoordenador = processo;
                    }
                }

                coordenador = novoCoordenador;
                temEleicao = false;
                System.out.println(processos);
                System.out.println("Novo lider: " + coordenador.id);
            }
        } catch (Exception e) {
            System.out.println("Exception!!! " + e.getMessage());
            e.printStackTrace();
        }
    }
}

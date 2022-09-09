// Matheus Filipe dos Santos Reinert

import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        int[][] grafo = {{1, 0}, {0, 1}};
        System.out.println(tipoDoGrafo(grafo));
    }

    private static String tipoDoGrafo(int[][] grafo) {
        ArrayList<String> tipos = new ArrayList<>();

        // Para um gráfico não dirigido precisamos garantir que a matriz seja simétrica
        for (int i = 0; i < grafo.length; i++) {
            for (int j = 0; j < grafo[i].length; j++) {
                if (grafo[i][j] != grafo[j][i]) {
                    tipos.add("Dirigido");
                }
            }
        }
        tipos.add("Não dirigido");

        return String.join(", ", tipos);
    }
}

// Matheus Filipe dos Santos Reinert

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

public class Main {
    public static void main(String[] args) {
        int[][] grafo = {{0, 1}, {1, 0}};
        int[][] grafo2 = {{2, 0, 3}, {3, 1, 1}, {1, 1, 1}};
        int[][] grafo3 = {{0, 1, 1}, {1, 0, 1}, {1, 1, 0}};

        System.out.println(tipoDoGrafo(grafo));
        System.out.println(arestasDoGrafo(grafo));
        System.out.println(grausDoVertice(grafo));
        System.out.println("------------------------------------------");

        System.out.println(tipoDoGrafo(grafo2));
        System.out.println(arestasDoGrafo(grafo2));
        System.out.println(grausDoVertice(grafo2));
        System.out.println("------------------------------------------");

        System.out.println(tipoDoGrafo(grafo3));
        System.out.println(arestasDoGrafo(grafo3));
        System.out.println(grausDoVertice(grafo3));
    }

    private static String tipoDoGrafo(int[][] grafo) {
        ArrayList<String> tipos = new ArrayList<>();
        boolean multigrafo = false;
        boolean regular = true;
        boolean completo = true;
        boolean nulo = true;

        tipos.add(isDirigido(grafo) ? "Dirigido" : "Não dirigido");

        // Para determinar se o grafo é simples a diagonal principal precisa ser compostas de 0
        // e o restante da matriz pode conter apenas 0 ou 1
        for (int i = 0; i < grafo.length; i++) {
            for (int j = 0; j < grafo[i].length; j++) {
                if (i == j && grafo[i][j] != 0) {
                    multigrafo = true;
                    break;
                }

                if (grafo[i][j] > 1) {
                    multigrafo = true;
                    break;
                }
            }
        }
        tipos.add(multigrafo ? "Multigrafo" : "Simples");

        // Para determinar se um grafo é regular ou não precisamos garantir que o somatório
        // das linhas da matriz sempre seja o mesmo
        int somatorio = Arrays.stream(grafo[0]).sum();

        for (int i = 1; i < grafo.length; i++) {
            if (Arrays.stream(grafo[i]).sum() != somatorio) {
                regular = false;
            }
        }

        if (regular) {
            tipos.add("Regular");
        }

        // Para determinar se um grafo é completo precisamos garantir que a diagonal principal seja
        // composta apenas por 0s e o resto da matriz por 1s
        for (int i = 0; i < grafo.length; i++) {
            for (int j = 0; j < grafo[i].length; j++) {
                if (i == j && grafo[i][j] != 0) {
                    completo = false;
                    break;
                }

                if (i != j && grafo[i][j] != 1) {
                    completo = false;
                    break;
                }
            }
        }

        if (completo) {
            tipos.add("Completo");
        }

        // Para determinar se um grafo é nulo precisamos garantir que todos os elementos da matriz sejam 0
        for (int i = 0; i < grafo.length; i++) {
            for (int j = 0; j < grafo[i].length; j++) {
                if (grafo[i][j] != 0) {
                    nulo = false;
                    break;
                }
            }
        }

        if (nulo) {
            tipos.add("Nulo");
        }

        if (isBipartido(grafo)) {
            tipos.add("Bipartido");
        }

        return String.join(", ", tipos);
    }

    private static boolean isDirigido(int[][] grafo) {
        boolean dirigido = false;

        // Para um gráfico não dirigido precisamos garantir que a matriz seja simétrica
        for (int i = 0; i < grafo.length; i++) {
            for (int j = 0; j < grafo[i].length; j++) {
                if (grafo[i][j] != grafo[j][i]) {
                    dirigido = true;
                    break;
                }
            }
        }

        return dirigido;
    }

    private static boolean isBipartido(int[][] grafo) {
        int[] cores = new int[grafo.length];

        for (int i = 0; i < grafo.length; ++i) {
            cores[i] = -1;
        }

        cores[0] = 1;

        // Pilha com o número dos vétrices
        ArrayList<Integer> nVertices = new ArrayList<>();
        nVertices.add(0);

        while (nVertices.size() != 0) {
            int u = nVertices.remove(0);

            // Se tiver laço não é bipartido
            if (grafo[u][u] == 1)
                return false;

            for (int v = 0; v < grafo.length; ++v) {
                // Se não tiver aresta dupla ou laço e não estiver inicializado com cor,
                // inicializa e adiciona nos vértices para processar
                if (grafo[u][v] == 1 && cores[v] == -1) {
                    cores[v] = 1 - cores[u];
                    nVertices.add(v);
                // Se possuir a cor que já existe não é bipartido
                } else if (grafo[u][v] == 1 && cores[v] == cores[u])
                    return false;
            }
        }

        return true;
    }

    private static String arestasDoGrafo(int[][] grafo) {
        ArrayList<String> arestas = new ArrayList<>();

        // caso o grafo não seja dirigido precisamos analisar apenas da diagonal principal para cima
        if (isDirigido(grafo)) {
            for (int i = 0; i < grafo.length; i++) {
                for (int j = 0; j < grafo[i].length; j++) {
                    // Adicionamos a aresta quantas vezes ela aparecer
                    for (int k = 0; k < grafo[i][j]; k++) {
                        arestas.add("(V" + (i + 1) + ", V" + (j + 1) + ")");
                    }
                }
            }
        } else {
            for (int i = 0; i < grafo.length; i++) {
                for (int j = i; j < grafo[i].length; j++) {
                    // Adicionamos a aresta quantas vezes ela aparecer
                    for (int k = 0; k < grafo[i][j]; k++) {
                        arestas.add("(V" + (i + 1) + ", V" + (j + 1) + ")");
                    }
                }
            }
        }

        String conjuntoArestas = String.join(", ", arestas);
        return "Quantidade de arestas: " + arestas.size() + "\nConjunto de arestas: { " + conjuntoArestas + " }";
    }


    private static String grausDoVertice(int[][] grafo) {
        ArrayList<String> sequenciaDeGraus = new ArrayList<>();
        String resultado = "";

        for (int i = 0; i < grafo.length; i++) {
            String soma = String.valueOf(Arrays.stream(grafo[i]).sum());
            sequenciaDeGraus.add(soma);
        }

        for (int i = 0; i < sequenciaDeGraus.size(); i++) {
            resultado += "V" + (i + 1) + ": Grau " + sequenciaDeGraus.get(i) + "\n";
        }

        Collections.sort(sequenciaDeGraus);
        resultado += "Sequência de graus: " + String.join(", ", sequenciaDeGraus);

        return resultado;
    }
}

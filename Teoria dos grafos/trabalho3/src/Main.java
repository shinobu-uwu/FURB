// Matheus Filipe dos Santos Reinert

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Main {
    public static void main(String[] args) throws IOException {
        FileReader fileReader = new FileReader("“C:\\temp\\entrada.in");
        String entrada = "";
        int c;

        while ((c = fileReader.read()) != -1) {
            entrada += (char) c;
        }

        fileReader.close();
        String[] linhas = entrada.toString().split("\\r?\\n");
        int grau = Integer.parseInt(linhas[0].split(" ")[0]);
        int nArestas = Integer.parseInt(linhas[0].split(" ")[1]);

        int[][] grafo = new int[grau][grau];
        int[][] matrizCusto = new int[grau][grau];

        // Inicializar matriz de custo com "infinito"
        for (int i = 0; i < grau; i++) {
            for (int j = 0; j < grau; j++) {
                matrizCusto[i][j] = Integer.MAX_VALUE;
            }
        }

        for (int i = 1; i <= nArestas; i++) {
            String[] parametros = linhas[i].split(" ");
            int u = Integer.parseInt(parametros[0]);
            int v = Integer.parseInt(parametros[1]);
            int w = Integer.parseInt(parametros[2]);

            // como não estamos trabalhando com um digrafo temos que (u,v) = (v,u)
            grafo[u - 1][v - 1] += 1;
            grafo[v - 1][u - 1] += 1;
            matrizCusto[u - 1][v - 1] = w;
            matrizCusto[v - 1][u - 1] = w;
        }

        // Algorítmo de Prim
        boolean[] visitados = new boolean[grau];
        int custoMinimo = 0;
        visitados[0] = true;

        for (int k = 0; k < grau - 1; k++) {
            int min = Integer.MAX_VALUE;
            // armazenar o vértice com o menor caminho
            int x = -1;
            int y = -1;

            for (int i = 0; i < grau; i++) {
                for (int j = 0; j < grau; j++) {
                    if (matrizCusto[i][j] < min) {
                        if (ehArestaValida(i, j, visitados)) {
                            min = matrizCusto[i][j];
                            x = i;
                            y = j;
                        }
                    }
                }
            }

            if (x != -1 && y != -1) {
                custoMinimo += min;
                visitados[y] = true;
                visitados[x] = true;
            }
        }

        System.out.println(custoMinimo);
    }

    private static boolean ehArestaValida(int u, int v, boolean[] inMST) {
        if (u == v) return false;
        if (!inMST[u] && !inMST[v]) return false;
        else return !inMST[u] || !inMST[v];
    }
}

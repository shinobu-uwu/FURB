using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;
using CG_Biblioteca;

namespace gcgcg;

internal class Spline : Objeto
{
    public List<Ponto4D> PontosControle { get; set; }
    private const int NumeroPontos = 1000;

    public Spline(Objeto refPai, ref char rotulo) : base(refPai, ref rotulo)
    {
    }

    public Spline(Objeto refPai, ref char rotulo, List<Ponto4D> pontosControle) : base(refPai, ref rotulo)
    {
        PontosControle = pontosControle;
        PrimitivaTipo = PrimitiveType.Lines;
        Atualizar();
    }

    public void Atualizar()
    {
        PontosLimpar();
        
        foreach (var ponto in CalcularPontosCurvaBezier())
        {
            PontosAdicionar(ponto);
        }

        ObjetoAtualizar();
    }

    private List<Ponto4D> CalcularPontosCurvaBezier()
    {
        var points = new List<Ponto4D>();

        for (var i = 0; i <= NumeroPontos; i++)
        {
            var t = (float)i / NumeroPontos;
            var ponto = DeCasteljau(t);
            points.Add(ponto);
        }

        return points;
    }

    private Ponto4D DeCasteljau(float t)
    {
        var pontos = new List<Ponto4D>(PontosControle);

        while (pontos.Count > 1)
        {
            var novosPontos = new List<Ponto4D>();

            for (var i = 0; i < pontos.Count - 1; i++)
            {
                var x = (1 - t) * pontos[i].X + t * pontos[i + 1].X;
                var y = (1 - t) * pontos[i].Y + t * pontos[i + 1].Y;
                novosPontos.Add(new Ponto4D(x, y));
            }

            pontos = novosPontos;
        }

        return pontos[0];
    }
}

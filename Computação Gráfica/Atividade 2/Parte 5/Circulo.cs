using OpenTK.Graphics.OpenGL4;
using System;
using CG_Biblioteca;

namespace gcgcg;

internal class Circulo : Objeto
{
    public Circulo(Objeto paiRef, ref char rotulo) : base(paiRef, ref rotulo)
    {
    }

    const int NumSegmentos = 72;
    public double Raio;
    public Ponto4D Centro;

    public Circulo(Objeto paiRef, ref char rotulo, double raio, Ponto4D centro) : base(paiRef, ref rotulo)
    {
        PrimitivaTipo = PrimitiveType.Points;
        PrimitivaTamanho = 5;
        Raio = raio;
        Centro = centro;
        Atualizar();
    }

    public void Atualizar()
    {
        PontosLimpar();
        
        for (var i = 0; i < NumSegmentos; i++)
        {
            var angulo = 2 * Math.PI * i / NumSegmentos;
            var x = Raio * Math.Cos(angulo) + Centro.X;
            var y = Raio * Math.Sin(angulo) + Centro.Y;
            PontosAdicionar(new Ponto4D(x, y));
        }

        ObjetoAtualizar();
    }
}
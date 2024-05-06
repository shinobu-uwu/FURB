using OpenTK.Graphics.OpenGL4;
using System;
using CG_Biblioteca;

namespace gcgcg;

internal class Circulo : Objeto
{
    public Circulo(Objeto paiRef, ref char rotulo) : base(paiRef, ref rotulo) {}

    public Circulo(Objeto paiRef, ref char rotulo, double raio, Ponto4D centro) : base(paiRef, ref rotulo)
    {
        PrimitivaTipo = PrimitiveType.Points;
        PrimitivaTamanho = 1;
        var numSegmentos = 72;
        
        for (var i = 0; i < numSegmentos; i++)
        {
            var angulo = 2 * Math.PI * i / numSegmentos;
            var x = raio * Math.Cos(angulo) + centro.X;
            var y = raio * Math.Sin(angulo) + centro.Y;
            PontosAdicionar(new Ponto4D(x, y));
        }
        
        ObjetoAtualizar();
    }
}
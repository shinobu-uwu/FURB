//TODO: testar se estes DEFINEs continuam funcionado

#define CG_Gizmo // debugar gráfico.
#define CG_OpenGL // render OpenGL.
// #define CG_DirectX // render DirectX.
// #define CG_Privado // código do professor.

using System;
using CG_Biblioteca;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

// using OpenTK.Mathematics;

namespace gcgcg
{
    public class Mundo : GameWindow
    {
        private static Objeto mundo = null;
        private const double RaioMenor = 0.25;
        private const double RaioMaior = 0.5;

        private char rotuloAtual = '?';
        private Objeto objetoSelecionado = null;

        private readonly float[] _sruEixos =
        {
            -0.5f, 0.0f, 0.0f, /* X- */ 0.5f, 0.0f, 0.0f, /* X+ */
            0.0f, -0.5f, 0.0f, /* Y- */ 0.0f, 0.5f, 0.0f, /* Y+ */
            0.0f, 0.0f, -0.5f, /* Z- */ 0.0f, 0.0f, 0.5f, /* Z+ */
        };

        private int _vertexBufferObject_sruEixos;
        private int _vertexArrayObject_sruEixos;

        private Shader _shaderVermelha;
        private Shader _shaderVerde;
        private Shader _shaderAzul;

        private bool mouseMovtoPrimeiro = true;
        private Ponto4D mouseMovtoUltimo;

        private Circulo _circuloMenor;
        private Circulo _circuloMaior;
        private Ponto4D _centroCirculoMenor;
        private Retangulo _bbox;

        public Mundo(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            mundo ??= new Objeto(null, ref rotuloAtual); //padrão Singleton
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            #region Eixos: SRU

            _vertexBufferObject_sruEixos = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_sruEixos);
            GL.BufferData(BufferTarget.ArrayBuffer, _sruEixos.Length * sizeof(float), _sruEixos,
                BufferUsageHint.StaticDraw);
            _vertexArrayObject_sruEixos = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_sruEixos);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shaderVermelha = new Shader("Shaders/shader.vert", "Shaders/shaderVermelha.frag");
            _shaderVerde = new Shader("Shaders/shader.vert", "Shaders/shaderVerde.frag");
            _shaderAzul = new Shader("Shaders/shader.vert", "Shaders/shaderAzul.frag");

            #endregion

            _centroCirculoMenor = new Ponto4D();
            _circuloMenor = new Circulo(mundo, ref rotuloAtual, RaioMenor, _centroCirculoMenor)
            {
                ShaderObjeto = _shaderAzul
            };
            _circuloMaior = new Circulo(mundo, ref rotuloAtual, RaioMaior, new Ponto4D())
            {
                ShaderObjeto = _shaderVermelha
            };
            _bbox = new Retangulo(mundo, ref rotuloAtual, new Ponto4D(-RaioMaior, -RaioMaior),
                new Ponto4D(RaioMaior, RaioMaior))
            {
                ShaderObjeto = _shaderVerde,
                PrimitivaTipo = PrimitiveType.LineLoop
            };
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

#if CG_Gizmo
            Sru3D();
#endif
            mundo.Desenhar();
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            #region Teclado

            var input = KeyboardState;
            if (input.IsKeyPressed(Keys.Escape))
            {
                Close();
            }

            if (input.IsKeyPressed(Keys.R))
            {
                objetoSelecionado.PontosLimpar();
            }

            if (input.IsKeyPressed(Keys.Right))
            {
                if (objetoSelecionado.PontosListaTamanho > 0)
                {
                    objetoSelecionado.PontosAlterar(
                        new Ponto4D(objetoSelecionado.PontosId(0).X + 0.005, objetoSelecionado.PontosId(0).Y, 0), 0);
                    objetoSelecionado.ObjetoAtualizar();
                }
            }

            if (input.IsKeyPressed(Keys.P))
            {
                Console.WriteLine(objetoSelecionado);
            }

            if (input.IsKeyPressed(Keys.Space))
            {
                objetoSelecionado ??= mundo;
                objetoSelecionado = mundo.GrafocenaBuscaProximo(objetoSelecionado);
            }

            const float Velocidade = 0.01f;

            if (input.IsKeyPressed(Keys.C))
            {
                if (_centroCirculoMenor.Y  <= RaioMaior && PodeMover())
                {
                    _centroCirculoMenor.Y += Velocidade;
                    _circuloMenor.Atualizar();
                }
            }

            if (input.IsKeyPressed(Keys.B))
            {
                if (_centroCirculoMenor.Y >= -RaioMaior && PodeMover())
                {
                    _centroCirculoMenor.Y -= Velocidade;
                    _circuloMenor.Atualizar();
                }
            }

            if (input.IsKeyPressed(Keys.E))
            {
                if (_centroCirculoMenor.X >= -RaioMaior && PodeMover())
                {
                    _centroCirculoMenor.X -= Velocidade;
                    _circuloMenor.Atualizar();
                }
            }

            if (input.IsKeyPressed(Keys.D))
            {
                if (_centroCirculoMenor.X <= RaioMaior && PodeMover())
                {
                    _centroCirculoMenor.X += Velocidade;
                    _circuloMenor.Atualizar();
                }
            }

            #endregion

            #region Mouse

            int janelaLargura = Size.X;
            int janelaAltura = Size.Y;
            Ponto4D mousePonto = new Ponto4D(MousePosition.X, MousePosition.Y);
            Ponto4D sruPonto = Utilitario.NDC_TelaSRU(janelaLargura, janelaAltura, mousePonto);

            //FIXME: o movimento do mouse em relação ao eixo X está certo. Mas tem um erro no eixo Y,,, aumentar o valor do Y aumenta o erro.
            if (input.IsKeyDown(Keys.LeftShift))
            {
                if (mouseMovtoPrimeiro)
                {
                    mouseMovtoUltimo = sruPonto;
                    mouseMovtoPrimeiro = false;
                }
                else
                {
                    var deltaX = sruPonto.X - mouseMovtoUltimo.X;
                    var deltaY = sruPonto.Y - mouseMovtoUltimo.Y;
                    mouseMovtoUltimo = sruPonto;

                    objetoSelecionado.PontosAlterar(
                        new Ponto4D(objetoSelecionado.PontosId(0).X + deltaX, objetoSelecionado.PontosId(0).Y + deltaY,
                            0), 0);
                    objetoSelecionado.ObjetoAtualizar();
                }
            }

            if (input.IsKeyDown(Keys.LeftShift))
            {
                objetoSelecionado.PontosAlterar(sruPonto, 0);
                objetoSelecionado.ObjetoAtualizar();
            }

            #endregion
        }

        bool PodeMover()
        {
            var distancia = Math.Pow(_centroCirculoMenor.X, 2) + Math.Pow(_centroCirculoMenor.Y, 2);

            return !(distancia >= Math.Pow(RaioMaior, 2));
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUnload()
        {
            mundo.OnUnload();

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteBuffer(_vertexBufferObject_sruEixos);
            GL.DeleteVertexArray(_vertexArrayObject_sruEixos);

            GL.DeleteProgram(_shaderVermelha.Handle);
            GL.DeleteProgram(_shaderVerde.Handle);
            GL.DeleteProgram(_shaderAzul.Handle);

            base.OnUnload();
        }

#if CG_Gizmo
        private void Sru3D()
        {
#if CG_OpenGL && !CG_DirectX
            GL.BindVertexArray(_vertexArrayObject_sruEixos);
            // EixoX
            _shaderVermelha.Use();
            GL.DrawArrays(PrimitiveType.Lines, 0, 2);
            // EixoY
            _shaderVerde.Use();
            GL.DrawArrays(PrimitiveType.Lines, 2, 2);
            // EixoZ
            _shaderAzul.Use();
            GL.DrawArrays(PrimitiveType.Lines, 4, 2);
#elif CG_DirectX && !CG_OpenGL
      Console.WriteLine(" .. Coloque aqui o seu código em DirectX");
#elif (CG_DirectX && CG_OpenGL) || (!CG_DirectX && !CG_OpenGL)
      Console.WriteLine(" .. ERRO de Render - escolha OpenGL ou DirectX !!");
#endif
        }
#endif
    }
}

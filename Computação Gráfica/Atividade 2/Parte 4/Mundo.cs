//TODO: testar se estes DEFINEs continuam funcionado

#define CG_Gizmo // debugar gráfico.
#define CG_OpenGL // render OpenGL.
// #define CG_DirectX // render DirectX.
// #define CG_Privado // código do professor.

using System.Collections.Generic;
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
        private Shader _shaderBranca;
        private Shader _shaderCiano;

        private bool mouseMovtoPrimeiro = true;
        private Ponto4D mouseMovtoUltimo;
        private Spline _spline;
        private Ponto4D _pontoSelecionado;
        private List<Ponto4D> _pontosControle;
        private List<Ponto> _pontos = [];
        private Dictionary<(Ponto4D, Ponto4D), SegReta> _segRetas = new();
        private Shader _shaderAmarela;

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
            _shaderBranca = new Shader("Shaders/shader.vert", "Shaders/shaderBranca.frag");
            _shaderAmarela = new Shader("Shaders/shader.vert", "Shaders/shaderAmarela.frag");
            _shaderCiano = new Shader("Shaders/shader.vert", "Shaders/shaderCiano.frag");

            #endregion

            _pontosControle = new List<Ponto4D>()
            {
                new(-0.5),
                new(0, 0.5),
                new(0.5),
            };
            _pontoSelecionado = _pontosControle[0];

            for (var i = 0; i < _pontosControle.Count; i++)
            {
                var ponto = _pontosControle[i];
                var pontoSeguinte = _pontosControle[(i + 1) % _pontosControle.Count];

                if (ponto == _pontoSelecionado)
                {
                    _pontos.Add(new Ponto(mundo, ref rotuloAtual, ponto)
                    {
                        ShaderObjeto = _shaderVermelha
                    });
                }
                else
                {
                    _pontos.Add(new Ponto(mundo, ref rotuloAtual, ponto)
                    {
                        ShaderObjeto = _shaderCiano
                    });
                }

                _segRetas.Add((ponto, pontoSeguinte), new SegReta(mundo, ref rotuloAtual, ponto, pontoSeguinte)
                {
                    ShaderObjeto = _shaderCiano
                });
            }

            _spline = new Spline(mundo, ref rotuloAtual, _pontosControle)
            {
                ShaderObjeto = _shaderAmarela,
            };
            objetoSelecionado = _spline;
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
                        new Ponto4D(objetoSelecionado.PontosId(0).X + deltaX, objetoSelecionado.PontosId(0).Y + deltaY),
                        0);
                    objetoSelecionado.ObjetoAtualizar();
                }
            }

            if (input.IsKeyDown(Keys.LeftShift))
            {
                objetoSelecionado.PontosAlterar(sruPonto, 0);
                objetoSelecionado.ObjetoAtualizar();
            }

            if (input.IsKeyDown(Keys.Space))
            {
                var i = _pontosControle.IndexOf(_pontoSelecionado);
                var novoI = (i + 1) % _pontosControle.Count;
                _pontoSelecionado = _pontosControle[novoI];
                _pontos[i].ShaderObjeto = _shaderCiano;
                _pontos[novoI].ShaderObjeto = _shaderVermelha;
            }

            const float velocidade = 0.01f;

            if (input.IsKeyDown(Keys.C))
            {
                _pontoSelecionado.Y += velocidade;
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            if (input.IsKeyDown(Keys.B))
            {
                _pontoSelecionado.Y -= velocidade;
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            if (input.IsKeyDown(Keys.E))
            {
                _pontoSelecionado.X -= velocidade;
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            if (input.IsKeyDown(Keys.D))
            {
                _pontoSelecionado.X += velocidade;
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            if (input.IsKeyDown(Keys.Equal))
            {
                AdicionarPonto();
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            if (input.IsKeyDown(Keys.Comma))
            {
                RemoverPonto();
                AtualizarPoliedro();
                _spline.Atualizar();
            }

            #endregion
        }

        private void AtualizarPoliedro()
        {
            foreach (var ponto in _pontos)
            {
                ponto.Atualizar();
            }

            foreach (var segReta in _segRetas.Values)
            {
                segReta.ObjetoAtualizar();
            }
        }

        protected void AdicionarPonto()
        {
            var novoPonto = new Ponto4D();
            var ultimoPonto = _pontosControle[^1];
            var primeiroPonto = _pontosControle[0];
            _pontosControle.Add(novoPonto);
            _pontos.Add(new Ponto(mundo, ref rotuloAtual, novoPonto)
            {
                ShaderObjeto = _shaderCiano
            });
            _segRetas[(ultimoPonto, primeiroPonto)].PontosLimpar();
            _segRetas.Remove((ultimoPonto, primeiroPonto));
            _segRetas.Add((ultimoPonto, novoPonto), new SegReta(mundo, ref rotuloAtual, ultimoPonto, novoPonto)
            {
                ShaderObjeto = _shaderCiano
            });
            _segRetas.Add((novoPonto, primeiroPonto), new SegReta(mundo, ref rotuloAtual, novoPonto, primeiroPonto)
            {
                ShaderObjeto = _shaderCiano
            });
        }

        protected void RemoverPonto()
        {
            // não é possível ter um polígono com 2 pontos
            if (_pontosControle.Count <= 3)
            {
                return;
            }

            var indice = _pontosControle.IndexOf(_pontoSelecionado);
            var proximoIndice = (indice + 1) % _pontosControle.Count;
            var pontoSeguinte = _pontosControle[proximoIndice];
            _segRetas[(_pontoSelecionado, pontoSeguinte)].PontosLimpar();
            _pontos[indice].PontosLimpar();
            _pontos.RemoveAt(indice);
            _pontosControle.RemoveAt(indice);
            _pontoSelecionado = pontoSeguinte;
            _pontos[proximoIndice].ShaderObjeto = _shaderVermelha;

            foreach (var segReta in _segRetas.Values)
            {
                segReta.PontosLimpar();
            }

            _segRetas.Clear();

            for (var i = 0; i < _pontosControle.Count; i++)
            {
                pontoSeguinte = _pontosControle[(indice + 1) % _pontosControle.Count];
                _segRetas.Add((_pontosControle[i], pontoSeguinte),
                    new SegReta(mundo, ref rotuloAtual, _pontosControle[i], pontoSeguinte)
                    {
                        ShaderObjeto = _shaderCiano,
                    });
            }

            _segRetas.Add((_pontosControle[0], _pontosControle[^1]),
                new SegReta(mundo, ref rotuloAtual, _pontosControle[0], _pontosControle[^1])
                {
                    ShaderObjeto = _shaderCiano,
                });

            AtualizarPoliedro();
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
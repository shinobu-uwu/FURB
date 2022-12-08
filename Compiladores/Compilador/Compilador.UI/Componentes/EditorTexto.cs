namespace Compilador.UI.Componentes;

public sealed class EditorTexto : RichTextBox
{
    public int AlturaLinha
    {
        get
        {
            using var graphics = CreateGraphics();
            return (int)graphics.MeasureString("A", Font).Height;
        }
    }

    public EditorTexto()
    {
        Size = new Size(850, 400);
        Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        Location = new Point(33, 30);
        BackColor = Color.White;
        ScrollBars = RichTextBoxScrollBars.ForcedBoth;
        WordWrap = false;
        AcceptsTab = true;
        Multiline = true;
        TabIndex = 4;
    }
}
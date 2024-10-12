using System.Drawing;
using System.Windows.Forms;

public class CustomContextMenuRenderer : ToolStripProfessionalRenderer
{
    private Color _backgroundColor = Color.FromArgb(11, 7, 17);
    private Color _hoverColor = Color.FromArgb(255, 30, 70);
    private Color _separatorColor = Color.FromArgb(255, 30, 70); // Couleur de la barre de séparation

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        // Remplir le fond
        Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

        // Vérifier si l'élément est sélectionné (survolé)
        if (e.Item.Selected)
        {
            // Utiliser la couleur de survol pour l'élément sélectionné
            e.Graphics.FillRectangle(new SolidBrush(_hoverColor), rect);
        }
        else
        {
            // Utiliser la couleur d'arrière-plan normal pour les éléments non sélectionnés
            e.Graphics.FillRectangle(new SolidBrush(_backgroundColor), rect);
        }
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        // Dessiner le texte en utilisant la couleur par défaut de l'élément
        e.TextColor = Color.White; // Assurer que le texte est blanc
        base.OnRenderItemText(e); // Utiliser le rendu par défaut pour le texte
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        // Empêche le dessin de l'arrière-plan du séparateur
        e.Graphics.Clear(_backgroundColor); // Définit le fond pour le séparateur

        // Dessiner la barre de séparation
        using (Pen pen = new Pen(_separatorColor, 2))
        {
            // Calculer la position Y pour centrer la ligne
            int centerY = (e.Item.Height - 1) / 2; // On soustrait 1 pour éviter de dessiner en bas
            e.Graphics.DrawLine(pen, new Point(0, centerY), new Point(e.Item.Width, centerY));
        }
    }
}

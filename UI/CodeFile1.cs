using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
/*using System.Windows;*/
using System.Windows.Forms;
/*using System.Windows.Media;*/
using TGMacro.UI;


public class CustomButton : Button
{
    private int borderSize = 0;
    private int borderRadius = 20;
    private Color borderColor = Color.WhiteSmoke;

    public CustomButton() {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.Size = new System.Drawing.Size(150, 20);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ForeColor = Color.White;
        Console.WriteLine(this.Text);
    }

    private GraphicsPath GetFigurePath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);

        path.CloseFigure();

        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        /*String str = this.Text.ToString();

        this.ResetText();

        if(str == "Add New Macro")
        {
            str = "Add New";
        }
        if(str == "Enable {HOME}")
        {
            str = "Enable (Home)";
        }

        this.Text = str;*/
        RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
        RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height);

        if(borderRadius > 0) {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }

        }
        else
        {
            this.Region = new Region(rectSurface);
            if(borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    
                }
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        this.Parent.BackColorChanged += new EventHandler(Container_BackColorCHanged);
    }

    private void Container_BackColorCHanged(object sender, EventArgs e)
    {
        if (DesignMode)
        {
            this.Invalidate();
        }
    }
}



public class GroupBoxConstants
{
    #region Constants

    /// <summary>The sweep angle of the arc.</summary>
    public const int SweepAngle = 90;

    /// <summary>The minimum control height.</summary>
    public const int MinControlHeight = 32;

    /// <summary>The minimum control width.</summary>
    public const int MinControlWidth = 96;

    #endregion
}
public class CustomGroupBox : System.Windows.Forms.UserControl
    {
        #region Enumerations

        /// <summary>A special gradient enumeration.</summary>
        public enum GroupBoxGradientMode
        {
            /// <summary>Specifies no gradient mode.</summary>
            None = 4,

            /// <summary>Specifies a gradient from upper right to lower left.</summary>
            BackwardDiagonal = 3,

            /// <summary>Specifies a gradient from upper left to lower right.</summary>
            ForwardDiagonal = 2,

            /// <summary>Specifies a gradient from left to right.</summary>
            Horizontal = 0,

            /// <summary>Specifies a gradient from top to bottom.</summary>
            Vertical = 1
        }


        #endregion

        #region Variables

        private System.ComponentModel.Container components = null;
        private int BorderRadius = 10;
        private string V_GroupTitle = "The Grouper";
        private System.Drawing.Color V_BorderColor = Color.Black;
        private float V_BorderThickness = 1;
        private bool V_ShadowControl = false;
        private System.Drawing.Color V_BackgroundColor = Color.White;
        private System.Drawing.Color V_BackgroundGradientColor = Color.White;
        private GroupBoxGradientMode V_BackgroundGradientMode = GroupBoxGradientMode.None;
        private System.Drawing.Color V_ShadowColor = Color.DarkGray;
        private int V_ShadowThickness = 3;
        private System.Drawing.Image V_GroupImage = null;
        private System.Drawing.Color V_CustomGroupBoxColor = Color.White;
        private bool V_PaintGroupBox = false;
        private System.Drawing.Color V_BackColor = Color.Transparent;

        #endregion

        #region Properties

        /// <summary>This feature will paint the background color of the control.</summary>
        [Category("Appearance"), Description("This feature will paint the background color of the control.")]
        public override System.Drawing.Color BackColor { get { return V_BackColor; } set { V_BackColor = value; this.Refresh(); } }

        /// <summary>This feature will paint the group title background to the specified color if PaintGroupBox is set to true.</summary>
        [Category("Appearance"), Description("This feature will paint the group title background to the specified color if PaintGroupBox is set to true.")]
        public System.Drawing.Color CustomGroupBoxColor { get { return V_CustomGroupBoxColor; } set { V_CustomGroupBoxColor = value; this.Refresh(); } }

        /// <summary>This feature will paint the group title background to the CustomGroupBoxColor.</summary>
        [Category("Appearance"), Description("This feature will paint the group title background to the CustomGroupBoxColor.")]
        public bool PaintGroupBox { get { return V_PaintGroupBox; } set { V_PaintGroupBox = value; this.Refresh(); } }

        /// <summary>This feature can add a 16 x 16 image to the group title bar.</summary>
        [Category("Appearance"), Description("This feature can add a 16 x 16 image to the group title bar.")]
        public System.Drawing.Image GroupImage { get { return V_GroupImage; } set { V_GroupImage = value; this.Refresh(); } }

        /// <summary>This feature will change the control's shadow color.</summary>
        [Category("Appearance"), Description("This feature will change the control's shadow color.")]
        public System.Drawing.Color ShadowColor { get { return V_ShadowColor; } set { V_ShadowColor = value; this.Refresh(); } }

        /// <summary>This feature will change the size of the shadow border.</summary>
        [Category("Appearance"), Description("This feature will change the size of the shadow border.")]
        public int ShadowThickness
        {
            get { return V_ShadowThickness; }
            set
            {
                if (value > 10)
                {
                    V_ShadowThickness = 10;
                }
                else
                {
                    if (value < 1) { V_ShadowThickness = 1; }
                    else { V_ShadowThickness = value; }
                }

                this.Refresh();
            }
        }


        /// <summary>This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.</summary>
        [Category("Appearance"), Description("This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.")]
        public System.Drawing.Color BackgroundColor { get { return V_BackgroundColor; } set { V_BackgroundColor = value; this.Refresh(); } }

        /// <summary>This feature can be used in combination with BackgroundColor to create a gradient background.</summary>
        [Category("Appearance"), Description("This feature can be used in combination with BackgroundColor to create a gradient background.")]
        public System.Drawing.Color BackgroundGradientColor { get { return V_BackgroundGradientColor; } set { V_BackgroundGradientColor = value; this.Refresh(); } }

        /// <summary>This feature turns on background gradient painting.</summary>
        [Category("Appearance"), Description("This feature turns on background gradient painting.")]
        public GroupBoxGradientMode BackgroundGradientMode { get { return V_BackgroundGradientMode; } set { V_BackgroundGradientMode = value; this.Refresh(); } }

        /// <summary>This feature will round the corners of the control.</summary>
        [Category("Appearance"), Description("This feature will round the corners of the control.")]
        public int RoundCorners
        {
            get { return BorderRadius; }
            set
            {
                if (value > 25)
                {
                    BorderRadius = 25;
                }
                else
                {
                    if (value < 1) { BorderRadius = 1; }
                    else { BorderRadius = value; }
                }

                this.Refresh();
            }
        }

        /// <summary>This feature will add a group title to the control.</summary>
        [Category("Appearance"), Description("This feature will add a group title to the control.")]
        public string GroupTitle { get { return V_GroupTitle; } set { V_GroupTitle = value; this.Refresh(); } }

        /// <summary>This feature will allow you to change the color of the control's border.</summary>
        [Category("Appearance"), Description("This feature will allow you to change the color of the control's border.")]
        public System.Drawing.Color BorderColor { get { return V_BorderColor; } set { V_BorderColor = value; this.Refresh(); } }

        /// <summary>This feature will allow you to set the control's border size.</summary>
        [Category("Appearance"), Description("This feature will allow you to set the control's border size.")]
        public float BorderThickness
        {
            get { return V_BorderThickness; }
            set
            {
                if (value > 3)
                {
                    V_BorderThickness = 3;
                }
                else
                {
                    if (value < 1) { V_BorderThickness = 1; }
                    else { V_BorderThickness = value; }
                }
                this.Refresh();
            }
        }

        /// <summary>This feature will allow you to turn on control shadowing.</summary>
        [Category("Appearance"), Description("This feature will allow you to turn on control shadowing.")]
        public bool ShadowControl { get { return V_ShadowControl; } set { V_ShadowControl = value; this.Refresh(); } }

        #endregion

        #region Constructor

        /// <summary>This method will construct a new GroupBox control.</summary>
        public CustomGroupBox()
        {
            InitializeStyles();
            InitializeGroupBox();
        }


        #endregion

        #region DeConstructor

        /// <summary>This method will dispose of the GroupBox control.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) { if (components != null) { components.Dispose(); } }
            base.Dispose(disposing);
        }


        #endregion

        #region Initialization

        /// <summary>This method will initialize the controls custom styles.</summary>
        private void InitializeStyles()
        {
            //Set the control styles----------------------------------
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //--------------------------------------------------------
        }


        /// <summary>This method will initialize the GroupBox control.</summary>
        private void InitializeGroupBox()
        {
            components = new System.ComponentModel.Container();
            this.Resize += new EventHandler(GroupBox_Resize);
            this.DockPadding.All = 20;
            this.Name = "GroupBox";
            this.Size = new System.Drawing.Size(368, 288);
        }


        #endregion

        #region Protected Methods

        /// <summary>Overrides the OnPaint method to paint control.</summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            PaintBack(e.Graphics);
            PaintGroupText(e.Graphics);
    }

        #endregion

        #region Private Methods

        /// <summary>This method will paint the group title.</summary>
        /// <param name="g">The paint event graphics object.</param>
        private void PaintGroupText(System.Drawing.Graphics g)
        {
            //Check if string has something-------------
            if (this.GroupTitle == string.Empty) { return; }
            //------------------------------------------

            //Set Graphics smoothing mode to Anit-Alias-- 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //-------------------------------------------

            //Declare Variables------------------
            SizeF StringSize = g.MeasureString(this.GroupTitle, this.Font);
            Size StringSize2 = StringSize.ToSize();
            if (this.GroupImage != null) { StringSize2.Width += 18; }
            int ArcWidth = this.RoundCorners;
            int ArcHeight = this.RoundCorners;
            int ArcX1 = 20;
            int ArcX2 = (StringSize2.Width + 34) - (ArcWidth + 1);
            int ArcY1 = 0;
            int ArcY2 = 24 - (ArcHeight + 1);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Brush BorderBrush = new SolidBrush(Color.White);
            System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
            System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
            System.Drawing.Brush BackgroundBrush = (this.PaintGroupBox) ? new SolidBrush(this.CustomGroupBoxColor) : new SolidBrush(this.BackgroundColor);
            System.Drawing.SolidBrush TextColorBrush = new SolidBrush(this.ForeColor);
            System.Drawing.SolidBrush ShadowBrush = null;
            System.Drawing.Drawing2D.GraphicsPath ShadowPath = null;
            //-----------------------------------

            //Check if shadow is needed----------
            if (this.ShadowControl)
            {
                ShadowBrush = new SolidBrush(this.ShadowColor);
                ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
                ShadowPath.AddArc(ArcX1 + (this.ShadowThickness - 1), ArcY1 + (this.ShadowThickness - 1), ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
                ShadowPath.AddArc(ArcX2 + (this.ShadowThickness - 1), ArcY1 + (this.ShadowThickness - 1), ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
                ShadowPath.AddArc(ArcX2 + (this.ShadowThickness - 1), ArcY2 + (this.ShadowThickness - 1), ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
                ShadowPath.AddArc(ArcX1 + (this.ShadowThickness - 1), ArcY2 + (this.ShadowThickness - 1), ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
                ShadowPath.CloseAllFigures();

                //Paint Rounded Rectangle------------
                g.FillPath(ShadowBrush, ShadowPath);
                //-----------------------------------
            }
        //-----------------------------------

        //Create Rounded Rectangle Path------
            path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
            path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
            path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
            path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
            path.CloseAllFigures();
            //-----------------------------------

            //Check if Gradient Mode is enabled--
            if (this.PaintGroupBox)
            {
                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundBrush, path);
                //-----------------------------------
            }
            else
            {
                if (this.BackgroundGradientMode == GroupBoxGradientMode.None)
                {
                    //Paint Rounded Rectangle------------
                    g.FillPath(BackgroundBrush, path);
                    //-----------------------------------
                }
                else
                {
                    BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);

                    //Paint Rounded Rectangle------------
                    g.FillPath(BackgroundGradientBrush, path);
                    //-----------------------------------
                }
            }
            //-----------------------------------

            //Paint Borded-----------------------
            g.DrawPath(BorderPen, path);
            //-----------------------------------

            //Paint Text-------------------------
            int CustomStringWidth = (this.GroupImage != null) ? 44 : 28;
            g.DrawString(this.GroupTitle, this.Font, TextColorBrush, CustomStringWidth, 5);
            //-----------------------------------

            //Draw GroupImage if there is one----
            if (this.GroupImage != null)
            {
                g.DrawImage(this.GroupImage, 28, 4, 16, 16);
            }
            //-----------------------------------

            //Destroy Graphic Objects------------
            if (path != null) { path.Dispose(); }
            if (BorderBrush != null) { BorderBrush.Dispose(); }
            if (BorderPen != null) { BorderPen.Dispose(); }
            if (BackgroundGradientBrush != null) { BackgroundGradientBrush.Dispose(); }
            if (BackgroundBrush != null) { BackgroundBrush.Dispose(); }
            if (TextColorBrush != null) { TextColorBrush.Dispose(); }
            if (ShadowBrush != null) { ShadowBrush.Dispose(); }
            if (ShadowPath != null) { ShadowPath.Dispose(); }
            //-----------------------------------
        }


        /// <summary>This method will paint the control.</summary>
        /// <param name="g">The paint event graphics object.</param>
        private void PaintBack(System.Drawing.Graphics g)
        {
            //Set Graphics smoothing mode to Anit-Alias-- 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //-------------------------------------------

            //Declare Variables------------------
            int ArcWidth = this.RoundCorners * 2;
            int ArcHeight = this.RoundCorners * 2;
            int ArcX1 = 0;
            int ArcX2 = (this.ShadowControl) ? (this.Width - (ArcWidth + 1)) - this.ShadowThickness : this.Width - (ArcWidth + 1);
            int ArcY1 = 10;
            int ArcY2 = (this.ShadowControl) ? (this.Height - (ArcHeight + 1)) - this.ShadowThickness : this.Height - (ArcHeight + 1);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Brush BorderBrush = new SolidBrush(this.BorderColor);
            System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
            System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
            System.Drawing.Brush BackgroundBrush = new SolidBrush(this.BackgroundColor);
            System.Drawing.SolidBrush ShadowBrush = null;
            System.Drawing.Drawing2D.GraphicsPath ShadowPath = null;
            //-----------------------------------

            //Check if shadow is needed----------
            if (this.ShadowControl)
            {
                ShadowBrush = new SolidBrush(this.ShadowColor);
                ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
                ShadowPath.AddArc(ArcX1 + this.ShadowThickness, ArcY1 + this.ShadowThickness, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
                ShadowPath.AddArc(ArcX2 + this.ShadowThickness, ArcY1 + this.ShadowThickness, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
                ShadowPath.AddArc(ArcX2 + this.ShadowThickness, ArcY2 + this.ShadowThickness, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
                ShadowPath.AddArc(ArcX1 + this.ShadowThickness, ArcY2 + this.ShadowThickness, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
                ShadowPath.CloseAllFigures();

                //Paint Rounded Rectangle------------
                g.FillPath(ShadowBrush, ShadowPath);
                //-----------------------------------
            }
            //-----------------------------------

            //Create Rounded Rectangle Path------
            path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
            path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
            path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
            path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
            path.CloseAllFigures();
            //-----------------------------------

            //Check if Gradient Mode is enabled--
            if (this.BackgroundGradientMode == GroupBoxGradientMode.None)
            {
                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundBrush, path);
                //-----------------------------------
            }
            else
            {
                BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);

                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundGradientBrush, path);
                //-----------------------------------
            }
            //-----------------------------------

            //Paint Borded-----------------------
            g.DrawPath(BorderPen, path);
            //-----------------------------------

            //Destroy Graphic Objects------------
            if (path != null) { path.Dispose(); }
            if (BorderBrush != null) { BorderBrush.Dispose(); }
            if (BorderPen != null) { BorderPen.Dispose(); }
            if (BackgroundGradientBrush != null) { BackgroundGradientBrush.Dispose(); }
            if (BackgroundBrush != null) { BackgroundBrush.Dispose(); }
            if (ShadowBrush != null) { ShadowBrush.Dispose(); }
            if (ShadowPath != null) { ShadowPath.Dispose(); }
            //-----------------------------------
        }


        /// <summary>This method fires when the GroupBox resize event occurs.</summary>
        /// <param name="sender">The object the sent the event.</param>
        /// <param name="e">The event arguments.</param>
        private void GroupBox_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }


        #endregion
    }



class CustomComboBox : ComboBox
{
    private Color borderColor = Color.Black;
    private int borderRadius = 10;
    private int borderSize = 1;

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(10)]
    public int BorderRadius
    {
        get { return borderRadius; }
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(1)]
    public int BorderWidth
    {
        get { return borderSize; }
        set
        {
            borderSize = value;
            Invalidate();
        }
    }
    public CustomComboBox()
    {
        SetStyle(ControlStyles.UserPaint, true);
    }
    private GraphicsPath GetFigurePath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        /*path.AddLine(rect.X + 50, rect.Y, rect.X + rect.Width, rect.Y);*/
        path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);

        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);



        return path;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
        RectangleF rectBorder = new RectangleF(1, 20, this.Width - 0.8F, this.Height);
        /*this.ClientRectangle.Intersect(rectBorder);*/
        rectBorder.Intersect(this.ClientRectangle);
        if (borderRadius > 0)
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(this.ClientRectangle, borderRadius - 1F))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize >= 1)
                    e.Graphics.DrawPath(penBorder, pathBorder);
            }

        }
        else
        {
            /*this.Region = new Region(rectSurface);*/
            if (borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                }
            }
        }
    }

}

class CustomLabel : Label
{
    private Color borderColor = Color.Black;
    private int borderRadius = 40;
    private int borderSize = 1;

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(10)]
    public int BorderRadius
    {
        get { return borderRadius; }
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(1)]
    public int BorderWidth
    {
        get { return borderSize; }
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    private GraphicsPath GetFigurePath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);

        path.CloseFigure();

        return path;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
        RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height);

        if (borderRadius > 0)
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize >= 1)
                    e.Graphics.DrawPath(penBorder, pathBorder);
            }

        }
        else
        {
            this.Region = new Region(rectSurface);
            if (borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                }
            }
        }

    }

    /*private GraphicsPath RoundedRectangle(Rectangle rect, int borderRadius)
    {
        GraphicsPath path = new GraphicsPath();

        if (borderRadius == 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        int diameter = borderRadius * 2;
        System.Drawing.Size size = new System.Drawing.Size(diameter, diameter);
        Rectangle arc = new Rectangle(rect.Location, size);

        // top left arc  
        path.AddArc(arc, 180, 90);

        // top right arc  
        arc.X = rect.Right - diameter;
        path.AddArc(arc, 270, 90);

        // bottom right arc  
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // bottom left arc 
        arc.X = rect.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();

        return path;
    }*/
}


class CustomPanel : Panel
{
    private Color borderColor = Color.Black;
    private int borderRadius = 40;
    private int borderSize = 1;

    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(10)]
    public int BorderRadius
    {
        get { return borderRadius; }
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(1)]
    public int BorderWidth
    {
        get { return borderSize; }
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    private GraphicsPath GetFigurePath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);

        path.CloseFigure();

        return path;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
        RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height);

        if (borderRadius > 0)
        {
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                e.Graphics.DrawPath(penSurface, pathSurface);

                if (borderSize >= 1)
                    e.Graphics.DrawPath(penBorder, pathBorder);
            }

        }
        else
        {
            this.Region = new Region(rectSurface);
            if (borderSize >= 1)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                }
            }
        }

    }

    /*private GraphicsPath RoundedRectangle(Rectangle rect, int borderRadius)
    {
        GraphicsPath path = new GraphicsPath();

        if (borderRadius == 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        int diameter = borderRadius * 2;
        System.Drawing.Size size = new System.Drawing.Size(diameter, diameter);
        Rectangle arc = new Rectangle(rect.Location, size);

        // top left arc  
        path.AddArc(arc, 180, 90);

        // top right arc  
        arc.X = rect.Right - diameter;
        path.AddArc(arc, 270, 90);

        // bottom right arc  
        arc.Y = rect.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // bottom left arc 
        arc.X = rect.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();

        return path;
    }*/
}


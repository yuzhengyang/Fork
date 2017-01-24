using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Y.Controls.Container
{
    public partial class FlexiblePanel : Panel
    {
        //Color HighlightColor = ColorTranslator.FromHtml("#78c4ec");
        Color HighlightColor = Color.Transparent;

        /// <summary>
        /// 光标状态
        /// </summary>
        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //'无   
            MouseSizeRight = 1, //'拉伸右边框   
            MouseSizeLeft = 2, //'拉伸左边框   
            MouseSizeBottom = 3, //'拉伸下边框   
            MouseSizeTop = 4, //'拉伸上边框   
            MouseSizeTopLeft = 5, //'拉伸左上角   
            MouseSizeTopRight = 6, //'拉伸右上角   
            MouseSizeBottomLeft = 7, //'拉伸左下角   
            MouseSizeBottomRight = 8, //'拉伸右下角   
            MouseDrag = 9   // '鼠标拖动   
        }
        #region 属性
        private static string xmlDocPath = "";
        private XmlDocument doc;
        private const int Band = 5;
        private const int MinWidth = 10;
        private const int MinHeight = 10;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;
        #endregion
        public FlexiblePanel()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
            InitializeComponent();
        }

        #region 改变控件大小和移动位置用到的方法



        private void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;
        }
        /// <summary>
        /// 鼠标离开事件需要改进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMouseLeave(object sender, EventArgs e)
        {
            Control s = (Control)sender;

            XmlNodeList nodes = doc.GetElementsByTagName(s.Name);
            XmlElement xn;
            if (nodes.Count != 1)
            {
                xn = doc.CreateElement(s.Name);
            }
            else
            {
                xn = (XmlElement)doc.GetElementsByTagName(s.Name)[0];
            }
            xn.SetAttribute("Top", s.Top.ToString());
            xn.SetAttribute("Left", s.Left.ToString());
            xn.SetAttribute("Width", s.Width.ToString());
            xn.SetAttribute("Height", s.Height.ToString());


            XmlNodeList xnl = doc.GetElementsByTagName(this.Name);
            XmlElement xnp;
            if (xnl.Count < 1)
            {
                xnp = doc.CreateElement(this.Name);
            }
            else
            {
                xnp = (XmlElement)xnl[0];
            }
            xnp.AppendChild((XmlNode)xn);
            doc.DocumentElement.AppendChild((XmlNode)xnp);
            doc.Save(xmlDocPath);

            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            this.Cursor = Cursors.Arrow;
            ((Control)sender).BackColor = Color.Transparent;
        }

        private EnumMousePointPosition MousePointPosition(Size size, System.Windows.Forms.MouseEventArgs e)
        {

            if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band) { return EnumMousePointPosition.MouseSizeTopLeft; }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        { return EnumMousePointPosition.MouseSizeBottomLeft; }
                        else
                        { return EnumMousePointPosition.MouseSizeLeft; }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTopRight; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottomRight; }
                            else
                            { return EnumMousePointPosition.MouseSizeRight; }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        { return EnumMousePointPosition.MouseSizeTop; }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            { return EnumMousePointPosition.MouseSizeBottom; }
                            else
                            { return EnumMousePointPosition.MouseDrag; }
                        }
                    }
                }
            }
            else
            { return EnumMousePointPosition.MouseSizeNone; }
        }
        private void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control lCtrl = (sender as Control);

            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        //       lCtrl.Height = lCtrl.Height + e.Y - p1.Y;   
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点   
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;

            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态   
                switch (m_MousePointPosition)   //'改变光标   
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;        //'箭头  
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        this.Cursor = Cursors.SizeAll;      //'四方向   
                        ((Control)sender).BackColor = HighlightColor;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        this.Cursor = Cursors.SizeNS;       //'南北   
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        this.Cursor = Cursors.SizeNS;       //'南北   
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        this.Cursor = Cursors.SizeWE;       //'东西   
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        this.Cursor = Cursors.SizeWE;       //'东西   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西   
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北   
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北   
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西   
                        break;
                    default:
                        break;
                }
            }

        }


        #endregion

        #region 初始化鼠标事件委托和控件大小和移动
        private void initProperty()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].MouseDown += new System.Windows.Forms.MouseEventHandler(MyMouseDown);
                this.Controls[i].MouseLeave += new System.EventHandler(MyMouseLeave);
                this.Controls[i].MouseMove += new System.Windows.Forms.MouseEventHandler(MyMouseMove);
            }

        }
        private void initStyle()
        {
            Control s;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                s = this.Controls[i];
                XmlNodeList nodes = doc.GetElementsByTagName(s.Name);
                if (nodes.Count == 1)
                {
                    XmlAttributeCollection xac = nodes[0].Attributes;
                    foreach (XmlAttribute xa in xac)
                    {
                        if (xa.Value == "")
                            continue;
                        switch (xa.Name)
                        {
                            case "Top":
                                var Top = Convert.ToInt32(xa.Value);
                                //if (Top > 0 && Top < this.Height - s.Height)
                                s.Top = Top;
                                break;
                            case "Left":
                                var Left = Convert.ToInt32(xa.Value);
                                //if (Left > 0 && Left < this.Width - s.Width)
                                s.Left = Left;
                                break;
                            case "Width":
                                s.Width = Convert.ToInt32(xa.Value);
                                break;
                            case "Height":
                                s.Height = Convert.ToInt32(xa.Value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 用于实现容器内控件移动和改变大小的方法
        /// </summary>
        /// <param name="XmlDoc">用于保存控件的属性的XML文档</param>
        public void InitMouseAndContolStyle(string XmlDocPath)
        {
            xmlDocPath = XmlDocPath;
            doc = new XmlDocument();
            doc.Load(XmlDocPath);
            initProperty();
            initStyle();
        }
    }
}

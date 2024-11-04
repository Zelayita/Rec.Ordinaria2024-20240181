using Refuerzo2024.Controller.Docentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.View.Docentes
{
    public partial class ViewDocentes : Form
    {
        public ViewDocentes()
        {
            InitializeComponent();
            ControllerDocentes control = new ControllerDocentes(this);
        }
    }
}

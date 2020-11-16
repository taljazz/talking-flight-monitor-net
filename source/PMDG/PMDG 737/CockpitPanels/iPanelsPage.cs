using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public interface iPanelsPage
    {
        void Hide();
        void Show();
        Control Parent { get; set; }
        void SetDocking();
        string Name { get; set; }
        private void event_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    break;

            }

        }

    }
}

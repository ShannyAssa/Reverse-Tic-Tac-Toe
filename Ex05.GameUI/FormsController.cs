using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameUI
{
    public class FormsController
    {
        public static void Run()
        {
            FormSettings formSettings = new FormSettings();
            
            formSettings.ShowDialog();
            if(formSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                FormGame formGame = new FormGame(formSettings);
                
                formGame.ShowDialog();
                formGame.Dispose();
            }

            formSettings.Dispose();
        }
    }
}

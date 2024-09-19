using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MK_BracketManager
{
    // TODO: Folgendes zur Definition von SomeType hinzufügen, um diese Schnellansicht beim Debugging von Instanzen von SomeType anzuzeigen:
    // 
    //  [DebuggerVisualizer(typeof(Visualizer1))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// Eine Schnellansicht für SomeType.  
    /// </summary>
    public class Visualizer1 : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: Das Objekt abrufen, für das eine Schnellansicht angezeigt werden soll.
            //       Wandeln Sie das Ergebnis von objectProvider.GetObject() 
            //       in den Typ des Objekts um, das in der Schnellansicht angezeigt wird.
            object data = (object)objectProvider.GetObject();

            // TODO: Ihre Ansicht des Objekts anzeigen.
            //       Ersetzen Sie displayForm durch ein eigenes benutzerdefiniertes Formular oder Steuerelement.
            using (Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: Folgendes zum Testcode hinzufügen, um die Schnellansicht zu testen:
        // 
        //    Visualizer1.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// Testet die Schnellansicht, indem sie außerhalb des Debuggers gehostet wird.
        /// </summary>
        /// <param name="objectToVisualize">Das in der Schnellansicht anzuzeigende Objekt.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(Visualizer1));
            visualizerHost.ShowVisualizer();
        }
    }
}

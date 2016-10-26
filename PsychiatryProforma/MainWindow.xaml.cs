using System;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using PsychiatryProforma.Expansions;
using PsychiatryProforma.Gender;
using PsychiatryProforma.InterfaceBuilding.Interfaces;
using PsychiatryProforma.InterfaceBuilding.Loading;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace PsychiatryProforma
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GroupElement _modelBaseElement;
        private TextExpansionLibrary _textExpansionLibrary;
        private bool patientGenderFound;

        public MainWindow()
        {
            InitializeComponent();
            _textExpansionLibrary = TextExpansionsHelper.LoadExpansions("Expansions/Expansions.xml");
        }

        private void RenderProforma(string proformaFileName)
        {
            IModelLoader modelLoader = new XmlModelLoader(proformaFileName);
            _modelBaseElement = modelLoader.LoadModel();

            IControlBuilderFactory factory = new ControlBuilderFactory();
            var control = factory.SelectFactory(_modelBaseElement).GenerateControl(_modelBaseElement);
            StackPanel.Children.Add(control);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var s = _modelBaseElement.ToString();
            Clipboard.SetText(s);
        }

        private void LoadProformaItem_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var fileSelected = openFileDialog.ShowDialog();
            if (fileSelected != null && fileSelected.Value)
            {
                var fileName = openFileDialog.FileName;
                RenderProforma(fileName);
            }

            // Set an auto-save timer.
            var autosaveTimer = new Timer(60000);
            autosaveTimer.Elapsed += (o, args) => { File.WriteAllText("autosave.txt", _modelBaseElement.ToString()); };
            autosaveTimer.Start();
        }

        private void ExportToClipboardItem_Click(object sender, RoutedEventArgs e)
        {
            var s = GetExportText();

            Clipboard.SetText(s);
        }

        private string GetExportText()
        {
            var s = _modelBaseElement.ToString();

            if (_textExpansionLibrary == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog(this) == true)
                {
                    _textExpansionLibrary = TextExpansionsHelper.LoadExpansions(openFileDialog.FileName);
                }
                else
                {
                    return "Need to select appropriate expansions file.";
                }
            }
            s = TextExpansionsHelper.ReplaceExpansions(s, _textExpansionLibrary);

            if (PatientName.Text != null) s = s.Replace("$patient$", PatientName.Text);
            if (PatientName.Text != null) s = s.Replace("$pt$", PatientName.Text);

            if (PatientGender.IsChecked.Value)
            {
                s = s.Replace("$gender$", "his");
                s = s.Replace("$g$", "his");
                s = s.Replace("$g2$", "he");
            }
            else
            {
                s = s.Replace("$gender$", "her");
                s = s.Replace("$g$", "her");
                s = s.Replace("$g2$", "she");
            }


            return s;
        }

        private void ShowExpansionsHelper_OnClick(object sender, RoutedEventArgs e)
        {
            if (_textExpansionLibrary == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog(this) == true)
                {
                    _textExpansionLibrary = TextExpansionsHelper.LoadExpansions(openFileDialog.FileName);
                }
                else
                {
                    return;
                }
            }

            var expansionsHelperWindow = new Window {Width = 500, Height = 700};
            var stackPanel = new StackPanel {Margin = new Thickness(15)};
            stackPanel.CanVerticallyScroll = true;

            stackPanel.Children.Add(new Label {Content = "Possible Text Expansions", FontSize = 26});

            foreach (var expansion in _textExpansionLibrary)
            {
                stackPanel.Children.Add(new Label {Content = $"{expansion.ContractedText} - {expansion.ExportVariations.SelectVariation()}"});
            }

            expansionsHelperWindow.Content = stackPanel;

            expansionsHelperWindow.Show();
        }

        private void LoadExpansionsFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            _textExpansionLibrary = openFileDialog.ShowDialog(this) == true ? TextExpansionsHelper.LoadExpansions(openFileDialog.FileName) : null;
        }

        private void PatientName_LostFocus(object sender, RoutedEventArgs e)
        {
            if ( !patientGenderFound )
            {
                IGenderDeterminer genderDeterminer = new WebApiGenderDeterminer();
                var isNameMale = genderDeterminer.IsNameMale(( sender as TextBox )?.Text);
                PatientGender.IsChecked = isNameMale;
                patientGenderFound = true;
            }
        }
    }
}
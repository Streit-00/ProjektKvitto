using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektKvitto
{
    //commentsumos77/ProjektKvitto
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            string productName = "Dator";
            string productDescription = "Contains a CPU, and a whole lot of other stuff.";
            string productPrice = "1500";
            // Window options
            Title = "GUI App";
            Width = 400;
            Height = 300;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Scrolling
            ScrollViewer root = new ScrollViewer();
            root.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = root;

            // Main grid
            Grid receipt = new Grid();
            root.Content = receipt;
            receipt.Margin = new Thickness(5);
            receipt.RowDefinitions.Add(new RowDefinition());
            receipt.RowDefinitions.Add(new RowDefinition());
            receipt.ColumnDefinitions.Add(new ColumnDefinition());

            StackPanel receiptProductPanel = new StackPanel
            {
                Orientation = Orientation.Vertical

            };
            receipt.Children.Add(receiptProductPanel);
            Grid.SetRow(receiptProductPanel, 0);
            Grid.SetColumn(receiptProductPanel, 0);

            #region Header Grid
            Grid receiptHeaderGrid = new Grid();
            receiptHeaderGrid.RowDefinitions.Add(new RowDefinition());
            receiptHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptProductPanel.Children.Add(receiptHeaderGrid);

            Label receiptNameLabel = CreateBorderdLabel("Produkt");
            receiptHeaderGrid.Children.Add(receiptNameLabel);
            Grid.SetRow(receiptNameLabel, 0);
            Grid.SetColumn(receiptNameLabel, 0);
            Label receiptDescriptionLabel = CreateBorderdLabel("Antal");
            receiptHeaderGrid.Children.Add(receiptDescriptionLabel);
            Grid.SetRow(receiptDescriptionLabel, 0);
            Grid.SetColumn(receiptDescriptionLabel, 1);
            Label receiptPriceLabel = CreateBorderdLabel("Styckpris");
            receiptHeaderGrid.Children.Add(receiptPriceLabel);
            Grid.SetRow(receiptPriceLabel, 0);
            Grid.SetColumn(receiptPriceLabel, 2);
            Label receiptTotPriceLabel = CreateBorderdLabel("TotalPris");
            receiptHeaderGrid.Children.Add(receiptTotPriceLabel);
            Grid.SetRow(receiptTotPriceLabel, 0);
            Grid.SetColumn(receiptTotPriceLabel, 3);
            #endregion Header

            receiptProductPanel.Children.Add(creatReceiptProductGrid(productName, 5, int.Parse(productPrice)));
            receiptProductPanel.Children.Add(creatReceiptProductGrid(productName, 2, int.Parse(productPrice)));
            receiptProductPanel.Children.Add(creatReceiptProductGrid(productName, 5, int.Parse(productPrice)));
            receiptProductPanel.Children.Add(creatReceiptProductGrid(productName, 1, int.Parse(productPrice)));

            #region Receipt Sum

            Grid receiptSumGrid = new Grid();
            receiptSumGrid.Margin = new Thickness(0,5,0,0);
            receiptSumGrid.RowDefinitions.Add(new RowDefinition());
            receiptSumGrid.RowDefinitions.Add(new RowDefinition());
            receiptSumGrid.RowDefinitions.Add(new RowDefinition());
            receiptSumGrid.RowDefinitions.Add(new RowDefinition());
            receiptSumGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptSumGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptProductPanel.Children.Add(receiptSumGrid);

            #region Receipt Colum 0
            Label recepitRebateCodeLabel = CreateBorderdLabel("Rabattkod");
            receiptSumGrid.Children.Add(recepitRebateCodeLabel);
            Grid.SetRow(recepitRebateCodeLabel, 0);
            Grid.SetColumn(recepitRebateCodeLabel, 0);
            Label receiptSumLabel = CreateBorderdLabel("Summa");
            receiptSumGrid.Children.Add(receiptSumLabel);
            Grid.SetRow(receiptSumLabel, 1);
            Grid.SetColumn(receiptSumLabel, 0);
            Label rebateCodeLabel = CreateBorderdLabel("Rabatt");
            receiptSumGrid.Children.Add(rebateCodeLabel);
            Grid.SetRow(rebateCodeLabel, 2);
            Grid.SetColumn(rebateCodeLabel, 0);
            Label receiptRebateSumLabel = CreateBorderdLabel("Summa efter rabat");
            receiptSumGrid.Children.Add(receiptRebateSumLabel);
            Grid.SetRow(receiptRebateSumLabel, 3);
            Grid.SetColumn(receiptRebateSumLabel, 0);
            #endregion Receipt Colum 0

            #region Receipt Colum 1
            //Label recepitRebateCodeLabel = CreateBorderdLabel(rebateCodeTextBox.Text);
            Label recepitRebateCode = CreateBorderdLabel("Abc123");
            receiptSumGrid.Children.Add(recepitRebateCode);
            Grid.SetRow(recepitRebateCode, 0);
            Grid.SetColumn(recepitRebateCode, 1);
            //Vet inte hur jag skulle göra på denna så alla efter kommer att utgå från denna
            Label receiptSum = CreateBorderdLabel((int.Parse(productPrice)*5).ToString() + "Kr");
            receiptSumGrid.Children.Add(receiptSum);
            Grid.SetRow(receiptSum, 1);
            Grid.SetColumn(receiptSum, 1);
            //Tog 20% som ett exempel
            Label rebateCode = CreateBorderdLabel(((int.Parse(productPrice) * 5)*0.20).ToString() + "kr" + "(20%)");
            receiptSumGrid.Children.Add(rebateCode);
            Grid.SetRow(rebateCode, 2);
            Grid.SetColumn(rebateCode, 1);
            Label receiptRebateSum = CreateBorderdLabel(((int.Parse(productPrice) * 5) * 0.80).ToString() + "kr");
            receiptSumGrid.Children.Add(receiptRebateSum);
            Grid.SetRow(receiptRebateSum, 3);
            Grid.SetColumn(receiptRebateSum, 1);
            #endregion Receipt Colum 1
            #endregion Receipt Sum

        }

        public static Grid creatReceiptProductGrid(string productName, int quantity, int price)
        {
            Grid receiptProductGrid = new Grid();
            receiptProductGrid.RowDefinitions.Add(new RowDefinition());
            receiptProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
            receiptProductGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Label productNameLabel = CreateBorderdLabel(productName);
            receiptProductGrid.Children.Add(productNameLabel);
            Grid.SetRow(productNameLabel, 0);
            Grid.SetColumn(productNameLabel, 0);

            Label receiptquantityLabel = CreateBorderdLabel(quantity.ToString());
            receiptProductGrid.Children.Add(receiptquantityLabel);
            Grid.SetRow(receiptquantityLabel, 0);
            Grid.SetColumn(receiptquantityLabel, 1);

            Label receiptPriceLabel = CreateBorderdLabel(price.ToString());
            receiptProductGrid.Children.Add(receiptPriceLabel);
            Grid.SetRow(receiptPriceLabel, 0);
            Grid.SetColumn(receiptPriceLabel, 2);

            Label recepitTotPriceLabel = CreateBorderdLabel((price*quantity).ToString());
            receiptProductGrid.Children.Add(recepitTotPriceLabel);
            Grid.SetRow(recepitTotPriceLabel, 0);
            Grid.SetColumn(recepitTotPriceLabel, 3);


            return receiptProductGrid;
        }
        public static Label CreateBorderdLabel(string header)
        {
            Label label = new Label
            {
                Content = header,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 0, 0, 0),
                Padding = new Thickness(2),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1)
            };
            return label;
        }
    }
}

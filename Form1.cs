using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class FlorarieApp : Form
{
    private List<Produs> produse = new List<Produs>();
    private ListBox produseListBox;
    private TextBox numeProdusTextBox, pretProdusTextBox, stocProdusTextBox;
    
    private ListBox comenziListBox;
    private TextBox clientComandaTextBox;
    
    private ListBox livrariListBox;
    private TextBox adresaLivrareTextBox;

    public FlorarieApp()
    {
        // Configurare Form
        this.Text = "Florarie";
        this.Width = 600;
        this.Height = 400;

        // Secțiunea pentru produse
        var produsGroupBox = new GroupBox { Text = "Produse", Top = 10, Left = 10, Width = 550, Height = 150 };
        this.Controls.Add(produsGroupBox);

        var numeLabel = new Label { Text = "Nume:", Top = 20, Left = 10 };
        produsGroupBox.Controls.Add(numeLabel);
        numeProdusTextBox = new TextBox { Top = 20, Left = 100, Width = 100 };
        produsGroupBox.Controls.Add(numeProdusTextBox);

        var pretLabel = new Label { Text = "Preț:", Top = 50, Left = 10 };
        produsGroupBox.Controls.Add(pretLabel);
        pretProdusTextBox = new TextBox { Top = 50, Left = 100, Width = 100 };
        produsGroupBox.Controls.Add(pretProdusTextBox);

        var stocLabel = new Label { Text = "Stoc:", Top = 80, Left = 10 };
        produsGroupBox.Controls.Add(stocLabel);
        stocProdusTextBox = new TextBox { Top = 80, Left = 100, Width = 100 };
        produsGroupBox.Controls.Add(stocProdusTextBox);

        var addProdusButton = new Button { Text = "Adaugă Produs", Top = 110, Left = 100 };
        addProdusButton.Click += AddProdus;
        produsGroupBox.Controls.Add(addProdusButton);

        produseListBox = new ListBox { Top = 20, Left = 220, Width = 300, Height = 100 };
        produsGroupBox.Controls.Add(produseListBox);

        // Secțiunea pentru comenzi
        var comandaGroupBox = new GroupBox { Text = "Comenzi", Top = 170, Left = 10, Width = 550, Height = 100 };
        this.Controls.Add(comandaGroupBox);

        var clientLabel = new Label { Text = "Client:", Top = 20, Left = 10 };
        comandaGroupBox.Controls.Add(clientLabel);
        clientComandaTextBox = new TextBox { Top = 20, Left = 100, Width = 100 };
        comandaGroupBox.Controls.Add(clientComandaTextBox);

        var addComandaButton = new Button { Text = "Adaugă Comandă", Top = 50, Left = 100 };
        addComandaButton.Click += AddComanda;
        comandaGroupBox.Controls.Add(addComandaButton);

        comenziListBox = new ListBox { Top = 20, Left = 220, Width = 300, Height = 60 };
        comandaGroupBox.Controls.Add(comenziListBox);

        // Secțiunea pentru livrări
        var livrareGroupBox = new GroupBox { Text = "Livrări", Top = 280, Left = 10, Width = 550, Height = 80 };
        this.Controls.Add(livrareGroupBox);

        var adresaLabel = new Label { Text = "Adresă:", Top = 20, Left = 10 };
        livrareGroupBox.Controls.Add(adresaLabel);
        adresaLivrareTextBox = new TextBox { Top = 20, Left = 100, Width = 100 };
        livrareGroupBox.Controls.Add(adresaLivrareTextBox);

        var addLivrareButton = new Button { Text = "Adaugă Livrare", Top = 50, Left = 100 };
        addLivrareButton.Click += AddLivrare;
        livrareGroupBox.Controls.Add(addLivrareButton);

        livrariListBox = new ListBox { Top = 20, Left = 220, Width = 300, Height = 40 };
        livrareGroupBox.Controls.Add(livrariListBox);
    }

    private void AddProdus(object sender, EventArgs e)
    {
        var produs = new Produs
        {
            ProdusId = produse.Count + 1,
            Nume = numeProdusTextBox.Text,
            Pret = decimal.Parse(pretProdusTextBox.Text),
            Stoc = int.Parse(stocProdusTextBox.Text)
        };
        produse.Add(produs);
        produseListBox.Items.Add($"{produs.Nume} - {produs.Pret} RON - Stoc: {produs.Stoc}");
    }

    private void AddComanda(object sender, EventArgs e)
    {
        var comanda = new Comanda
        {
            ComandaId = comenziListBox.Items.Count + 1,
            Client = clientComandaTextBox.Text,
            Data = DateTime.Now,
            Produse = new List<Produs>(produse)  // Toate produsele adăugate
        };
        comenziListBox.Items.Add($"Comanda {comanda.ComandaId} - {comanda.Client}");
    }

    private void AddLivrare(object sender, EventArgs e)
    {
        var livrare = new Livrare
        {
            LivrareId = livrariListBox.Items.Count + 1,
            ComandaId = 1,  // Exemplu: prima comandă
            Adresa = adresaLivrareTextBox.Text,
            DataLivrare = DateTime.Now.AddDays(1),
            Status = "în curs"
        };
        livrariListBox.Items.Add($"Livrare {livrare.LivrareId} - {livrare.Adresa} - {livrare.Status}");
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new FlorarieApp());
    }
}

using AdventureAdmin.Ui.Product;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void productosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var productList = Program.ServiceProvider.GetRequiredService<ProductList>();
        productList.Show();
    }
}

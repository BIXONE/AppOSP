using BibliotekaOSP.Encje;
using System.Text.Json;

namespace AppOSP;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        CounterBtn.Text = "Click";

        string request = "https://localhost:7075/członkowie/3";
        //WebClient wc = new() { Proxy = null };
        //wc.DownloadString(request);
        //foreach (string name in wc.ResponseHeaders.Keys)
        //{
        //    Console.WriteLine(name + "=" + wc.ResponseHeaders[name]);
        //}

        string html = await new HttpClient().GetStringAsync(request);
        Początek.Text = html;

        JsonDocument document = JsonDocument.Parse(html);

        Początek.Text += "\n" + document.RootElement.GetProperty("imię");


    }
}
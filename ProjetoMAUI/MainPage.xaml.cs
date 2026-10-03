using System.Text.Json;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class MainPage : ContentPage
{
    private List<Candidate> candidates = [];
    private bool loaded;

    public MainPage()
    {
        InitializeComponent();
        CopyButton.IsEnabled = false;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (loaded) return;
        try
        {
            using var stream = await FileSystem.Current.OpenAppPackageFileAsync("candidates.json");
            candidates = await JsonSerializer.DeserializeAsync<List<Candidate>>(stream) ?? [];
            loaded = true;
            RefreshCards();
        }
        catch (Exception)
        {
            StatusLabel.Text = "Não foi possível carregar os apoios. Reabra a tela para tentar novamente.";
        }
    }

    private IEnumerable<Candidate> VisibleCandidates => candidates.Where(candidate => !candidate.Optional || DeputiesSwitch.IsToggled);

    private void RefreshCards()
    {
        BindableLayout.SetItemsSource(CandidateCards, VisibleCandidates.ToList());
        CopyButton.IsEnabled = VisibleCandidates.Any(candidate => !string.IsNullOrWhiteSpace(candidate.Name));
        StatusLabel.Text = CopyButton.IsEnabled
            ? "Copie os apoios para guardar ou compartilhar."
            : "Os apoios serão exibidos aqui assim que forem definidos.";
    }

    private void OnDeputiesToggled(object? sender, ToggledEventArgs e) => RefreshCards();

    private async void OnCopyClicked(object? sender, EventArgs e)
    {
        var lines = VisibleCandidates.Select(candidate => $"{candidate.Office}: {candidate.DisplayName}" +
            (string.IsNullOrWhiteSpace(candidate.Number) ? "" : $" · {candidate.Number}") +
            (string.IsNullOrWhiteSpace(candidate.Party) ? "" : $" · {candidate.Party}"));
        try
        {
            await Clipboard.Default.SetTextAsync("AppEvandroEuApoio · Rio de Janeiro\n\n" + string.Join("\n", lines));
            StatusLabel.Text = "Colinha copiada!";
            SemanticScreenReader.Default.Announce(StatusLabel.Text);
        }
        catch (Exception)
        {
            StatusLabel.Text = "Não foi possível copiar a colinha. Tente novamente.";
        }
    }
}

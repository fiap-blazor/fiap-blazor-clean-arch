namespace FIAP.Fiapfy.WebApp.Components.Pages
{
    public partial class Home
    {
        private List<PlaylistModel> playlistsRecentementeTocadas = new();
        private List<PlaylistModel> playlistsDestaque = new();
        private List<ArtistaModel> artistasPopulares = new();

        protected override async Task OnInitializedAsync()
        {
            await CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            playlistsRecentementeTocadas = new List<PlaylistModel>
        {
            new() { Id = 1, Nome = "Rock Clássico", ImageUrl = "https://picsum.photos/64/64?random=1" },
            new() { Id = 2, Nome = "Jazz Instrumental", ImageUrl = "https://picsum.photos/64/64?random=2" },
            new() { Id = 3, Nome = "Músicas Favoritas", ImageUrl = "https://picsum.photos/64/64?random=3" },
            new() { Id = 4, Nome = "Workout Mix", ImageUrl = "https://picsum.photos/64/64?random=4" },
            new() { Id = 5, Nome = "Chill Vibes", ImageUrl = "https://picsum.photos/64/64?random=5" },
            new() { Id = 6, Nome = "Top Hits 2024", ImageUrl = "https://picsum.photos/64/64?random=6" },
        };

            playlistsDestaque = new List<PlaylistModel>
        {
            new() { Id = 10, Nome = "Today's Top Hits", Descricao = "Os maiores sucessos do momento", ImageUrl = "https://picsum.photos/300/300?random=21" },
            new() { Id = 11, Nome = "RapCaviar", Descricao = "Rap e Hip Hop", ImageUrl = "https://picsum.photos/300/300?random=22" },
            new() { Id = 12, Nome = "All Out 80s", Descricao = "Os clássicos dos anos 80", ImageUrl = "https://picsum.photos/300/300?random=23" },
            new() { Id = 13, Nome = "Peaceful Piano", Descricao = "Piano relaxante", ImageUrl = "https://picsum.photos/300/300?random=24" },
            new() { Id = 14, Nome = "Rock Legends", Descricao = "Lendas do rock", ImageUrl = "https://picsum.photos/300/300?random=25" },
            new() { Id = 15, Nome = "Latin Hits", Descricao = "Sucessos latinos", ImageUrl = "https://picsum.photos/300/300?random=26" },
        };

            artistasPopulares = new List<ArtistaModel>
        {
            new() { Id = "1", Nome = "The Beatles", ImageUrl = "https://cdn-images.dzcdn.net/images/artist/fe9eb4463ea87452e84ed97e0c86b878/1900x1900-000000-80-0-0.jpg" },
            new() { Id = "2", Nome = "Lady Gaga", ImageUrl = "https://i.scdn.co/image/ab6761610000e5ebaadc18cac8d48124357c38e6" },
            new() { Id = "3", Nome = "Linkin Park", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d8/Linkin_Park_-_From_Zero_Lead_Press_Photo_-_James_Minchin_III.jpg" },
            new() { Id = "4", Nome = "Tears for Fears", ImageUrl = "https://i.scdn.co/image/ab676161000051741e63dea1bded4ae1d53b5c9a" },
            new() { Id = "5", Nome = "Avenged Sevenfold", ImageUrl = "https://fitademo.com.br/wp-content/uploads/2025/09/A7x.png" },
            new() { Id = "6", Nome = "Metallica", ImageUrl = "https://i.scdn.co/image/ab6761610000e5eb69ca98dd3083f1082d740e44" },
        };
        }

        private string ObterPrimeiroNome(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Usuário";

            var partes = email.Split('@');
            return partes[0];
        }

        private class PlaylistModel
        {
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string Descricao { get; set; } = string.Empty;
            public string ImageUrl { get; set; } = string.Empty;
        }

        private class ArtistaModel
        {
            public string Id { get; set; } = string.Empty;
            public string Nome { get; set; } = string.Empty;
            public string ImageUrl { get; set; } = string.Empty;
        }
    }
}